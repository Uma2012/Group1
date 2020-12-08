using ProductsService.Tests;
using System.Net;
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
        public async Task GetOneProductById_ReturnsProduct()
        {
            int Id = 1;
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/product/getbyid");
                response.EnsureSuccessStatusCode();
                Assert.Equal(Id, product.Id);
            }
        }
    }
}
