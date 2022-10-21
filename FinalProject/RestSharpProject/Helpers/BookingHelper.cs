using Newtonsoft.Json;
using RestSharp;
using RestSharpProject.DataModels;
using RestSharpProject.Resources;
using RestSharpProject.Tests.TestData;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Helpers
{
    public class BookingHelper
    {
        public static async Task<RestResponse<BookingModel>> AddNewBooking(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.BaseBookingMethod).AddJsonBody(GenerateBooking.bookingDetails());

            return await restClient.ExecutePostAsync<BookingModel>(postRequest);

        }

        public static async Task<RestResponse<BookingJSONModel>> GetBookingById(RestClient restClient, int bookingId)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.ExecuteGetAsync<BookingJSONModel>(getRequest);
        }

        public static async Task<RestResponse> DeleteBookingById(RestClient restClient, int bookingId)
        {
            var token = await GetAuthToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.DeleteAsync(getRequest);
        }

        public static async Task<RestResponse<BookingJSONModel>> UpdateBookingById(RestClient restClient, BookingJSONModel booking, int bookingId)
        {
            var token = await GetAuthToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var putRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId)).AddJsonBody(booking);

            return await restClient.ExecutePutAsync<BookingJSONModel>(putRequest);
        }

            private static async Task<string> GetAuthToken(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.GenerateToken).AddJsonBody(Authentication.userTokenDetails());

            var generateToken = await restClient.ExecutePostAsync<TokenModel>(postRequest);

            return generateToken.Data.Token;
        }
    }
}
