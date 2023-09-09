using RestSharp;

namespace SampleApiRestSharp
{
    internal class OwnerController
    {

        public OwnerDto PostRequest(OwnerDto body)
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners);
            request.AddJsonBody(body);
            return client.Post<OwnerDto>(request);
        }


        public OwnerDto GetByIdRequest(int id) 
        {
            var client = new RestClient(Endpoints.BaseUri);
            var request = new RestRequest(Endpoints.EndpointOwners + "/{username}");
            request.AddUrlSegment("username", id);
            return client.Get<OwnerDto>(request);
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






    }
}
