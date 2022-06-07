using ReservationSystem.Core.Model.CalculatePrice;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class PriceExplanation
    {
        public readonly Price TotalAccomodationPrice;
        public readonly Price TotalGuestPrice;
        public readonly Price TotalPrice;
        public readonly Price TotalNormalTaxPrice;
        public readonly Price TotalTourismTaxPrice;
        public readonly Price TotalTax;
        public readonly Price TotalTaxedPrice;
        private readonly PriceCalculation calculator;
        
        public PriceExplanation(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            this.calculator = new PriceCalculation(durationOfStay, accomodations, occupancy);

            TotalAccomodationPrice = calculator.CalculateAccomodationPrice.Calculate();
            TotalGuestPrice = calculator.CalculateGuestPrice.Calculate();
            TotalPrice = calculator.CalculateTotalPrice.Calculate();
            TotalNormalTaxPrice = calculator.CalculateNormalTaxPrice.Calculate();
            TotalTourismTaxPrice = calculator.CalculateTourismTaxPrice.Calculate();
            TotalTax = calculator.CalculateTaxedTotalPrice.Calculate();
            TotalTaxedPrice = calculator.CalculateTaxedTotalPrice.Calculate();
        }
    }
}