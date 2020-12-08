using ProductsService.Tests;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public async Task GetEmptyId_Returns_NotFound()
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
        [Fact]
        public async Task CreateProduct_Returns_CreatedProductId()
        {
            using (var client = new TestClientProvider().Client)
            {

                var payload = JsonSerializer.Serialize(new Product.Service.Models.Product()

                {
                    Name = "Testprodukt",
                    Quantity = 1,
                    Price = 15,
                    ImageUrl = "https://www.medistore.se/PICTURE/test_produkt.png",
                    Description = "Detta är en testprodukt"
                }
                    );

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/product/createproduct", content);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var product = await JsonSerializer.DeserializeAsync<Product.Service.Models.Product>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    Assert.NotNull(product);
                    Assert.NotEqual(0, product.Id);
                }
            }
        }
    }
}
