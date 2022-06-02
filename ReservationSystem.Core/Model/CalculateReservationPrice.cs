using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public class CalculateReservationPrice
    {
        public double CalculateTotalPrice(List<Accomodation> accomodations, DurationOfStay durationOfStay, List<Guest> guests)
        {
            return CalculateTotalAccomodationPrice(accomodations, durationOfStay) + CalculateTotalGuestPrice(guests);
        }

        public double CalculateTotalPriceWithTax(List<Accomodation> accomodations, DurationOfStay durationOfStay, List<Guest> guests)
        {
            double totalPrice = 0.0;
            totalPrice += CalculateTotalAccomodationPrice(accomodations, durationOfStay) + CalculateTotalGuestPrice(guests);

            return totalPrice;
        }


        public double CalculateTotalAccomodationPrice(List<Accomodation> accomodations, DurationOfStay durationOfStay)
        {
            double totalPrice = 0.0;

            foreach (Accomodation accomodation in accomodations)
            {
                totalPrice += (accomodation.price.Value * durationOfStay.GetAmmountOfNights());
            }

            return totalPrice;
        }

        public double CalculateTotalGuestPrice(List<Guest> guests)
        {
            double totalPrice = 0.0;

            foreach (Guest guest in guests)
            {
                totalPrice += guest.GetPrice();
            }

            return totalPrice;
        }
    }
}