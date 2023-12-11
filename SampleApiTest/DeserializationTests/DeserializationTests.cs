using NUnit.Framework;
using RestSharp;

namespace SampleApiTest.DeserializationTests
{
    [TestFixture]
    public class DeserializationTests
    {
        [Test]
        public void CountrySerializationTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/12345", Method.Get);

            // act
            //RestResponse response = client.Execute(request);
            //LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(response);
            var response = client.Get<LocationDTO>(request);

            // assert
            Assert.That(response.Country, Is.EqualTo("United States"));
        }


        [Test]
        public void StateSerializationTest()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("us/12345", Method.Get);

            // act
            //RestResponse response = client.Execute(request);
            //LocationResponse locationResponse = new JsonDeserializer().Deserialize<LocationResponse>(response);
            var response = client.Get<LocationDTO>(request);

            // assert
            Assert.That(response.Places[0].State, Is.EqualTo("New York"));
        }
    }
}