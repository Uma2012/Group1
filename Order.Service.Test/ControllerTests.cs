using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Order.Service.Test
{
    public class ControllerTests
    {
        [Fact]
        public async Task CreateOrder_Returns_CreatedOrder()
        {
            using (var client = new TestClientProvider().Client)
            {

                var payload = JsonSerializer.Serialize(new Models.Order()
                {
                    Id = 1,
                    UserId = 1,
                    DeliveryId = 1,
                    OrderDate = DateTime.Now,
                    PaymentId = 1,
                    Deliverd = false
                }
                    );

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/order/CreateOrder", content);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var order = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    //Assert.NotNull(order);
                    //Assert.NotEqual(0, order.Id);
                    //response.EnsureSuccessStatusCode();

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                }

            }
        }

        [Fact]
        public async Task CreateOrder_Returns_BadRequest()
        {
            using (var client = new TestClientProvider().Client)
            {

                var payload = JsonSerializer.Serialize(new Models.Order()
                { }
                );

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/order/createorder", content);

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


            }
        }

        [Fact]
        public async Task DeleteOrder_Returns_Notfound()
        {
            using (var client = new TestClientProvider().Client)
            {
                var payload = JsonSerializer.Serialize(new Models.Order());

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.DeleteAsync($"/api/order/deleteorder?id={0}");

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            }
        }

        [Fact]
        public async Task DeleteOrder_Returns_Deleted_Id()
        {
            using (var client = new TestClientProvider().Client)
            {

                var payload = JsonSerializer.Serialize(new Models.Order());

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/order/createorder", content);
                Models.Order order = null;
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    order = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


                }
                var deleteResponse = await client.DeleteAsync($"/api/order/deleteorder?id={order.Id}");
                using (var responseStream = await deleteResponse.Content.ReadAsStreamAsync())
                {
                    var deletedId = await JsonSerializer.DeserializeAsync<int>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    Assert.Equal(order.Id, deletedId);
                }
            }

        }


    }
}
