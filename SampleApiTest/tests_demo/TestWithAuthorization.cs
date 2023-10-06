using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SampleApiRestSharp.tests
{
    public class TestWithAuthorization
    {
        const string baseUri = "http://localhost:5001";
        const string endpointAuth = "/api/Authenticate/Login";
        const string endpointGetProductById = "/Product/GetProductById/";


        [Test]
        public void Test1()
        {
            //RestClient
            var restClient = new RestClient(new RestClientOptions
            { BaseUrl = new Uri(baseUri) });

            //POST the Authentication
            var authRequest = new RestRequest(endpointAuth);
            var authBody = $$"""
                                {
                                "username": "user1",
                                "password": "password1"
                                }
                             """;
            authRequest.AddStringBody(authBody, DataFormat.Json);
            var authResponse = restClient.Post(authRequest);

            //Deserialize the token
            var token = JObject.Parse(authResponse.Content)["token"];

            //Place the token to the header
            //Perform GET of the product

            var productGetRequest = new RestRequest(endpointGetProductById + "1");
            productGetRequest.AddHeader("Authorization", $"Bearer {token}");

            var productResponse = restClient.Get(productGetRequest);
            
            Console.WriteLine("Product ID: " + JObject.Parse(productResponse.Content)["ProductId"]);
            Console.WriteLine("Product name: " + JObject.Parse(productResponse.Content)["Name"]);
            Console.WriteLine("Product price:" + JObject.Parse(productResponse.Content)["Price"]);
        }
    }
}