using ReservationSystem.Core.Model.Taxes;
using System.Collections.Generic;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class PriceCalculationFactory
    {
        public TotalAccomodationPrice CreateAccomodationPriceCalculator(List<Accomodation> accomodation, DurationOfStay durationOfStay)
        {
            return new TotalAccomodationPrice(accomodation, durationOfStay);
        }

        public TotalGuestPrice CreateGuestPriceCalculator(List<Guest> guests)
        {
            return new TotalGuestPrice(guests);
        }

    }
}