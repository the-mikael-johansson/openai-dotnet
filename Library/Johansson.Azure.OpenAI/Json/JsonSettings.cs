using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Johansson.OpenAI.Json;

public static class JsonSettings
{
    public static JsonSerializerSettings CreateLowerCaseSettings()
    {
        return new JsonSerializerSettings
        {
            ContractResolver = new LowercaseContractResolver()
        };
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}