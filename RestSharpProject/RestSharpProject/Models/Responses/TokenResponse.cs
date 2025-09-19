using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharpProject.Models.Responses
{

    public class TokenResponse { 
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
    }
}
