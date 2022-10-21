using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharpProject.DataModels;
using RestSharpProject.Resources;
using RestSharpProject.Helpers;
using RestSharpProject.Tests.TestData;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace RestSharpProject.Tests
{
    [TestClass]
    public class BookingAssertion : APIBaseTest
    {

        [TestInitialize]
        public async Task TestInitialize()
        {
            #region create test data
            var restResponse = await BookingHelper.AddNewBooking(RestClient);
            BookingDetails = restResponse.Data;
            #endregion

            #region assert created data
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);
            #endregion
        }

        [TestMethod]
        public async Task CreateBooking()
        {
            #region get created data
            var getCreatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);
            #endregion

            #region assert pulled data
            var expectedData = GenerateBooking.bookingDetails();
            Assert.AreEqual(expectedData.Firstname, getCreatedBooking.Data.Firstname);
            Assert.AreEqual(expectedData.Lastname, getCreatedBooking.Data.Lastname);
            Assert.AreEqual(expectedData.Totalprice, getCreatedBooking.Data.Totalprice);
            Assert.AreEqual(expectedData.Depositpaid, getCreatedBooking.Data.Depositpaid);
            Assert.AreEqual(expectedData.Bookingdates.Checkin, getCreatedBooking.Data.Bookingdates.Checkin);
            Assert.AreEqual(expectedData.Bookingdates.Checkout, getCreatedBooking.Data.Bookingdates.Checkout);
            Assert.AreEqual(expectedData.Additionalneeds, getCreatedBooking.Data.Additionalneeds);
            #endregion

            #region cleanup data
            await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);
            #endregion
        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            #region get created data
            var getCreatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);
            #endregion

            #region update data
            var updatedData = new BookingJSONModel()
            {
                Firstname = "Team.put.updated",
                Lastname = "Spirit.put.updated",
                Totalprice = getCreatedBooking.Data.Totalprice,
                Depositpaid = getCreatedBooking.Data.Depositpaid,
                Bookingdates = getCreatedBooking.Data.Bookingdates,
                Additionalneeds = getCreatedBooking.Data.Additionalneeds
            };

            var updateBooking = await BookingHelper.UpdateBookingById(RestClient, updatedData, BookingDetails.BookingId);

            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);
            #endregion

            #region get updated data
            var getUpdatedBooking = await BookingHelper.GetBookingById(RestClient, BookingDetails.BookingId);
            #endregion

            #region assert pulled updated data
            Assert.AreEqual(updatedData.Firstname, getUpdatedBooking.Data.Firstname);
            Assert.AreEqual(updatedData.Lastname, getUpdatedBooking.Data.Lastname);
            Assert.AreEqual(updatedData.Totalprice, getUpdatedBooking.Data.Totalprice);
            Assert.AreEqual(updatedData.Depositpaid, getUpdatedBooking.Data.Depositpaid);
            Assert.AreEqual(updatedData.Bookingdates.Checkin, getUpdatedBooking.Data.Bookingdates.Checkin);
            Assert.AreEqual(updatedData.Bookingdates.Checkout, getUpdatedBooking.Data.Bookingdates.Checkout);
            Assert.AreEqual(updatedData.Additionalneeds, getUpdatedBooking.Data.Additionalneeds);
            #endregion

            #region cleanup data
            await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);
            #endregion
        }

        [TestMethod]
        public async Task DeleteBooking()
        {
            #region delete created data
            var deleteBooking = await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);
            #endregion

            #region assert if data was successfully deleted
            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);
            #endregion
        }

        [TestMethod]
        public async Task GetInvalidBookingId()
        {
            Random random = new Random();
            int randomNumber = random.Next(9000000, 999999999);

            #region get created data
            var getCreatedBooking = await BookingHelper.GetBookingById(RestClient, randomNumber);
            #endregion

            #region assert invalid data
            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);
            #endregion

            #region cleanup data
            await BookingHelper.DeleteBookingById(RestClient, BookingDetails.BookingId);
            #endregion
        }
    }
}
