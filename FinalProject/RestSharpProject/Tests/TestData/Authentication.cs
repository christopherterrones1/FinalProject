using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpProject.DataModels;

namespace RestSharpProject.Tests.TestData
{
    public class Authentication
    {
        public static UserTokenModel userTokenDetails()
        {
            return new UserTokenModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
