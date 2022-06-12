using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public interface IPriceCalculate
    {

        ICalculate CalculateAccomodationPrice();
        ICalculate CalculateGuestPrice();
        ICalculate CalculateTotalPrice();
        ICalculate CalculateNormalTaxPrice();
        ICalculate CalculateTourismTaxPrice();
        ICalculate CalculateTaxedTotalPrice();
    }
}
