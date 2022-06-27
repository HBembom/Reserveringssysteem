using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReservationSystem.Core.Model;

namespace ReservationSystem.Core.Clients
{
    public class PriceModel
    {
        public int PriceId { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public bool IsTax { get; set; }

    }
    public class PricesClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Price> GetByName(string name)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Prices/" + name);
            var price = JsonConvert.DeserializeObject<Price>(res);
            return price;
        }

        public async Task<List<PriceModel>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Prices");
            var prices = JsonConvert.DeserializeObject<List<PriceModel>>(res);
            return prices;
        }

        public async Task Post(PriceModel priceModel)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Prices/", priceModel);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(string name, Price price)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Prices/" + name, price);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(string name)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Prices/" + name);
            res.EnsureSuccessStatusCode();
        }
    }
}
