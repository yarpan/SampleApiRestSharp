using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApiRestSharp
{
    [TestFixture]
    internal class SpecTest
    {
        [Test]
        public void testCase01()
        {

        }


        [Test]
        public void ContentTypeTest()
        {
            // arrange

            var request = new RestRequest();
            request.AddParameter("page", "2");
            request.AddParameter("status", 1);
            request.AddParameter("ids", "123,456");

            var client = new RestClient("https://api.github.com");
            var request2 = new RestRequest("users/{username}", Method.Get);
            request2.AddUrlSegment("username", "Belmondo");

            //var token = JObject.Parse(authResponse.Content)["token"];
            //productGetRequest.AddHeader("Authorization", $"Bearer {token}");

            //request.AddHeader(string name, string value);
            //request.AddHeader<T>(string name, T value);           // value will be converted to string
            //request.AddOrUpdateHeader(string name, string value); // replaces the header if it already exists

            //client.AddDefaultParameter("foo", "bar");
            //client.AddDefaultHeader(string name, string value);

            RestResponse response = null;
            // act

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            //Assert.AreEqual("Michael", response.data[0].first_name);
        }























    }
}
