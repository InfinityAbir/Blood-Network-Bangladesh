using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class DeviceTokenService
{
    // Probation window for last-seen tokens. Devices that never report activity for this
    // long are removed lazily the next time their owner registers a token.
    private static readonly TimeSpan StaleTokenWindow = TimeSpan.FromDays(180);

    private readonly IRepository<DeviceToken> _tokenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeviceTokenService> _logger;

    public DeviceTokenService(
        IRepository<DeviceToken> tokenRepository,
        IUnitOfWork unitOfWork,
        ILogger<DeviceTokenService> logger)
    {
        _tokenRepository = tokenRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    /// <summary>
    /// Upserts a device token for the caller. A token that already exists (e.g. reclaimed
    /// after the previous owner reinstalled the app) is reassigned to the current user.
    /// </summary>
    public async Task<Result<bool>> RegisterAsync(Guid userId, RegisterPushTokenRequest request, CancellationToken cancellationToken = default)
    {
        var token = request.Token?.Trim();
        if (string.IsNullOrWhiteSpace(token) || token.Length < 16)
            return Result<bool>.Failure("A valid device token is required");

        var existing = await _tokenRepository.FirstOrDefaultAsync(
            t => t.Token == token, cancellationToken);

        if (existing is null)
        {
            await _tokenRepository.AddAsync(new DeviceToken
            {
                UserId = userId,
                Token = token,
                Platform = request.Platform,
                LastActiveAt = DateTime.UtcNow
            }, cancellationToken);
        }
        else
        {
            existing.UserId = userId;
            existing.Platform = request.Platform;
            existing.LastActiveAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;
            await _tokenRepository.UpdateAsync(existing, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        try
        {
            await PruneStaleTokensAsync(userId, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Stale device-token prune failed for user {UserId}", userId);
        }

        return Result<bool>.Success(true);
    }

    public async Task<Result<bool>> RemoveAsync(Guid userId, string token, CancellationToken cancellationToken = default)
    {
        var trimmed = token?.Trim();
        if (string.IsNullOrWhiteSpace(trimmed))
            return Result<bool>.Failure("A valid device token is required");

        var existing = await _tokenRepository.FirstOrDefaultAsync(
            t => t.Token == trimmed && t.UserId == userId, cancellationToken);

        if (existing is null)
            return Result<bool>.Failure("Device token not found");

        await _tokenRepository.DeleteAsync(existing, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<bool>.Success(true);
    }

    private async Task PruneStaleTokensAsync(Guid userId, CancellationToken cancellationToken)
    {
        var cutoff = DateTime.UtcNow.Subtract(StaleTokenWindow);
        var stale = await _tokenRepository.FindAsync(
            t => t.UserId == userId && t.LastActiveAt < cutoff, cancellationToken);
        foreach (var token in stale)
        {
            await _tokenRepository.DeleteAsync(token, cancellationToken);
        }
        if (stale.Count > 0)
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}