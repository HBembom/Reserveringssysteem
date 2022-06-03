using ReservationSystem.Core.Model.Taxes;
using System;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateTaxPrice : CalculatePrice
    {
        private TaxRate _taxRate;
        private PriceExplanation _totalPrice;

        public CalculateTaxPrice(TaxRate taxRate, PriceExplanation totalPrice)
        {
            if(taxRate == null || totalPrice == null)
            {
                throw new ArgumentNullException();
            }

            this._taxRate = taxRate;
            this._totalPrice = totalPrice;
        }

        public override PriceExplanation Calculate()
        {
            return this._taxRate.CalculateTax(_totalPrice);
        }
    }
}
