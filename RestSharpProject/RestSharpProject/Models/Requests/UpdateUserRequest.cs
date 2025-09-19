
namespace RestSharpProject.Models.Requests
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
       public class UpdateUserRequest
    {
        public string name { get; set; }
        public Data data { get; set; }
    }



}