using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Group1.Web.Services
{
    public class ProductServiceHandler
    {
        private readonly HttpClient _client;

        // Set headers and values
        const string ACCEPT_HEADER = "Accept";
        const string USER_AGENT_HEADER = "User-Agent";
        const string USER_AGENT_VALUE = "Group1";
        const string ACCEPT_VALUE = "application/json";

        public ProductServiceHandler(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();

        }

        public async Task<List<T>> GetAllAsync<T>(string webServicePath)
        {         
            var request = new HttpRequestMessage(HttpMethod.Get, webServicePath);           

            request = SetHeaders(request);

            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {               
                return await DeserializeResponse<List<T>>(response);
            }

            return null;
        }

        public async Task<T> GetOneAsyn<T>(string webServicePath)where T:class
        {
            var request = new HttpRequestMessage(HttpMethod.Get, webServicePath);
            request = SetHeaders(request);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await DeserializeResponse<T>(response);
            }
            return null;
        }

        private HttpRequestMessage SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add(ACCEPT_HEADER, ACCEPT_VALUE);
            request.Headers.Add(USER_AGENT_HEADER, USER_AGENT_VALUE);
            return request;
        }

        public async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var deserializedResponse = await JsonSerializer.DeserializeAsync<T>(responseStream,
                      new JsonSerializerOptions() 
                      {
                       PropertyNameCaseInsensitive = true 
                      }
                    );
                return deserializedResponse;
            }              
           
        }


    }
}
