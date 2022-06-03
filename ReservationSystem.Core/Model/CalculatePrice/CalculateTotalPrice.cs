using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    internal class CalculateTotalPrice : CalculatePrice
    {
        private List<PriceExplanation> Prices;
        private PriceExplanation _price;

        public CalculateTotalPrice(PriceExplanation accomodationPrice, PriceExplanation guestPrice)
        {
            if (accomodationPrice == null || guestPrice == null)
            {
                throw new ArgumentNullException();
            }

            List<PriceExplanation> list = new List<PriceExplanation>();
            list.Add(accomodationPrice);
            list.Add(guestPrice);
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
