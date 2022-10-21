using Newtonsoft.Json;

namespace RestSharpProject.DataModels
{
    public class UserTokenModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    
}
