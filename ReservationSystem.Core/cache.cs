using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Core.Clients;

namespace ReservationSystem.Core
{
    internal static class cache
    {
        public static List<AccommodationModel> AccommodationModels;
        private static AccommodationClient _accommodationClient = new AccommodationClient();
         static cache()
         {
             AccommodationModels = new List<AccommodationModel>();
         }

         public static async void GetAccommodationsModels()
         {
             AccommodationModels = await _accommodationClient.GetAll();

        }
    }
}
