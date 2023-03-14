namespace Johansson.OpenAI;

public class OpenAIConfiguration
{
    public string ApiKey { get; set; }
    public string ApiBaseUrl { get; set; }
    public string Type { get; set; } = "Azure";
    public string Version { get; set; } = "2022-12-01";
}
