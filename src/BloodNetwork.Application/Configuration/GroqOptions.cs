namespace BloodNetwork.Application.Configuration;

public class GroqOptions
{
    public const string SectionName = "GroqApi";
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = "https://api.groq.com/openai/v1";
    public string Model { get; set; } = "llama-3.3-70b-versatile";
    public int MaxTokens { get; set; } = 1024;
    public double Temperature { get; set; } = 0.7;
}
