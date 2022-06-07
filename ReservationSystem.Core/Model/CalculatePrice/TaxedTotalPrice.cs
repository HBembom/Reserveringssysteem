using ReservationSystem.Core.Model.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TaxedTotalPrice : ICalculate
    {
        public NormalTaxRate NormalTaxRate;
        public TourismTaxRate TourismTaxRate;
        public readonly double Value;
        public TaxedTotalPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }

            Price totalNormalTaxPrice = NormalTaxRate.CalculateTax(totalPrice);
            Price totalTourismTaxprice = TourismTaxRate.CalculateTax(totalPrice);
            this.Value = totalNormalTaxPrice.Value + totalTourismTaxprice.Value;
        }
    }
}
