using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartLibrary
{
    public class ShoppingCart
    {
        private readonly HttpClient _client;
        public ShoppingCart()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/api/ShoppingCart/")
            };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ShoppingItem>> GetAllItems()
        {
            HttpResponseMessage response = await _client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ShoppingItem>>(jsonString);
            }
            else
            {
                throw new HttpRequestException("Request is not success");
            }
        }

        public async Task AddItem(ShoppingItem item)
        {            
            HttpResponseMessage response = await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)                       
            {
                throw new HttpRequestException("Request is not success");
            }
        }

        public async Task RemoveItem(Guid guid)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{guid.ToString()}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Request is not success");
            }
        }

        public async Task ChangeQuantity(Guid guid, int quantity)
        {
            HttpResponseMessage response = await _client.PutAsync($"{guid.ToString()}/{quantity}", new StringContent(""));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Request is not success");
            }
        }

        public async Task Clear()
        {
            HttpResponseMessage response = await _client.GetAsync("Clear");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Request is not success");
            }
        }
    }
}
