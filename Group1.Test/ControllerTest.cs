using ProductsService.Tests;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Products.Service.Tests
{
    public class ControllerTest
    {
        [Fact]
        public async Task GetAllProducts_Succeed()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product/getall");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        [Fact]
        public async Task GetEmptyId_Returns_NOTFOUND()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync($"/api/product/getone");
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
        }
        [Fact]
        public async Task GetProductById_Returns_ProductId()
        {
            using (var client = new TestClientProvider().Client)
            {
                var productsResponse = await client.GetAsync($"/api/product/getone?id=1");

                using (var responseStream = await productsResponse.Content.ReadAsStreamAsync())
                {
                    var product = await System.Text.Json.JsonSerializer.DeserializeAsync<Product.Service.Models.Product>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    Assert.Equal(1, product.Id);
                }
            }
        }

    }
}
