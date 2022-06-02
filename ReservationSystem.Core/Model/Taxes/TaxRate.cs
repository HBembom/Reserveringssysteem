using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Taxes
{
    internal abstract class TaxRate
    {
        const double MINIMUMRATE = 0.00;
        const double MAXIMUMRATE = 100.00;
        public readonly double Rate;

        public TaxRate(double rate)
        {
            RateIsInclusive(rate);
            this.Rate = rate;
        }

        public double CalculateTax(double price)
        {
            return price * (Rate / 100);
        }

        public double CalculatePriceWithTax(double price)
        {
            return price * (1 + (Rate / 100));
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
