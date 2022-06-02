using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class Reservation
    {
        public DurationOfStay DurationOfStay;
        public CalculateReservationPrice Prices;
        public List<Accomodation> Accomodations;
        public GuestContactDetail ContactDetail;
        public List<Guest> Occupancy;
    }
}
