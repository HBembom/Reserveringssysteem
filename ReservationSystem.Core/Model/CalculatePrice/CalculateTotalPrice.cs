using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateTotalPrice : ICalculate
    {
        public readonly double Value;

        public CalculateTotalPrice(Price price)
        {
            if (price == null)
            {
                throw new ArgumentNullException();
            }

            this.Value = price.Value;
        }
    }
}
