using Newtonsoft.Json;

namespace Johansson.OpenAI.Api.Completions;

public class CompletionsRequest
{
    [JsonProperty("prompt")]
    public string Prompt { get; set; }

    [JsonProperty("max_tokens")] 
    public int MaxTokens { get; set; } = 600;

    public CompletionsRequest(string prompt)
    {
        Prompt = prompt;
    }
}
