using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateTotalPriceWithTax : ICalculate
    {
        private List<Price> Prices;
        private Price _price;
        public CalculateTotalPriceWithTax(Price totalPrice, Price normalTaxPrice, Price tourismTaxPrice)
        {
            if (totalPrice == null || normalTaxPrice == null || tourismTaxPrice == null)
            {
                throw new ArgumentNullException();
            }

            List<Price> list = new List<Price>();
            list.Add(totalPrice);
            list.Add(normalTaxPrice);
            list.Add(tourismTaxPrice);
            this._price = new Price(0);
        }

        public Price Calculate()
        {
            foreach (Price price in Prices)
            {
                _price.AddPrice(price);
            }

            return _price;
        }
    }
}
