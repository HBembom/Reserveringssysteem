using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class ProfitModel
    {
        public double AmountOfProfit { get; set; }
        public int Period { get; set; }
    }
    public class ProfitsClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<ProfitModel> GetProfitFromPeriod(string startDate, string endDate)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/profit_from_period?StartDate=" + startDate + "&EndDate=" + endDate);
            var profit = JsonConvert.DeserializeObject<ProfitModel>(res);
            return profit;
        }

        public async Task<ProfitModel> GetTotalProfit()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/total_profit");
            var profit = JsonConvert.DeserializeObject<ProfitModel>(res);
            return profit;
        } public async Task<List<ProfitModel>> GetProfitByPeriod()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/profit_by_period");
            var profit = JsonConvert.DeserializeObject<List<ProfitModel>>(res);
            return profit;
        }
    }
}
