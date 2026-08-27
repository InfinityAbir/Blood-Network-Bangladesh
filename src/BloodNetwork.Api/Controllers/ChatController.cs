using System.ComponentModel.DataAnnotations;
using BloodNetwork.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

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
    [AllowAnonymous]
    [EnableRateLimiting("search")]
    [ProducesResponseType(typeof(ChatResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Chat([FromBody] ChatRequest request, CancellationToken cancellationToken)
    {
        if (request.History != null && request.History.Count > 20)
        {
            request.History = request.History.Skip(Math.Max(0, request.History.Count - 20)).ToList();
        }

        var reply = await _chatService.ChatAsync(request.Message, request.History);
        return Ok(new ChatResponse { Reply = reply });
    }
}

public class ChatRequest
{
    [Required]
    [MaxLength(4000)]
    public string Message { get; set; } = string.Empty;
    public List<ChatMessage>? History { get; set; }
}

public class ChatResponse
{
    public string Reply { get; set; } = string.Empty;
}
