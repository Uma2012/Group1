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
            var postJson = JsonSerializer.Serialize(obj);
            request.Content = new StringContent(postJson, Encoding.UTF8, "application/json");

            // Send and receive request
            var result = await _client.SendAsync(request);
            var responseString = await result.Content.ReadAsStreamAsync();            

        }

        private HttpRequestMessage SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add(ACCEPT_HEADER, ACCEPT_VALUE);
            request.Headers.Add(USER_AGENT_HEADER, USER_AGENT_VALUE);
            return request;
        }
    }
}
