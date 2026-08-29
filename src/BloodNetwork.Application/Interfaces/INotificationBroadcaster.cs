namespace BloodNetwork.Application.Interfaces;

public interface INotificationBroadcaster
{
    Task BroadcastNotificationAsync(Guid userId, string title, string message, string type, Guid? relatedEntityId = null, string? metadata = null);
    Task BroadcastUnreadCountAsync(Guid userId, int count);
}
