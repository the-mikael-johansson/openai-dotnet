namespace Johansson.OpenAI;

public class OpenAi
{
    public Completions Completions { get; set; }
    private readonly OpenAIConfiguration _configuration;
    private HttpClient _httpClient;

    public OpenAi(string baseUrl, string apiKey)
    {
        _configuration = new OpenAIConfiguration
        {
            ApiBaseUrl = baseUrl,
            ApiKey = apiKey
        };
        SetHttpClient();

        Completions = new Completions(_configuration, _httpClient);
    }

    public OpenAi(OpenAIConfiguration configuration)
    {
        _configuration = configuration;
        SetHttpClient();
    }

    private void SetHttpClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("api-key", _configuration.ApiKey);
    }
}
