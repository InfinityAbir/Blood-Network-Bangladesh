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

    public NotificationService(
        IRepository<Notification> notificationRepo,
        IUnitOfWork unitOfWork,
        ILogger<NotificationService> logger)
    {
        _notificationRepo = notificationRepo;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task SendNotificationAsync(Guid userId, string title, string message, NotificationType type, Guid? relatedEntityId = null)
    {
        var notification = new Notification
        {
            UserId = userId,
            Type = type,
            Title = title,
            Message = message,
            RelatedEntityId = relatedEntityId,
            IsRead = false
        };

        await _notificationRepo.AddAsync(notification);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Notification sent to {UserId}: {Title} (Type: {Type})", userId, title, type);
    }

    public async Task SendBulkNotificationAsync(IEnumerable<Guid> userIds, string title, string message, NotificationType type, Guid? relatedEntityId = null)
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
                IsRead = false
            };

            await _notificationRepo.AddAsync(notification);
        }

        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Bulk notification sent to {Count} users: {Title} (Type: {Type})", userIdList.Count, title, type);
    }

    public async Task<IReadOnlyList<NotificationDto>> GetUserNotificationsAsync(Guid userId, int page = 1, int pageSize = 20)
    {
        var allNotifications = await _notificationRepo.FindAsync(n => n.UserId == userId);
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
            CreatedAt = notification.CreatedAt
        };
    }
}
