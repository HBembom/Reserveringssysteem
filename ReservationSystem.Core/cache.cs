using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Core.Clients;

namespace ReservationSystem.Core
{
    internal static class Cache
    {
        public static List<AccommodationModel> AccommodationModels;
        public static List<ReservationModel> ReservationModels;
        private static readonly AccommodationClient AccommodationClient = new AccommodationClient();
        private static readonly ReservationsClient ReservationClient = new ReservationsClient();
         static Cache()
         {
             AccommodationModels = new List<AccommodationModel>();
             ReservationModels = new List<ReservationModel>();
         }

         public static async void SetAccommodationModels()
         {
             AccommodationModels = await AccommodationClient.GetAll();
         }
         
         public static async void SetReservationModels()
         {
            ReservationModels = await ReservationClient.GetAll();

        }
    }
}