using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Taxes
{
    internal class NormalTaxRate : TaxRate
    {
        public NormalTaxRate(double rate) : base(rate)
        {
        }
    }
}
