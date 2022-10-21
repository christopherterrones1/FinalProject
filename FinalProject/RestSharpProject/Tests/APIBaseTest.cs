using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.Tests
{
    public class APIBaseTest
    {
        public RestClient RestClient { get; set; }

        public BookingModel BookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }
    }
}
