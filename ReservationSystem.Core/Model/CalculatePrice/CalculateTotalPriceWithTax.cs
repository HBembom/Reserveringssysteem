using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    internal class CalculateTotalPriceWithTax : CalculatePrice
    {
        private List<PriceExplanation> Prices;
        private PriceExplanation _price;
        public CalculateTotalPriceWithTax(PriceExplanation totalPrice, PriceExplanation normalTaxPrice, PriceExplanation tourismTaxPrice)
        {
            if (totalPrice == null || normalTaxPrice == null || tourismTaxPrice == null)
            {
                throw new ArgumentNullException();
            }

            List<PriceExplanation> list = new List<PriceExplanation>();
            list.Add(totalPrice);
            list.Add(normalTaxPrice);
            list.Add(tourismTaxPrice);
            this._price = new PriceExplanation(0);
        }

        public override PriceExplanation Calculate()
        {
            foreach (PriceExplanation price in Prices)
            {
                _price.AddPrice(price);
            }

            return _price;
        }
    }
}
