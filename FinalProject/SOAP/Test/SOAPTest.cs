using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceReference1;
using System.Diagnostics;
using System.Reflection;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace SOAP.Test
{
    [TestClass]
    public class SOAPTest
    {

        private static CountryInfoServiceSoapTypeClient infoServiceSoapClient = null;

        [TestInitialize]
        public void TestInit()
        {
            infoServiceSoapClient = new CountryInfoServiceSoapTypeClient(CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var countryList = CountryList();
            var randomCountryRecord = RandomCountryCode(countryList);

            var randomCountryFullDetails = infoServiceSoapClient.FullCountryInfo(randomCountryRecord.sISOCode);

            Assert.AreEqual(randomCountryRecord.sISOCode, randomCountryFullDetails.sISOCode);
            Assert.AreEqual(randomCountryRecord.sName, randomCountryFullDetails.sName);
        }

        [TestMethod]

        public void TestMethod2()
        {
            var countryList = CountryList();
            List<tCountryCodeAndName> fiveRandomCountry = new List<tCountryCodeAndName>();

            for (int x = 0; x < 5; x++) { 
                fiveRandomCountry.Add(RandomCountryCode(countryList));
            }

            foreach (var country in fiveRandomCountry) {
                var countryISOCode = infoServiceSoapClient.CountryISOCode(country.sName);

                Assert.AreEqual(country.sISOCode, countryISOCode);
            }
     
        }

        private List<tCountryCodeAndName> CountryList()
        {
            var countryList = infoServiceSoapClient.ListOfCountryNamesByCode();

            return countryList;
        }

        private static tCountryCodeAndName RandomCountryCode(List<tCountryCodeAndName> countryList)
        {
            Random random = new Random();
            int countryListMaxCount = countryList.Count - 1;
            int randomNum = random.Next(0, countryListMaxCount);
            var randomCountryCode = countryList[randomNum];

            return randomCountryCode;
        }
    }
}