using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null)
    {
        _logger.LogInformation("Notification sent to {UserId}: {Title} - {Message} (Type: {Type})", userId, title, message, type);
        return Task.CompletedTask;
    }

    public Task SendBulkNotificationAsync(IEnumerable<Guid> userIds, string title, string message, NotificationType type, Guid? relatedEntityId = null)
    {
        var userIdList = userIds.ToList();
        _logger.LogInformation("Bulk notification sent to {Count} users: {Title} (Type: {Type})", userIdList.Count, title, type);
        return Task.CompletedTask;
    }
}
