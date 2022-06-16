using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        public string AccommodationType { get; set; }
    }
    public class AccommodationClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Accommodation> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Accommodations/" + id);
            var accommodation = JsonConvert.DeserializeObject<Accommodation>(res);
            return accommodation;
        }

        public async Task<List<Accommodation>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Accommodations");
            var accommodations = JsonConvert.DeserializeObject<List<Accommodation>>(res);
            return accommodations;
        }

        public async Task Post(Accommodation accommodation)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Accommodations/", accommodation);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, Accommodation accommodation)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Accommodations/" + id, accommodation);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Accommodations/" + id);
            res.EnsureSuccessStatusCode();
        }

    }
}
