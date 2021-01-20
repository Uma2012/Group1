using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Group1.Web.Services
{
    public class OrderServiceHandler
    {
        private readonly HttpClient _client;

        // Set headers and values
        const string ACCEPT_HEADER = "Accept";
        const string USER_AGENT_HEADER = "User-Agent";
        const string USER_AGENT_VALUE = "Group1";
        const string ACCEPT_VALUE = "application/json";

        public OrderServiceHandler(IHttpClientFactory clientFactory)
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

        public async Task<T> GetOneAsync<T>(string webServicePath) where T : class
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

        public async Task PostAsync<T>(T obj, string webServicePath)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, webServicePath);
            request = SetHeaders(request);

            // Serialize object to JSON
            var serialized = JsonSerializer.Serialize(obj);
            request.Content = new StringContent(serialized, Encoding.UTF8, ACCEPT_VALUE);

            // Send and receive request
            var response = await _client.SendAsync(request);
            var responseString = await response.Content.ReadAsStreamAsync();

        }

        public async Task<T> DeleteOneAsync<T>(string webServicePath) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, webServicePath);
            request = SetHeaders(request);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await DeserializeResponse<T>(response);
            }
            return null;
        }

        public async Task UpdateDeliveryStatus<T>(T obj, string webServicepath)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, webServicepath);
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
