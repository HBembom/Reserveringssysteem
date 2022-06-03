using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class PriceExplanation
    {
        public Price TotalAccomodationPrice;
        public Price TotalGuestPrice;
        public Price TotalPrice;
        public Price TotalTax;
        public Price TotalTaxedPrice;
        private PriceCalculation calculator;
        

        public PriceExplanation(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            if (durationOfStay == null || accomodations == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }

           
        }

        public void CalculatePrices()
        {
            
        }


    }
}