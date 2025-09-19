using RestSharp;
using RestSharp.Authenticators;
using RestSharpProject.Models.Responses;
namespace RestSharpProject.Auth
{
    public class APIAuthenticator : AuthenticatorBase

    {
        readonly string baseUrl;
        readonly string clientId;
        readonly string clientSecret;

        public APIAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            this.clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            this.clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        }
        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            // Implement your authentication logic here
            var token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, token);
            
        }

        private async Task<string> GetToken()
        {
            var authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
            var options = new RestClientOptions(baseUrl)
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            var request = new RestRequest("oauth2/token")
                .AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);
            return $"{response.TokenType} {response.AccessToken}";
        }
    }
}   