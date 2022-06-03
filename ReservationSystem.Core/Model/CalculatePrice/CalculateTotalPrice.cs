using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    internal class CalculateTotalPrice : CalculatePrice
    {
        private List<Price> Prices;
        private Price _price;

        public CalculateTotalPrice(Price accomodationPrice, Price guestPrice)
        {
            if (accomodationPrice == null || guestPrice == null)
            {
                throw new ArgumentNullException();
            }

            List<Price> list = new List<Price>();
            list.Add(accomodationPrice);
            list.Add(guestPrice);
            this._price = new Price(0);
        }
    
        public override Price Calculate()
        {
            foreach (Price price in Prices)
            {
                _price.AddPrice(price);
            }

            return _price;
        }
    }
}
