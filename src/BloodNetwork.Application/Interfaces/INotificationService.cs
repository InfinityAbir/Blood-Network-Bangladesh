using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null);
    Task SendBulkNotificationAsync(IEnumerable<Guid> userIds, string title, string message, NotificationType type, Guid? relatedEntityId = null);
}
