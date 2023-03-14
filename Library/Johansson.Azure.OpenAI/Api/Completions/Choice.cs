using Newtonsoft.Json;

namespace Johansson.OpenAI.Api.Completions;

public class Choice
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
    [JsonProperty("logprobs")]
    public object LogProbs { get; set; }
}
