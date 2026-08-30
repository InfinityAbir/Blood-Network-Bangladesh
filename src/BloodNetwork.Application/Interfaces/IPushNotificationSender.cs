using System.Threading;
using System.Threading.Tasks;

namespace BloodNetwork.Application.Interfaces;

/// <summary>
/// Sends OS-level push notifications for a user (currently FCM). Sits behind the same
/// notification chokepoint as the SignalR broadcaster so every in-app notification also
/// reaches backgrounded/killed devices. Implementations degrade to a no-op when no push
/// provider is configured (e.g. local dev / tests).
/// </summary>
public interface IPushNotificationSender
{
    Task SendPushAsync(
        Guid userId,
        string title,
        string message,
        string type,
        Guid? relatedEntityId = null,
        string? metadata = null,
        CancellationToken cancellationToken = default);
}