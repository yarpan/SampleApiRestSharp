using Newtonsoft.Json;
using RestSharp;


namespace SampleApiRestSharp
{
    public class BaseController
    {

        public T ConvertResponseToDto<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
            //alternate serializer
            //return System.Text.Json.JsonSerializer.Deserialize<T>(response.Content);
        }

        public string SerializeJsonString(dynamic content)
        {
            return JsonConvert.SerializeObject(content, Formatting.Indented);
        }

        public void ConvertResponseToDtoOwner(RestResponse response)
        {
            var customerDto = JsonConvert.DeserializeObject<OwnerDto>(response.Content);
            var customer = System.Text.Json.JsonSerializer.Deserialize<OwnerDto>(response.Content);
        }


    }
}
