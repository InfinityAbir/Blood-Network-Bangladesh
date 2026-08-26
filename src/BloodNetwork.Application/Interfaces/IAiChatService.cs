namespace BloodNetwork.Application.Interfaces;

public interface IAiChatService
{
    Task<string> ChatAsync(string message, List<ChatMessage>? history = null);
}

public class ChatMessage
{
    public string Role { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
