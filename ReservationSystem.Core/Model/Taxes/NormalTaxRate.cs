using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Taxes
{
    public class NormalTaxRate : TaxRate
    {
        public NormalTaxRate(double rate) : base(rate)
        {
        }
    }
}
