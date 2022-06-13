using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalNormalTaxPrice
    {
        public Price Price;

        public TotalNormalTaxPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }
            NormalTaxRate normalTaxRate = new NormalTaxRate(9);

            this.Price = normalTaxRate.CalculateTax(totalPrice);
        }
    }
}
