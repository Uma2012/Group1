using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Group1.Web.Services
{
    public class ProductServiceHandler
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductServiceHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

        }

        public async Task<List<T>> GetAllAsync<T>(string webApipath)
        {
            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, webApipath);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Group1");
           

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var products = await JsonSerializer.DeserializeAsync<List<T>>(responseStream,
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return products;
            }

            return null;

        }
    }
}
