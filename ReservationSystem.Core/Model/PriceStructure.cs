using ReservationSystem.Core.Model.CalculatePrice;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class PriceStructure
    {
        public readonly Price TotalAccomodationPrice;
        public readonly Price TotalGuestPrice;
        public readonly Price TotalPrice;
        public readonly Price TotalNormalTaxPrice;
        public readonly Price TotalTourismTaxPrice;
        public readonly Price TotalTax;
        public readonly Price TotalTaxedPrice;
        
        public PriceStructure(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            if (durationOfStay == null || accomodations == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }
            
            this.TotalAccomodationPrice = new TotalAccomodationPrice(accomodations, durationOfStay).Price;
            this.TotalGuestPrice = new TotalGuestPrice(occupancy).Price;
            this.TotalPrice = new Price(TotalAccomodationPrice.Value + TotalGuestPrice.Value);
            this.TotalNormalTaxPrice =new TotalNormalTaxPrice(TotalPrice).Price;
            this.TotalTourismTaxPrice = new TotalTourismTaxPrice(TotalPrice).Price;
            this.TotalTax = new Price(TotalNormalTaxPrice.Value + TotalTourismTaxPrice.Value);
            this.TotalTaxedPrice = new Price(TotalPrice.Value + TotalTourismTaxPrice.Value);
        }
        // Above or below one?

        public PriceStructure(Price totalAccomodationPrice, Price totalGuestPrice, Price totalPrice, Price totalNormalTaxPrice, Price totalTourismTaxPrice, Price totalTax, Price totalTaxedPrice)
        {
            if (totalAccomodationPrice == null || totalGuestPrice == null || totalPrice == null)
            {
                throw new ArgumentNullException();
            }

            this.TotalAccomodationPrice = totalAccomodationPrice;
            this.TotalGuestPrice = totalGuestPrice;
            this.TotalPrice = totalPrice;
            this.TotalNormalTaxPrice = totalNormalTaxPrice;
            this.TotalTourismTaxPrice = totalTourismTaxPrice;
            this.TotalTax = totalTax;
            this.TotalTaxedPrice = totalTaxedPrice;
        }
    }
}