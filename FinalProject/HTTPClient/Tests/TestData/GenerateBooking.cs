using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTTPClient.DataModels;

namespace HTTPClient.Tests.TestData
{
    public class GenerateBooking
    {
        public static BookingJSONModel bookingDetails()
        {
            DateTime dt= DateTime.UtcNow.Date;

            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(1);


            return new BookingJSONModel
            {
                Firstname = "Boom",
                Lastname = "Esports",
                Totalprice = 200,
                Depositpaid = true,
                Bookingdates = bookingDates,
                Additionalneeds = "Breakfast"
            };
        }
    }
}
