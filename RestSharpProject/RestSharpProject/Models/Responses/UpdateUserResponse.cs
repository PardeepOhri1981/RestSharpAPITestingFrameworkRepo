
namespace RestSharpProject.Models.Responses
{

    public class UpdateUserResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
        public DateTime updatedAt { get; set; }
    }
}