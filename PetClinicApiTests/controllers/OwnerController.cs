using Newtonsoft.Json;
using System.Text.Json;
using RestSharp;
using System;

namespace SampleApiRestSharp
{
    internal class OwnerController : BaseController
    {

        public RestResponse GetByIdRequest(int id)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners + "/{username}");
            request.AddUrlSegment("username", id);
            return client.Get(request);
        }


        public RestResponse PostRequest(OwnerDto body)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners);
            request.AddJsonBody(body);
            return client.Post(request);
        }


        public RestResponse PutByIdRequest(OwnerDto body, int id)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners + "/{username}");
            request.AddUrlSegment("username", id);
            request.AddJsonBody(body);
            return client.Put(request);
        }



        public RestResponse DeleteByIdRequest(int id)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners + "/{username}");
            request.AddUrlSegment("username", id);
            return client.Delete(request);
        }



        public OwnerDto GenerateRandomOwnerDto()
        {
            return new OwnerDto
            {
                address = Faker.Address.StreetAddress(),
                firstName = Faker.Name.First(),
                lastName = Faker.Name.Last(),
                city = Faker.Address.City(),
                telephone = Faker.Identification.UkNhsNumber()
            };
        }



        public RestResponse getListCustomHeaderRequest(String headerKey, String headerValue)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners);
            request.AddHeader(headerKey, headerValue);
            return client.Get(request);
        }





    }
}
