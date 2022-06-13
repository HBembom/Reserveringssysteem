using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class Reservation
    {
        public DurationOfStay DurationOfStay;
        public PriceStructure PriceStructure;
        public List<Accomodation> Accomodations;
        public GuestContactDetail ContactDetail;
        public List<Guest> Occupancy;
        public PaidStatus hasPaid;
        private ReservationPriceCalculator _priceCalculator;

        public Reservation(DurationOfStay durationOfStay,  List<Accomodation> accomodations, GuestContactDetail contactDetail, List<Guest> occupancy)
        {
            NotNull(durationOfStay, accomodations, contactDetail, occupancy);

            this.DurationOfStay = durationOfStay;
            this.Accomodations = accomodations;
            this.ContactDetail = contactDetail;
            this.Occupancy = occupancy;
            this._priceCalculator = new ReservationPriceCalculator(durationOfStay, accomodations, occupancy);
            this.PriceStructure = _priceCalculator.GetPriceStructure();
            this.hasPaid = new PaidStatus();
        }

        private void NotNull(DurationOfStay durationOfStay, List<Accomodation> accomodations, GuestContactDetail contactDetail, List<Guest> occupancy)
        {
           if(durationOfStay == null || accomodations == null || contactDetail == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
