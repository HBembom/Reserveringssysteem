using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Profit
    {
        public double AmountOfProfit { get; set; }
        public int Period { get; set; }
    }
    public class ProfitsClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Profit> GetProfitFromPeriod(string startDate, string endDate)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/profit_from_period?StartDate=" + startDate + "&EndDate=" + endDate);
            var profit = JsonConvert.DeserializeObject<Profit>(res);
            return profit;
        }

        public async Task<Profit> GetTotalProfit()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/total_profit");
            var profit = JsonConvert.DeserializeObject<Profit>(res);
            return profit;
        } public async Task<List<Profit>> GetProfitByPeriod()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/profit_by_period");
            var profit = JsonConvert.DeserializeObject<List<Profit>>(res);
            return profit;
        }
    }
}
