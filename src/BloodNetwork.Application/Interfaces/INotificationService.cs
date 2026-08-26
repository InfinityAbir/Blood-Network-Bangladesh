using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null);
    Task SendBulkNotificationAsync(IEnumerable<Guid> userIds, string title, string message, NotificationType type, Guid? relatedEntityId = null);
    Task<IReadOnlyList<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page = 1, int pageSize = 20);
    Task<int> GetUnreadCountAsync(Guid userId);
    Task<NotificationDto?> MarkAsReadAsync(Guid notificationId, Guid userId);
    Task MarkAllAsReadAsync(Guid userId);
}
