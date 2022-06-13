using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Taxes
{
    public abstract class TaxRate
    {
        const double MINIMUMRATE = 0.00;
        const double MAXIMUMRATE = 100.00;
        public readonly double Rate;

        public TaxRate(double rate)
        {
            RateIsInclusive(rate);
            this.Rate = rate;
        }

        public Price CalculateTax(Price price)
        {
            return price.AddPrice(new Price(price.Value * (Rate / 100)));
        }

        private void RateIsInclusive(double rate)
        {
            if(rate < MINIMUMRATE || rate > MAXIMUMRATE)
            {
                throw new ArgumentException("Invalid Tax Rate");
            }
        }
    }
}
