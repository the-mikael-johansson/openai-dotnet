using Johansson.OpenAI;

const string Prompt = "Please explain what 1337 means";

Console.WriteLine($"Asking {Prompt}");

var openAi = new OpenAi("https://<ENTER YOUR SERVICE NAME HERE>.openai.azure.com/", "<ENTER YOUR API KEY HERE>");
var response = await openAi.Completions.GenerateAsync(
    "<ENTER YOUR DEPLOYMENT NAME HERE>",
    Prompt);

Console.WriteLine($"Response: {response.FirstChoice()}");
