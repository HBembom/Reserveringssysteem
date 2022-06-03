using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalTourismTaxPrice
    {
        public Price Price;
  
        public TotalTourismTaxPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }
            TourismTaxRate tourismTaxRate = new TourismTaxRate(9);

            this.Price = tourismTaxRate.CalculateTax(totalPrice);
        }
    }
}
