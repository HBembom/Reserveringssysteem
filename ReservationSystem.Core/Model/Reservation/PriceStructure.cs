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

        public PriceStructure(Price totalAccomodationPrice, Price totalGuestPrice, Price totalPrice, Price totalNormalTaxPrice, Price totalTourismTaxPrice, Price totalTax, Price totalTaxedPrice)
        {
            NotNull(totalAccomodationPrice, totalGuestPrice, totalPrice, totalNormalTaxPrice, totalTourismTaxPrice, totalTax, totalTaxedPrice);

            this.TotalAccomodationPrice = totalAccomodationPrice;
            this.TotalGuestPrice = totalGuestPrice;
            this.TotalPrice = totalPrice;
            this.TotalNormalTaxPrice = totalNormalTaxPrice;
            this.TotalTourismTaxPrice = totalTourismTaxPrice;
            this.TotalTax = totalTax;
            this.TotalTaxedPrice = totalTaxedPrice;
        }

        private void NotNull(Price totalAccomodationPrice, Price totalGuestPrice, Price totalPrice, Price totalNormalTaxPrice, Price totalTourismPrice, Price totalTax, Price totalTaxedPrice)
        {
            if (totalAccomodationPrice == null || totalGuestPrice == null || totalPrice == null || totalNormalTaxPrice == null || totalTourismPrice == null || totalTax == null || totalTaxedPrice == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}