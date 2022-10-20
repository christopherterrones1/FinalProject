using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClient.Resources
{
    public class Endpoints
    {
        //Base URL
        public const string baseURL = "https://restful-booker.herokuapp.com/";

        public const string UserEndpoint = "booking";

        public const string AuthEndpoint = "auth";

        public static string GetURL(string endpoint) => $"{baseURL}{endpoint}";

        public static Uri GetUri(string endpoint) => new Uri(GetURL(endpoint));

    }
}
