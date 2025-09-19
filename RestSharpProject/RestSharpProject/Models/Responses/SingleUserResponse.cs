using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharpProject.Models.Responses
{


    public class SingleUserResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
    }

}
