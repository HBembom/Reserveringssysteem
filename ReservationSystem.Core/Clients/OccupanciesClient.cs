using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Occupancy
    {
        public int OccupancyId { get; set; }
        public int AccommodationId { get; set; }
        public int ReservationId { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public bool PaymentStatus { get; set; }

    }
    public class OccupanciesClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Occupancy> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Occupancies/" + id);
            var occupancy = JsonConvert.DeserializeObject<Occupancy>(res);
            return occupancy;
        }

        public async Task<List<Occupancy>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Occupancies");
            var occupancies = JsonConvert.DeserializeObject<List<Occupancy>>(res);
            return occupancies;
        }

        public async Task Post(Occupancy occupancy)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Occupancies/", occupancy);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, Occupancy occupancy)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Occupancies/" + id, occupancy);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Occupancies/" + id);
            res.EnsureSuccessStatusCode();
        }
    }
}
