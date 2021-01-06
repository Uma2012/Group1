using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Group1.Web.Services
{
    public class CartServiceHandler
    {
        private readonly HttpClient _client;

        // Set headers and values
        const string ACCEPT_HEADER = "Accept";
        const string USER_AGENT_HEADER = "User-Agent";
        const string USER_AGENT_VALUE = "Group1";
        const string ACCEPT_VALUE = "application/json";

        public CartServiceHandler(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
        }
        public async Task PostAsync<T>(T obj, string webApiPath)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Post, webApiPath);
            request = SetHeaders(request);

            // Serialize object to JSON
            var serialized = JsonSerializer.Serialize(obj);
            request.Content = new StringContent(serialized, Encoding.UTF8, ACCEPT_VALUE);

            // Send and receive request
            var response = await _client.SendAsync(request);
            var responseString = await response.Content.ReadAsStreamAsync();            

        }

        private HttpRequestMessage SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add(ACCEPT_HEADER, ACCEPT_VALUE);
            request.Headers.Add(USER_AGENT_HEADER, USER_AGENT_VALUE);
            return request;
        }
    }
}
