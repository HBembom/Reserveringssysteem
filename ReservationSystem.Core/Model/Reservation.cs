using ReservationSystem.Core.Model.Taxes;
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
        public PriceExplanation Price;
        public List<Accomodation> Accomodations;
        public GuestContactDetail ContactDetail;
        public List<Guest> Occupancy;

        public Reservation(DurationOfStay durationOfStay, Price price, List<Accomodation> accomodations, GuestContactDetail contactDetail, List<Guest> occupancy)
        {
            DurationOfStay = durationOfStay;
            Price = price; 
            Accomodations = accomodations;
            ContactDetail = contactDetail;
            Occupancy = occupancy;
        }
    }
}
