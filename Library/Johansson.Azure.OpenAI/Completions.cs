using Johansson.OpenAI.Api.Completions;
using Johansson.OpenAI.Json;
using Newtonsoft.Json;
using System.Text;

namespace Johansson.OpenAI;

public class Completions
{
    private readonly OpenAIConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public Completions(OpenAIConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<CompletionsResponse> GenerateAsync(string deploymentName, string prompt)
    {
        var setting = JsonSettings.CreateLowerCaseSettings();
        var completion = new CompletionsRequest(prompt);
        var httpContent = new StringContent(
            JsonConvert.SerializeObject(completion, setting),
            Encoding.UTF8,
            "application/json");

        try
        {
            var url = CreateUrl(deploymentName);
            var response = await _httpClient.PostAsync(url, httpContent);
            var contentString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new OpenAIException(contentString);
            }

            return JsonConvert.DeserializeObject<CompletionsResponse>(contentString, setting)
                   ?? throw new OpenAIException($"Failed to deserialize response: {contentString}");
        }
        catch (Exception e)
        {
            throw new OpenAIException(e.Message);
        }
    }

    private string CreateUrl(string deploymentName)
    {
        var baseUrl = _configuration.ApiBaseUrl.TrimEnd('/');
        return $"{baseUrl}/openai/deployments/{deploymentName}/completions?api-version=2022-12-01";
    }
}
