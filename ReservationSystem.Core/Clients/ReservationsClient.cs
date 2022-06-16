using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class Reservation 
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public int[] AccommodationId { get; set; }
        public int AmountOfExtraAdults { get; set; }
        public int AmountOfExtraChildren { get; set; }
        public int AmountOfExtraPets { get; set; }
        public double TotalCost { get; set; }
        public bool PaymentStatus { get; set; }
    }
    public class ReservationsClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<Reservation> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Reservations/" + id);
            var reservation = JsonConvert.DeserializeObject<Reservation>(res);
            return reservation;
        }

        public async Task<List<Reservation>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Reservations");
            var reservations = JsonConvert.DeserializeObject<List<Reservation>>(res);
            return reservations;
        }

        public async Task Post(Reservation reservation)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Reservations/", reservation);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, Reservation reservation)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Reservations/" + id, reservation);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Reservations/" + id);
            res.EnsureSuccessStatusCode();
        }
    }
}
