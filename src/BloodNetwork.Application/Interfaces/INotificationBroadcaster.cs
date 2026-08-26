namespace BloodNetwork.Application.Interfaces;

public interface INotificationBroadcaster
{
    Task BroadcastNotificationAsync(Guid userId, string title, string message, string type, Guid? relatedEntityId = null);
    Task BroadcastUnreadCountAsync(Guid userId, int count);
}
