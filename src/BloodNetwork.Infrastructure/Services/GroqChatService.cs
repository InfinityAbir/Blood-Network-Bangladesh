using System.Net.Http.Json;
using System.Text.Json;
using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BloodNetwork.Infrastructure.Services;

public class GroqChatService : IAiChatService
{
    private readonly HttpClient _httpClient;
    private readonly GroqOptions _options;
    private readonly ILogger<GroqChatService> _logger;

    private const string SystemPrompt = """
        You are Blood Buddy, a friendly AI assistant for Blood Network Bangladesh (ব্লাড নেটওয়ার্ক বাংলাদেশ).
        You help donors and blood requesters with:
        - Blood donation eligibility and health guidelines
        - How the platform works (registration, matching, requesting blood)
        - Blood group compatibility information
        - General blood donation FAQ
        - Emergency blood request guidance

        IMPORTANT LANGUAGE RULES:
        - If user writes in Bangla (বাংলা), respond in Bangla
        - If user writes in Banglish (e.g. "ami donorki hote pari", "kivabe register korbo"), respond in Bangla (translate the Banglish query to proper Bangla script)
        - If user writes in English, respond in English
        - If user mixes languages, respond in Bangla if any Bangla/Banglish is present, otherwise English
        - Be warm, supportive, and concise
        - Always mention that you are an AI assistant, not a doctor
        - For medical questions, advise consulting a doctor
        - For platform-specific questions, guide them to the relevant feature
        - Keep responses under 150 words for readability
        - Use simple, easy-to-understand language
        - Never give specific medical diagnoses
        """;

    public GroqChatService(
        HttpClient httpClient,
        IOptions<GroqOptions> options,
        ILogger<GroqChatService> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<string> ChatAsync(string message, List<ChatMessage>? history = null)
    {
        if (string.IsNullOrWhiteSpace(_options.ApiKey) || _options.ApiKey == "YOUR_GROQ_API_KEY")
        {
            _logger.LogWarning("Groq API key is not configured. Set GroqApi__ApiKey environment variable.");
            return "AI assistant is not configured yet. / AI সহকারী এখনো কনফিগার করা হয়নি।";
        }

        try
        {
            _logger.LogInformation("Calling Groq API with model {Model}", _options.Model);
            var client = _httpClient;

            var messages = new List<object>
            {
                new { role = "system", content = SystemPrompt }
            };

            if (history != null)
            {
                foreach (var msg in history)
                {
                    var rawRole = msg.Role?.ToLowerInvariant();
                    if (rawRole == "system") continue;
                    var role = rawRole == "assistant" ? "assistant" : "user";
                    messages.Add(new { role, content = msg.Content });
                }
            }

            messages.Add(new { role = "user", content = message });

            var requestBody = new
            {
                model = _options.Model,
                messages = messages.ToArray(),
                max_tokens = _options.MaxTokens,
                temperature = _options.Temperature
            };

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_options.BaseUrl}/chat/completions");
            request.Headers.Add("Authorization", $"Bearer {_options.ApiKey}");
            request.Content = JsonContent.Create(requestBody);

            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var truncatedError = responseString.Length > 200 ? responseString.Substring(0, 200) + "...[truncated]" : responseString;
                _logger.LogError("Groq API returned {StatusCode}: {Response}", response.StatusCode, truncatedError);
                return "Sorry, I'm having trouble connecting right now. Please try again later. / দুঃখিত, আমি এখন সংযোগ করতে সমস্যা হচ্ছে। পরে আবার চেষ্টা করুন।";
            }

            using var doc = JsonDocument.Parse(responseString);
            var root = doc.RootElement;

            if (root.TryGetProperty("choices", out var choices) && choices.GetArrayLength() > 0)
            {
                var firstChoice = choices[0];
                if (firstChoice.TryGetProperty("message", out var msgObj) &&
                    msgObj.TryGetProperty("content", out var contentElement))
                {
                    return contentElement.GetString() ?? string.Empty;
                }
            }

            var truncatedResponse = responseString.Length > 200 ? responseString.Substring(0, 200) + "...[truncated]" : responseString;
            _logger.LogWarning("Unexpected Groq API response structure: {Response}", truncatedResponse);
            return "Sorry, I couldn't understand the response. Please try again. / দুঃখিত, আমি উত্তরটি বুঝতে পারিনি। আবার চেষ্টা করুন।";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calling Groq API");
            return "Sorry, something went wrong. Please try again later. / দুঃখিত, কিছু ভুল হয়েছে। পরে আবার চেষ্টা করুন।";
        }
    }
}
