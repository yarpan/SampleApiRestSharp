using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;


namespace SampleApiRestSharp
{
    public class VaryBodyTests : BaseTests
    {

        [Test]
        public void PostBodyStringTest()
        {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            const string payload = @"{
                    ""firstName"": ""Nicolle"",
                    ""lastName"": ""Stark"",
                    ""address"": ""56173 Becker Gateway"",
                    ""city"": ""East Mackshire"",
                    ""telephone"": ""485781923""
                }";
            request.AddJsonBody(payload);  

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "                " + response.Content.ToString());

        }


        [Test] public void PostBodyLiteralsTest()   // 'raw strings literals' for C# 7.3 language version 11.0
        {
            //POST the Authentication
            var authRequest = new RestRequest("/api/Authenticate/Login");
            //var jsonBody = $$"""
            //                     {
            //                         "firstName": "Nicolle",
            //                         "lastName": "Stark",
            //                         "address": "56173 Becker Gateway",
            //                         "city": "East Mackshire",
            //                         "telephone": "485781923"
            //                     }
            //                 """;

        }



        [Test]
        public void PostBodyDtoTest()
        {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            var bodyDto = new OwnerDto { 
                address = "no address", 
                firstName = "Leonardo", 
                lastName = "Pendo", 
                city = "Orlando", 
                telephone = "1234567890" 
            };

            request.AddJsonBody(bodyDto);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "                " + response.Content.ToString());

            //var request = new RestRequest(resource, Method.Post);
        }













    }
}
