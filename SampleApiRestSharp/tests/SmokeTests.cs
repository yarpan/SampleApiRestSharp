using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SampleApiRestSharp
{
    [TestFixture]
    internal class SmokeTests : BaseTests
    {


        [Test]
        public void Test_01_Get()
        {
            string url = "http://localhost:9966/petclinic/api/owners";

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine(response.Content.ToString());

            



        }

        [Test]
        public void Test_02_Post() {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            var bodyDto = new OwnerDto { address = "no address", firstName = "Leonardo", lastName = "Pendo", city = "Orlando", telephone = "1234567890" };

            request.AddJsonBody(bodyDto);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "                " + response.Content.ToString());

            //var request = new RestRequest(resource, Method.Post);
        }



        [Test]
         public void Test1()
        {
            //RestClient
            //var restClient = new RestClient(new RestClientOptions
            //{ BaseUrl = new Uri("http://localhost:5001") });

            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            var bodyDto = new OwnerDto { address = "no address", firstName = "Leonardo", lastName = "Pendo", city = "Orlando", telephone = "1234567890" };
            request.AddJsonBody(bodyDto); //, DataFormat.Json);

            
            //var token = JObject.Parse(authResponse.Content)["token"];
            //var productGetRequest = new RestRequest("/Product/GetProductById/1");

            var authResponse = client.Post(request);
            var productResponse = client.Post<OwnerDto>(request);

            //Assertion with FluentAssertions
            //productResponse?.Name.Should().Be("Keyboard");


            Console.WriteLine("productResponse.Price - " + productResponse.firstName);
            Console.WriteLine("productResponse.Name - " + productResponse.lastName);
            Console.WriteLine("productResponse.ProductId - " + productResponse.telephone);
        }





        [Test]
        public void TestMethod5()
        {


        }


















    }
}