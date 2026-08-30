using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly IRepository<Notification> _notificationRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<NotificationService> _logger;
    private readonly INotificationBroadcaster? _broadcaster;
    private readonly IPushNotificationSender? _pushSender;

    public NotificationService(
        IRepository<Notification> notificationRepo,
        IUnitOfWork unitOfWork,
        ILogger<NotificationService> logger,
        INotificationBroadcaster? broadcaster = null,
        IPushNotificationSender? pushSender = null)
    {
        _notificationRepo = notificationRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _broadcaster = broadcaster;
        _pushSender = pushSender;
    }

    public async Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null, string? metadata = null)
    {
        var notification = new Notification
        {
            UserId = userId,
            Type = type,
            Title = title,
            Message = message,
            RelatedEntityId = relatedEntityId,
            Metadata = metadata,
            IsRead = false
        };

        await _notificationRepo.AddAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Notification sent to {UserId}: {Title} (Type: {Type})", userId, title, type);

        if (_broadcaster != null)
        {
            var count = await _notificationRepo.CountAsync(n => n.UserId == userId && !n.IsRead);
            await _broadcaster.BroadcastNotificationAsync(userId, title, message, type.ToString(), relatedEntityId, metadata);
            await _broadcaster.BroadcastUnreadCountAsync(userId, count);
        }

        await SendPushAsync(userId, title, message, type, relatedEntityId, metadata);
    }

    public async Task SendBulkNotificationAsync(IEnumerable<Guid> userIds, string title, string message, NotificationType type, Guid? relatedEntityId = null, string? metadata = null)
    {
        var userIdList = userIds.ToList();
        foreach (var userId in userIdList)
        {
            var notification = new Notification
            {
                UserId = userId,
                Type = type,
                Title = title,
                Message = message,
                RelatedEntityId = relatedEntityId,
                Metadata = metadata,
                IsRead = false
            };

            await _notificationRepo.AddAsync(notification);
        }

        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Bulk notification sent to {Count} users: {Title} (Type: {Type})", userIdList.Count, title, type);

        if (_broadcaster != null)
        {
            foreach (var userId in userIdList)
            {
                var count = await _notificationRepo.CountAsync(n => n.UserId == userId && !n.IsRead);
                await _broadcaster.BroadcastNotificationAsync(userId, title, message, type.ToString(), relatedEntityId, metadata);
                await _broadcaster.BroadcastUnreadCountAsync(userId, count);
            }
        }

        foreach (var userId in userIdList)
        {
            await SendPushAsync(userId, title, message, type, relatedEntityId, metadata);
        }
    }

    private async Task SendPushAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null, string? metadata = null)
    {
        if (_pushSender is null) return;
        try
        {
            await _pushSender.SendPushAsync(userId, title, message, type.ToString(), relatedEntityId, metadata);
        }
        catch (Exception ex)
        {
            // Push is additive — never let it break or slow down the in-app notification.
            _logger.LogWarning(ex, "Push notification send failed for user {UserId}", userId);
        }
    }

    public async Task<IReadOnlyList<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page = 1, int pageSize = 20, NotificationType? type = null)
    {
        // NOTE: Ideally push OrderBy/Skip/Take to DB via IRepository with IQueryable or paginated Find.
        // Current repo returns IReadOnlyList; filtering at DB via predicate but ordering/paging in memory.
        // Clamp pagination to avoid excessive memory load.
        page = Math.Max(page, 1);
        pageSize = Math.Clamp(pageSize, 1, 50);
        var allNotifications = type.HasValue
            ? await _notificationRepo.FindAsync(n => n.UserId == userId && n.Type == type.Value)
            : await _notificationRepo.FindAsync(n => n.UserId == userId);
        return allNotifications
            .OrderByDescending(n => n.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(MapToDto)
            .ToList();
    }

    public async Task<int> GetUnreadCountAsync(Guid userId)
    {
        return await _notificationRepo.CountAsync(n => n.UserId == userId && !n.IsRead);
    }

    public async Task<NotificationDto?> MarkAsReadAsync(Guid notificationId, Guid userId)
    {
        var notification = await _notificationRepo.GetByIdAsync(notificationId);
        if (notification == null || notification.UserId != userId)
            return null;

        notification.IsRead = true;
        notification.ReadAt = DateTime.UtcNow;
        notification.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        if (_broadcaster != null)
        {
            var count = await _notificationRepo.CountAsync(n => n.UserId == userId && !n.IsRead);
            await _broadcaster.BroadcastUnreadCountAsync(userId, count);
        }

        return MapToDto(notification);
    }

    public async Task MarkAllAsReadAsync(Guid userId)
    {
        var unreadNotifications = await _notificationRepo.FindAsync(n => n.UserId == userId && !n.IsRead);
        foreach (var notification in unreadNotifications)
        {
            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            notification.UpdatedAt = DateTime.UtcNow;
        }

        await _unitOfWork.SaveChangesAsync();

        if (_broadcaster != null)
        {
            await _broadcaster.BroadcastUnreadCountAsync(userId, 0);
        }
    }

    public async Task<bool> DeleteAsync(Guid notificationId, Guid userId)
    {
        var notification = await _notificationRepo.GetByIdAsync(notificationId);
        if (notification == null || notification.UserId != userId)
            return false;

        var wasUnread = !notification.IsRead;
        await _notificationRepo.DeleteAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        if (wasUnread && _broadcaster != null)
        {
            var count = await _notificationRepo.CountAsync(n => n.UserId == userId && !n.IsRead);
            await _broadcaster.BroadcastUnreadCountAsync(userId, count);
        }

        return true;
    }

    public async Task ClearAllAsync(Guid userId)
    {
        var all = await _notificationRepo.FindAsync(n => n.UserId == userId);
        foreach (var notification in all)
        {
            await _notificationRepo.DeleteAsync(notification);
        }

        await _unitOfWork.SaveChangesAsync();

        if (_broadcaster != null)
        {
            await _broadcaster.BroadcastUnreadCountAsync(userId, 0);
        }
    }

    private static NotificationDto MapToDto(Notification notification)
    {
        return new NotificationDto
        {
            Id = notification.Id,
            Type = notification.Type,
            Title = notification.Title,
            Message = notification.Message,
            RelatedEntityId = notification.RelatedEntityId,
            IsRead = notification.IsRead,
            ReadAt = notification.ReadAt,
            CreatedAt = notification.CreatedAt,
            Metadata = notification.Metadata
        };
    }
}
