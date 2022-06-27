using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReservationSystem.Core.Clients
{
    public class ReservationModel 
    {
        public int ReservationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrefixName { get; set; }
        public string StreetName { get; set; }
        public string LicensePlateName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
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

        public async Task<ReservationModel> GetById(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Reservations/" + id);
            var reservation = JsonConvert.DeserializeObject<ReservationModel>(res);
            return reservation;
        }

        public async Task<List<ReservationModel>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Reservations");
            var reservations = JsonConvert.DeserializeObject<List<ReservationModel>>(res);
            return reservations;
        } 

        public async Task<List<ReservationModel>> GetByAccommodation(int id)
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/get_reservation_by_accommodation/" + id);
            var reservations = JsonConvert.DeserializeObject<List<ReservationModel>>(res);
            return reservations;
        }

        public async Task Post(ReservationModel reservationModel)
        {
            var res = await _client.PostAsJsonAsync("http://localhost:57302/api/Reservations/", reservationModel);
            res.EnsureSuccessStatusCode();
        }

        public async Task Put(int id, ReservationModel reservationModel)
        {
            var res = await _client.PutAsJsonAsync("http://localhost:57302/api/Reservations/" + id, reservationModel);
            res.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var res = await _client.DeleteAsync("http://localhost:57302/api/Reservations/" + id);
            res.EnsureSuccessStatusCode();
        }
    }
}
