
using Newtonsoft.Json;


namespace RestSharpProject.Models.Requests
{

    public class CreateUserRequest
    {
        public string name { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public int year { get; set; }
        public double price { get; set; }

        [JsonProperty("CPU model")]
        public string CPUmodel { get; set; }

        [JsonProperty("Hard disk size")]
        public string Harddisksize { get; set; }

        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("Capacity")]
        public string Capacity { get; set; }
    }
}
