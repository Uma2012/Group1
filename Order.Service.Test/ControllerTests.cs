using System;
using System.Collections.Generic;
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
            int createdorderId = 0;
            using (var client = new TestClientProvider().Client)
            {
                var productList = new List<Models.Product>()
                { new Models.Product(){ Id=1,Quantity=2},
                  new Models.Product(){Id=3,Quantity=1}
                };             

                var payload2 = JsonSerializer.Serialize(new Models.Viewmodels.OrderViewModel()
                {
                    UserId = Guid.NewGuid(),
                    PaymentId = 1,
                    DeliveryMethodId = 1,
                    ProductList = productList

                }
                    );

                HttpContent content = new StringContent(payload2, Encoding.UTF8, "application/json");

               var response = await client.PostAsync($"/api/order/CreateOrder", content);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var order = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    //Assert.NotNull(order);
                    //Assert.NotEqual(0, order.Id);
                    //response.EnsureSuccessStatusCode();
                    createdorderId = order.Id;

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                }

            }
        }

        [Fact]
        public async Task CreateOrder_Returns_BadRequest()
        {
            using (var client = new TestClientProvider().Client)
            {

                var payload = JsonSerializer.Serialize(new Models.Viewmodels.OrderViewModel()
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
                var payload = JsonSerializer.Serialize(new Models.Viewmodels.OrderViewModel());

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/order/createorder", content);

                Models.Order order = null;

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    order = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                }
                var deleteResponse = await client.DeleteAsync($"/api/order/deleteorder?orderId={order.Id}");
                using (var responseStream = await deleteResponse.Content.ReadAsStreamAsync())
                {
                    var deletedId = await JsonSerializer.DeserializeAsync<int>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    Assert.Equal(order.Id, deletedId);
                }

            }
        }

        [Fact]
        public async Task DeleteOrder_Returns_Deleted_Id()
        {
            using (var client = new TestClientProvider().Client)
            {

                var productList = new List<Models.Product>()
                { new Models.Product(){ Id=1,Quantity=2},
                  new Models.Product(){Id=3,Quantity=1}
                };


                var payload = JsonSerializer.Serialize(new Models.Viewmodels.OrderViewModel()
                {
                    UserId = Guid.NewGuid(),
                    PaymentId = 2,
                    DeliveryMethodId = 2,
                    ProductList = productList
                }
                );               

                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"/api/order/createorder", content);

                Models.Order order = null;              

                    
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    order = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                          new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });                    

                }
                var deleteResponse = await client.DeleteAsync($"/api/order/deleteorder?orderId={order.Id}");
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
