using ReservationSystem.Core.Model.CalculatePrice;
using System;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class PriceStructure
    {
        public readonly TotalAccomodationPrice TotalAccomodationPrice;
        public readonly TotalGuestPrice TotalGuestPrice;
        public readonly Price TotalPrice;
        public readonly TotalNormalTaxPrice TotalNormalTaxPrice;
        public readonly TotalTourismTaxPrice TotalTourismTaxPrice;
        public readonly Price TotalTax;
        
        public PriceStructure(DurationOfStay durationOfStay, List<Accomodation> accomodations, List<Guest> occupancy)
        {
            if (durationOfStay == null || accomodations == null || occupancy == null)
            {
                throw new ArgumentNullException();
            }

            this.TotalAccomodationPrice = new TotalAccomodationPrice(accomodations, durationOfStay);
            this.TotalGuestPrice = new TotalGuestPrice(occupancy);
            this.TotalPrice = new Price(TotalAccomodationPrice.Value + TotalGuestPrice.Value);
            this.TotalNormalTaxPrice = new TotalNormalTaxPrice(TotalPrice);
            this.TotalTourismTaxPrice = new TotalTourismTaxPrice(TotalPrice);
            this.TotalTax = new Price(TotalNormalTaxPrice.Value + TotalTourismTaxPrice.Value);
        }
    }
}