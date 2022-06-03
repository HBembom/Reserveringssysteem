using System;

namespace ReservationSystem.Core.Model
{
    public class PriceExplanation
    {
        public readonly double Value;

        public PriceExplanation(double price)
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

        public PriceExplanation AddPrice(PriceExplanation price)
        {
            if (price == null)
            {
                throw new ArgumentNullException();
            }
            return new PriceExplanation(this.Value + price.Value);
        }
    }
}