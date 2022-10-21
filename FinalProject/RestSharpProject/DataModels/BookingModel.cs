using Newtonsoft.Json;
using RestSharp;

namespace RestSharpProject.DataModels
{
    public class BookingModel
    {
        [JsonProperty("bookingid")]
        public int BookingId { get; set; }

        [JsonProperty("booking")]
        public BookingJSONModel Booking { get; set; }
    }
}
