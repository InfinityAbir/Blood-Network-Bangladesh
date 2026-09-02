using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BloodNetwork.Infrastructure.Services;

/// <summary>
/// FCM push sender. Delivers an OS-level notification to every registered Android/Web device
/// of the target user (iOS reserved for later). Purely additive: if no Firebase credential
/// is available (local dev, tests) it degrades to a silent no-op so the in-app
/// notification layer is never blocked. Invalid/unregistered tokens are removed
/// automatically so a stale token never silently drops notifications forever.
/// </summary>
public class PushNotificationService : IPushNotificationSender
{
    private readonly IRepository<DeviceToken> _tokenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PushNotificationService> _logger;
    private readonly FirebaseOptions _options;

    private readonly object _initLock = new();
    private FirebaseApp? _app;
    private bool _initAttempted;
    private bool _disabled;

    public PushNotificationService(
        IOptions<FirebaseOptions> options,
        IRepository<DeviceToken> tokenRepository,
        IUnitOfWork unitOfWork,
        ILogger<PushNotificationService> logger)
    {
        _options = options.Value;
        _tokenRepository = tokenRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task SendPushAsync(
        Guid userId,
        string title,
        string message,
        string type,
        Guid? relatedEntityId = null,
        string? metadata = null,
        CancellationToken cancellationToken = default)
    {
        if (_disabled) return;

        IReadOnlyList<DeviceToken> devices;
        try
        {
            devices = await _tokenRepository.FindAsync(
                t => t.UserId == userId && (t.Platform == DevicePlatform.Android || t.Platform == DevicePlatform.Web),
                cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Device-token lookup failed for user {UserId}", userId);
            return;
        }

        if (devices.Count == 0)
        {
            _logger.LogInformation("No registered FCM devices for notification recipient {UserId}", userId);
            return;
        }

        var app = GetApp();
        if (app is null) return;

        var fcm = FirebaseMessaging.GetMessaging(app);
        foreach (var device in devices)
        {
            try
            {
                var isAndroid = device.Platform == DevicePlatform.Android;

                var payload = new Message
                {
                    Token = device.Token,
                    // Android gets a DATA-ONLY message: including a notification block hands
                    // rendering to the system tray, which skips PushMessagingService entirely
                    // whenever the app isn't foregrounded. That path is opaque (nothing the app
                    // can log) and is what aggressive OEM ROMs suppress. Data-only always wakes
                    // onMessageReceived, so the app posts the notification through its own
                    // channel and every delivery is observable. Web still needs the block —
                    // its service worker renders from it.
                    Notification = isAndroid
                        ? null
                        : new FirebaseAdmin.Messaging.Notification { Title = title, Body = message },
                    Android = isAndroid
                        ? new AndroidConfig { Priority = Priority.High }
                        : null,
                    Webpush = device.Platform == DevicePlatform.Web
                        ? new WebpushConfig
                        {
                            Notification = new WebpushNotification
                            {
                                Icon = "/favicon.ico"
                            }
                        }
                        : null,
                    Data = new Dictionary<string, string>
                    {
                        ["title"] = title,
                        ["message"] = message,
                        ["type"] = type,
                        ["relatedEntityId"] = relatedEntityId?.ToString() ?? string.Empty,
                        ["metadata"] = metadata ?? string.Empty
                    }
                };
                await fcm.SendAsync(payload, cancellationToken);
                _logger.LogInformation("FCM push accepted for device ending ...{Tail}", DeviceTail(device.Token));
            }
            catch (FirebaseMessagingException ex) when (IsPermanentlyInvalidToken(ex))
            {
                _logger.LogInformation("Removing invalid FCM token ending ...{Tail} for user {UserId}", DeviceTail(device.Token), userId);
                try
                {
                    // A dead FCM token must be physically removed; soft deletion retains the
                    // unique Token index and prevents the device from registering again.
                    await _tokenRepository.HardDeleteAsync(device, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception inner)
                {
                    _logger.LogWarning(inner, "Failed to remove invalid FCM token for user {UserId}", userId);
                }
            }
            catch (Exception ex)
            {
                // Transient failure (e.g. FCM quota/backoff) — leave the token, log it.
                _logger.LogWarning(ex, "FCM send failed for user {UserId}", userId);
            }
        }
    }

    private FirebaseApp? GetApp()
    {
        if (_initAttempted) return _app;
        lock (_initLock)
        {
            if (_initAttempted) return _app;
            _initAttempted = true;
            try
            {
                // The service is registered scoped (one instance per request scope), but the
                // named FirebaseApp lives for the process lifetime. Reuse it if a previous
                // scope already created it, otherwise create once.
                try
                {
                    _app = FirebaseApp.GetInstance("bloodnetwork");
                }
                catch
                {
                    var options = BuildOptions();
                    _app = FirebaseApp.Create(options, "bloodnetwork");
                }
                _logger.LogInformation("Firebase Admin initialized (FCM push enabled)");
            }
            catch (Exception ex)
            {
                _disabled = true;
                _logger.LogWarning(
                    "Firebase Admin could not be initialized. Push notifications disabled. " +
                    "Set Firebase:ServiceAccountPath, Firebase:ServiceAccountJson, or GOOGLE_APPLICATION_CREDENTIALS. Error: {Message}",
                    ex.Message);
                _app = null;
            }
            return _app;
        }
    }

    private AppOptions BuildOptions()
    {
        var options = new AppOptions();
        if (!string.IsNullOrWhiteSpace(_options.ServiceAccountPath) && File.Exists(_options.ServiceAccountPath))
        {
            options.Credential = GoogleCredential.FromFile(_options.ServiceAccountPath);
        }
        else if (!string.IsNullOrWhiteSpace(_options.ServiceAccountJson))
        {
            options.Credential = GoogleCredential.FromJson(_options.ServiceAccountJson);
        }
        // No explicit credential -> Firebase Admin falls back to Application Default
        // Credentials (GOOGLE_APPLICATION_CREDENTIALS env var), which is the deploy path.
        return options;
    }

    private static bool IsPermanentlyInvalidToken(FirebaseMessagingException ex) =>
        ex.MessagingErrorCode is MessagingErrorCode.Unregistered
            or MessagingErrorCode.InvalidArgument
            or MessagingErrorCode.SenderIdMismatch;

    private static string DeviceTail(string token) =>
        token.Length <= 8 ? token : token[^8..];
}
