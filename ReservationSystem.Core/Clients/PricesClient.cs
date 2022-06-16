using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Price
    {
        public int PriceId { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool IsTax { get; set; }

    }
    public class PricesClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Price> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Prices/" + id);
            var price = JsonConvert.DeserializeObject<Price>(res);
            return price;
        }

        public async Task<List<Price>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Prices");
            var prices = JsonConvert.DeserializeObject<List<Price>>(res);
            return prices;
        }

        public async Task Post(Price price)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Prices/", price);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, Price price)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Prices/" + id, price);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Prices/" + id);
            res.EnsureSuccessStatusCode();
        }
    }
}
