using Academy.Week4.Test.APIClient.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week4.Test.APIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            #region GET

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44325/api/order")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrderContract>>(data);

            }

            #endregion

            #region GET BY ID

            Console.Write("ID: ");

            string idGet = Console.ReadLine();
            HttpRequestMessage getByIDRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:44325/api/order/{idGet}")
            };

            HttpResponseMessage getByIDResponse = await client.SendAsync(getByIDRequest);

            if (getByIDResponse.IsSuccessStatusCode)
            {
                string data = await getByIDResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderContract>(data);

            }

            #endregion

            #region PUT

            Console.Write("ID (PUT): ");
            string id = Console.ReadLine();

            HttpRequestMessage putRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:44325/api/order/{id}")
            };

            int.TryParse(id, out int idVal);
            OrderContract updatedOrder = new OrderContract
            {
                ID = 1,
                OrderDate = DateTime.Today,
                OrderCode = "OC-1234",
                ProductCode = "P-1234",
                Amount = 10
            };

            string updatedEmpJson = JsonConvert.SerializeObject(updatedOrder);
            putRequest.Content = new StringContent(
                updatedEmpJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage putResponse = await client.SendAsync(putRequest);

            if (putResponse.IsSuccessStatusCode)
            {
                string data = await putResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderContract>(data);
            }

            #endregion

            #region DELETE

            Console.Write("ID (DELETE): ");
            string idDel = Console.ReadLine();

            HttpRequestMessage deleteRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:44325/api/order/{idDel}")
            };

            HttpResponseMessage deleteResponse = await client.SendAsync(deleteRequest);

            if (deleteResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Order Successfully deleted.");
            }

            #endregion
        }
    }
}
