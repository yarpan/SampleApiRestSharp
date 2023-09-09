using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;
using NUnit.Framework;

namespace SampleApiRestSharp
{
    [TestFixture]
    internal class GitHubTest
    {

        [Test]
        public void testCase01()
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("users/{username}", Method.Get);
            request.AddUrlSegment("username", "yarpan");

            request.AddHeader("authority", "api.github.com");

            var response = client.Execute<GitHubUser>(request);
            Console.WriteLine($"Status: {response.StatusCode}");
            Assert.IsTrue(response.IsSuccessful);

                var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(response.Content, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                    //CamelCaseNamingStrategy()
                    //SnakeCaseNamingStrategy()
                }
            });
            Console.WriteLine("gitHubUser = " + gitHubUser);
            Console.WriteLine("user = " + gitHubUser.Email);
        }


        [Test]
        public void testCase02()
        {
            var client = new RestClient("https://api.github.com");

            var request = new RestRequest("users/{username}", Method.Get);
            request.AddUrlSegment("username", "executeautomation");

            request.AddHeader("authority", "api.github.com");

            request.RequestFormat = DataFormat.Json;
            //request.AddBody(obj);



            var response = client.Execute<GitHubUser>(request);
            Console.WriteLine($"Status: {response.StatusCode}");

            var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(response.Content, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                    //SnakeCaseNamingStrategy()
                }
            }); ;
        }


    }
}
