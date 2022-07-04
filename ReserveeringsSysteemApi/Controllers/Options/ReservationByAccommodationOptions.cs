using System;

namespace ReserveeringsSysteemApi.Controllers.Options
{
    public class ReservationByAccommodationOptions
    {
        public int[] AccommodationId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
