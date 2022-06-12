using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class CalculateAccomodationPrice : ICalculate
    {
        private List<Accomodation> Accomodations;
        private DurationOfStay DurationOfStay;

        public CalculateAccomodationPrice(List<Accomodation> accomodation, DurationOfStay durationOfStay)
        {
            if (accomodation == null || durationOfStay == null)
            {
                throw new ArgumentNullException();
            }

            this.Accomodations = accomodation;
            this.DurationOfStay = durationOfStay;
        }

        public Price Calculate()
        {
            double totalPrice = 0.0;

            foreach (Accomodation accomodation in Accomodations)
            {
                totalPrice += accomodation.Price.Value * DurationOfStay.GetAmmountOfNights();
            }

            return new Price(totalPrice);
        }
    }
}
