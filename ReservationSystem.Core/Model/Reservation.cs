using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class Reservation
    {
        public GuestContactDetail ContactDetail;
        public List<Accomodation> Accomodations;
        public DurationOfStay DurationOfStay;
        public CalculateReservationPrice Prices;
        public List<Guest> Occupancy;
    }
}
