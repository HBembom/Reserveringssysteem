using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    internal class PriceCalculation
    {

        private DurationOfStay _durationOfStay;
        private List<Accomodation> _accomodations;
        private List<Guest> _guests;

        public PriceCalculation(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            this._durationOfStay = durationOfStay;
            this._accomodations = accomodations;
            this._guests = occupancy;
        }
    }
}