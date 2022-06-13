using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalAccomodationPriceCalculator
    {
        private List<Accomodation> _accomodations;
        private DurationOfStay _durationOfStay;
        public Price Price;

        public TotalAccomodationPriceCalculator(List<Accomodation> accomodation, DurationOfStay durationOfStay)
        {
            if (accomodation == null || durationOfStay == null)
            {
                throw new ArgumentNullException();
            }

            this._accomodations = accomodation;
            this._durationOfStay = durationOfStay;
            this.Price = Calculate();
        }

        private Price Calculate()
        {
            double totalPrice = 0.0;

            foreach (Accomodation accomodation in _accomodations)
            {
                totalPrice += accomodation.Price.Value * _durationOfStay.GetAmmountOfNights().Value;
            }

            return new Price(totalPrice);
        }
    }
}
