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

                var payload = JsonSerializer.Serialize(new Models.Order()
                {                  
                    UserId = 1,
                    DeliveryId = 1,
                    OrderDate = DateTime.Now,
                    PaymentId = 1,
                    Deliverd = false,
                    TotalPrice=200                    
                    
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
                    createdorderId = order.Id;

                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                }

                var payload1 = JsonSerializer.Serialize(new List<Models.OrderItem>()

                { 
                    new Models.OrderItem() {OrderId=createdorderId,ProductId=1,Quantity=2 },
                    new Models.OrderItem() {OrderId=createdorderId,ProductId=2,Quantity=1 }

                }
                );
                HttpContent content1 = new StringContent(payload1, Encoding.UTF8, "application/json");

                var response1 = await client.PostAsync($"/api/order/CreateOrderItem", content1);

                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var orderItem = await JsonSerializer.DeserializeAsync<Models.Order>(responseStream,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });                  
                    

                    Assert.Equal(HttpStatusCode.OK, response1.StatusCode);

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
