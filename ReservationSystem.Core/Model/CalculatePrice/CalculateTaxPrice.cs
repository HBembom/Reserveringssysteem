using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateTaxPrice : ICalculate
    {
        private TaxRate _taxRate;
        private Price _totalPrice;
        public readonly Price Value;
  

        public CalculateTaxPrice(Price totalPrice)
        {
            if(taxRate == null || totalPrice == null)
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
