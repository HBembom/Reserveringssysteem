using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateNormalTaxPrice
    {
        public CalculateTaxPrice(Price totalPrice)
        {
            if (totalPrice == null)
            {
                throw new ArgumentNullException();
            }
            this._taxRate = taxRate;
            this._totalPrice = totalPrice;
        }

        public double Calculate()
        {
            return ( ;
        }
    }
}
