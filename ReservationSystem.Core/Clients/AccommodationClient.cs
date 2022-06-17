using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class AccommodationModel
    {
        public int AccommodationId { get; set; }
        public double Price { get; set; }
        public string AccommodationType { get; set; }
    }
    public class AccommodationClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<AccommodationModel> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Accommodations/" + id);
            var accommodation = JsonConvert.DeserializeObject<AccommodationModel>(res);
            return accommodation;
        }

        public async Task<List<AccommodationModel>> GetAll()
        {
            var accommodationsList = new List<AccommodationModel>();
            var res = await _client.GetAsync("http://localhost:57302/api/Accommodations");
            res.EnsureSuccessStatusCode();
            accommodationsList = await res.Content.ReadAsAsync<List<AccommodationModel>>();
            // var accommodations = JsonConvert.DeserializeObject<List<AccommodationModel>>(res);
            return accommodationsList;
        }

        public async Task Post(AccommodationModel accommodationModel)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Accommodations/", accommodationModel);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, AccommodationModel accommodationModel)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Accommodations/" + id, accommodationModel);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Accommodations/" + id);
            res.EnsureSuccessStatusCode();
        }

    }
}
