using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateTaxPrice : CalculatePrice
    {
        private TaxRate _taxRate;
        private Price _totalPrice;

        public CalculateTaxPrice(TaxRate taxRate, Price totalPrice)
        {
            if(taxRate == null || totalPrice == null)
            {
                throw new ArgumentNullException();
            }

            this._taxRate = taxRate;
            this._totalPrice = totalPrice;
        }

        public override Price Calculate()
        {
            return this._taxRate.CalculateTax(_totalPrice);
        }
    }
}
