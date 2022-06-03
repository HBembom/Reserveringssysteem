using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalNormalTaxPrice
    {
        public readonly double Value;

        public TotalNormalTaxPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }
            NormalTaxRate normalTaxRate = new NormalTaxRate(9);

            Price price =  normalTaxRate.CalculateTax(totalPrice);
            this.Value = price.Value;
        }
    }
}
