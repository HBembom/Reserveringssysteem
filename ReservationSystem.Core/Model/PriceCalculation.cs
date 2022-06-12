using ReservationSystem.Core.Model.Taxes;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    internal class PriceCalculation 
    {
        public  ICalculate CalculateAccomodationPrice;
        public  ICalculate CalculateGuestPrice;
        public  ICalculate CalculateTotalPrice;
        public  ICalculate CalculateNormalTaxPrice;
        public  ICalculate CalculateTourismTaxPrice;
        public  ICalculate CalculateTaxedTotalPrice;

        public PriceCalculation(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            if (durationOfStay == null || accomodations == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }

        }
    }
}