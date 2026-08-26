using BloodNetwork.Application.Interfaces;
using BloodNetwork.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BloodNetwork.Api.Services;

public class SignalRNotificationBroadcaster : INotificationBroadcaster
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public SignalRNotificationBroadcaster(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task BroadcastNotificationAsync(Guid userId, string title, string message, string type, Guid? relatedEntityId = null)
    {
        await _hubContext.Clients.Group($"user_{userId}").SendAsync("ReceiveNotification", new
        {
            title,
            message,
            type,
            relatedEntityId,
            createdAt = DateTime.UtcNow,
            isRead = false
        });
    }

    public async Task BroadcastUnreadCountAsync(Guid userId, int count)
    {
        await _hubContext.Clients.Group($"user_{userId}").SendAsync("UnreadCount", count);
    }
}
