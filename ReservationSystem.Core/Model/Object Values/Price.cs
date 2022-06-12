using System;

namespace ReservationSystem.Core.Model
{
    public class Price
    {
        public readonly double Value;

        public Price(double price)
        {
            PriceIsNotLessThanZero(price);
            this.Value = price;
        }

        private void PriceIsNotLessThanZero(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price can not be lower than 0.0");
            };
        }

        public Price AddPrice(Price price)
        {
            if (price == null)
            {
                throw new ArgumentNullException();
            }
            return new Price(this.Value + price.Value);
        }
    }
}