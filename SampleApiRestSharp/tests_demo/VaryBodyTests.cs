using NUnit.Framework;
using RestSharp;
using System;


namespace SampleApiRestSharp
{
    public class VaryBodyTests
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
        }


        [Test] public void PostBodyLiteralsTest()   
        {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            // 'raw strings literals' for C# 7.3 language version 11.0
            // var payload = $$"""
            //                     {
            //                         "firstName": "Nicolle",
            //                         "lastName": "Stark",
            //                         "address": "56173 Becker Gateway",
            //                         "city": "East Mackshire",
            //                         "telephone": "485781923"
            //                     }
            //                 """;

            string payload = "{\r\n    \"firstName\": \"Nicolle\",\r\n    \"lastName\": \"Stark\",\r\n    \"address\": \"56173 Becker Gateway\",\r\n    \"city\": \"East Mackshire\",\r\n    \"telephone\": \"485781923\"\r\n}";

            request.AddJsonBody(payload);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "\n" + response.Content.ToString());

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

            Console.WriteLine(response.StatusCode.ToString() + "\n" + response.Content.ToString());
        }













    }
}
