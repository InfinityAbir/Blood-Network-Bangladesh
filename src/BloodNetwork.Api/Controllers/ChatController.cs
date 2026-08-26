using BloodNetwork.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IAiChatService _chatService;

    public ChatController(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ChatResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Chat([FromBody] ChatRequest request, CancellationToken cancellationToken)
    {
        var reply = await _chatService.ChatAsync(request.Message, request.History);
        return Ok(new ChatResponse { Reply = reply });
    }
}

public class ChatRequest
{
    public string Message { get; set; } = string.Empty;
    public List<ChatMessage>? History { get; set; }
}

public class ChatResponse
{
    public string Reply { get; set; } = string.Empty;
}
