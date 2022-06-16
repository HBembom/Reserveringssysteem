using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Guest
    {
        public int GuestId { get; set; }
        public int AmountOfDays { get; set; }
        public string TypeOfGuest { get; set; }
        public double Price { get; set; }
    }
    public class GuestClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Guest> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Guests/" + id);
            var guest = JsonConvert.DeserializeObject<Guest>(res);
            return guest;
        }

        public async Task<List<Guest>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Guests");
            var guests = JsonConvert.DeserializeObject<List<Guest>>(res);
            return guests;
        }

        public async Task Post(Guest guest)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Guests/", guest);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, Guest guest)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Guests/" + id, guest);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Guests/" + id);
            res.EnsureSuccessStatusCode();
        }
    }
}
