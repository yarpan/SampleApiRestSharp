using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;


namespace SampleApiRestSharp
{
    public class JsonBodyTests
    {

        [Test]
        public void PostBodyStringTest()
        {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            const string Payload = @"{
                    ""firstName"": ""Nicolle"",
                    ""lastName"": ""Stark"",
                    ""address"": ""56173 Becker Gateway"",
                    ""city"": ""East Mackshire"",
                    ""telephone"": ""485781923""
                }";
            request.AddJsonBody(Payload);  

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "\n" + response.Content.ToString());

            dynamic data = JObject.Parse(response.Content);
            Console.WriteLine("firstName: " + data.firstName);
            Console.WriteLine("lastName: " + data.lastName);
            Console.WriteLine("address: " + data.address);
        }


        [Test] 
        public void PostBodyLiteralsTest()   
        {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

             //'raw strings literals' for C# 7.3 language version 11.0
             var payload = $$"""
                                 {
                                     "firstName": "Nicolle",
                                     "lastName": "Stark",
                                     "address": "56173 Becker Gateway",
                                     "city": "East Mackshire",
                                     "telephone": "485781923"
                                 }
                             """;

            request.AddJsonBody(payload);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "\n" + response.Content.ToString());
        }


    }
}
