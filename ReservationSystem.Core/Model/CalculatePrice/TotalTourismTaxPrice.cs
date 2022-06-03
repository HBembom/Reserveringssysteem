using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalTourismTaxPrice
    {
        public readonly double Value;
  
        public TotalTourismTaxPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }
            TourismTaxRate tourismTaxRate = new TourismTaxRate(9);

            Price price = tourismTaxRate.CalculateTax(totalPrice);
            this.Value = price.Value;
        }
    }
}
