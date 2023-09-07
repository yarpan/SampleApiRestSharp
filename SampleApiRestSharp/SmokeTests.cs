using APIDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Runtime.InteropServices;
using RestSharp;
using System.Diagnostics;

namespace SampleApiRestSharp
{
    [TestFixture]
    internal class SmokeTests
    {


        [Test]
        public void TestMethod1()
        {
            var demo = new Demo();
            var response = demo.GetUsers();
            //Assert.IsNotNull(response);
            //Assert.AreEqual(2, response.code);
            Assert.AreEqual(2, response.page);
            Assert.AreEqual("Michael", response.data[0].first_name);



        }


        [Test]
        public void TestMethod2()
        {
            string url = "https://reqres.in/api/users";

            var client = new RestClient(url);

            var request = new RestRequest();
            request.AddParameter("page", "2");

            var response = client.Get(request);

            Console.WriteLine(response.Content.ToString());

            //Console.Read();



        }

        [Test]
        public void TestMethod3() {
            string url = "http://localhost:9966/petclinic/api/owners";
            var client = new RestClient(url);
            var request = new RestRequest();

            String bodySimple = "{\r\n  \"firstName\" : \"Nicolle\",\r\n  \"lastName\" : \"Stark\",\r\n  \"address\" : \"56173 Becker Gateway\",\r\n  \"city\" : \"East Mackshire\",\r\n  \"telephone\" : \"485781923\"\r\n}";
            var body = new PostBody { address = "no address", firstName = "Leonardo", lastName = "Pendo", city = "Orlando", telephone = "1234567890" };

            request.AddJsonBody(body);

            var response = client.Post(request);

            Console.WriteLine(response.StatusCode.ToString() + "                " + response.Content.ToString());






        }

        [Test]
        public void TestMethod4()

        {
            Console.WriteLine("Console.WriteLine");;
            Debug.WriteLine("Debug.WriteLine");}
    }
}