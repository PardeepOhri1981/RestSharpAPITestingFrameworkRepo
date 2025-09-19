
using RestSharp;
using RestSharpProject.Auth;
using Newtonsoft.Json;
namespace RestSharpProject
{
    public class APIClient : IAPIClient , IDisposable

    {
        private readonly RestClient _client;
         readonly string? clientId;
        readonly string? clientSecret;
        private readonly string baseUrl;    
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this); 
            // Dispose of unmanaged resources if any
        }   

 /*        public APIClient(string baseUrl, string clientId, string clientSecret)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            this.clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));  
            this.clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            var options = new RestClientOptions(baseUrl)
            {
                Authenticator = new APIAuthenticator(baseUrl, clientId, clientSecret)
            };
            _client = new RestClient(options);
        } */
         public APIClient(string baseUrl)
        {
            this.baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            var options = new RestClientOptions(baseUrl);
            _client = new RestClient(options);
        }
        public async Task<RestResponse> CreateUser<T>(T payload) where T : class
        {
            var request = new RestRequest(EndPoints.CREATE_USER, Method.Post);
            request.AddJsonBody(payload);
            Console.Out.WriteLine("Request Body: " + JsonConvert.SerializeObject(payload));
    
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> UpdateUser<T>(T payload, string id) where T : class
        {
            var request = new RestRequest(EndPoints.UPDATE_USER.Replace("{id}", id), Method.Put);
            request.AddJsonBody(payload);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> DeleteUser(string id)
        {
            var request = new RestRequest(EndPoints.DELETE_USER.Replace("{id}", id), Method.Delete);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUser(string id)
        {
            var request = new RestRequest(EndPoints.GET_USER.Replace("{id}", id), Method.Get);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetListUsers()
        {
            var request = new RestRequest(EndPoints.GET_LIST_USERS, Method.Get);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUsers(int[] ids)
        {
            var idsParam = string.Join(",", ids);
            var request = new RestRequest(EndPoints.GET_USERS.Replace("{ids}", idsParam), Method.Get);
            return await _client.ExecuteAsync(request);
        }
    }

}