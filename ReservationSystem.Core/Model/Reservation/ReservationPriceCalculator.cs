using ReservationSystem.Core.Model.CalculatePrice;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    internal class ReservationPriceCalculator
    {
        private Price _totalAccomodationPrice;
        private Price _totalGuestPrice;
        private Price _totalPrice;
        private Price _totalNormalTaxPrice;
        private Price _totalTourismTaxPrice;
        private Price _totalTax;
        private Price _totalTaxedPrice;

        public ReservationPriceCalculator(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            if(durationOfStay == null || accomodations == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }

            this._totalAccomodationPrice = new TotalAccomodationPriceCalculator(accomodations, durationOfStay).Price;
            this._totalGuestPrice = new TotalGuestPriceCalculator(occupancy).Price;
            this._totalPrice = new Price(_totalAccomodationPrice.Value + _totalGuestPrice.Value);
            this._totalNormalTaxPrice = new TotalNormalTaxPriceCalculator(_totalPrice).Price;
            this._totalTourismTaxPrice = new TotalTourismTaxPriceCalculator(_totalPrice).Price;
            this._totalTax = new Price(_totalNormalTaxPrice.Value + _totalTourismTaxPrice.Value);
            this._totalTaxedPrice = new Price(_totalPrice.Value + _totalTourismTaxPrice.Value);


        }

        public PriceStructure GetPriceStructure()
        {
            return new PriceStructure(_totalAccomodationPrice, 
                _totalGuestPrice, 
                _totalPrice, 
                _totalNormalTaxPrice, 
                _totalTourismTaxPrice, 
                _totalTax, 
                _totalTaxedPrice);
        }
    }
}