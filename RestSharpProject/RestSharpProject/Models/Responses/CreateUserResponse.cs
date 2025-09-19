
namespace RestSharpProject.Models.Responses
{

 public class CreateUserResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
        public DateTime createdAt { get; set; }
    }
}