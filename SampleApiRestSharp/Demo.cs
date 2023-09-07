using Newtonsoft.Json;
using RestSharp;
using APIDemo;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APIDemo
{
    public class Demo
    {

        public ListOfUsersDTO GetUsers() {

            var restClient = new RestClient("https://reqres.in//api/users?page=2");
            var restRequest = new RestRequest("", Method.Get);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            //.AddJsonBody(someObject);
            restRequest.RequestFormat = DataFormat.Json;


            RestResponse response = restClient.Execute(restRequest);
            var content = response.Content;
            //var response = await client.PostAsync<MyResponse>(request, cancellationToken);


            var users = JsonConvert.DeserializeObject<ListOfUsersDTO>(content);
            return users;

        }
        //  JsonConvert.DeserializeObject(String value, Type type, JsonSerializerSettings settings)
        //  JsonConvert.DeserializeObject[T] (String value, JsonSerializerSettings settings)



    }
}
