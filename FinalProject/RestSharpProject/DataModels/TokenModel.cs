using Newtonsoft.Json;

namespace RestSharpProject.DataModels
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
