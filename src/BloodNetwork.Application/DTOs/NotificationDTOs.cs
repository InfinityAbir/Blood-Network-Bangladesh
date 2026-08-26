using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public class NotificationDto
{
    public Guid Id { get; set; }
    public NotificationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Guid? RelatedEntityId { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class MarkNotificationReadRequest
{
    public bool IsRead { get; set; } = true;
}

public class UnreadCountDto
{
    public int Count { get; set; }
}
