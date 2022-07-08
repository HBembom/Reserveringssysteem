using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public DateTimeOffset ArrivalDate { get; set; }
        public DateTimeOffset DepartureDate { get; set; }
        public string[] AccommodationId { get; set; }
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
            var res =  await _client.GetStringAsync("http://localhost:57302/api/Reservations/" + id);
            var reservation = JsonConvert.DeserializeObject<ReservationModel>(res);
            return reservation;
        }

        public async Task<List<ReservationModel>> GetAll()
        {
            var res = await _client.GetStringAsync("http://localhost:57302/api/Reservations");

                var reservations = JsonConvert.DeserializeObject<List<ReservationModel>>(res);
            return reservations;
        } 

        public async Task<List<ReservationModel>> GetByAccommodation(int[] id, string startDate, string endDate)
        {
            var options = new
            {
                AccommodationId = id,
                StartDate = startDate,
                EndDate = endDate,

            };
            var getAccommodationRoute = "http://localhost:57302/api/get_reservation_by_accommodations/?";
            for (var i = 0; i < id.Length; i++)
            {
                getAccommodationRoute += $"AccommodationId={id[i]}&";
            }

            getAccommodationRoute += $"StartDate={startDate}&EndDate={endDate}";
            var res = await _client.GetStringAsync(getAccommodationRoute);
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
