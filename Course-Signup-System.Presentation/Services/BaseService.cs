using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Course_Signup_System.Presentation.Services
{
    public class BaseService
    {
        protected static string SerializeObj(object modelObj) => JsonSerializer.Serialize(modelObj,JsonOptions());
        protected static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        protected static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        protected static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        protected static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
        protected readonly HttpClient _httpClient;
        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

    }
}
