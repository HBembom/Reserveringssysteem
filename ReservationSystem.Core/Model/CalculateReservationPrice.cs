using System.Collections.Generic;

namespace ReservationSystem.Core.Model
{
    public abstract class CalculateReservationPrice
    {

        public abstract Price Calculate()
        {
            return new Price();
        }

        public Price CalculatePriceAllAccomodation(Price price, List<Accomodation> accomodations, DurationOfStay durationOfStay)
        {
            Price totalPrice = price;

            foreach (Accomodation accomodation in accomodations)
            {
                totalPrice.AddPrice(accomodation.Price);
            }

            return totalPrice;
        }

        public Price CalculatePriceAllGuests(Price price, List<Guest> guests)
        {
            Price totalPrice = price;

            foreach (Guest guest in guests)
            {
                totalPrice.AddPrice(guest.Price);
            }

            return price;
        }

        public Price CalculateTotalPrice(Price price, List<Accomodation> accomodations, DurationOfStay durationOfStay, List<Guest> guests)
        {
            Price totalPrice = price;

            totalPrice.AddPrice(CalculatePriceAllAccomodation(price, accomodations, durationOfStay));
            totalPrice.AddPrice(CalculatePriceAllGuests(totalPrice, guests));

            return totalPrice;
        }

        public Price CalculateTotalPriceWithTax(Price price, List<Accomodation> accomodations, DurationOfStay durationOfStay, List<Guest> guests)
        {
            Price totalPrice = price;

            totalPrice.AddPrice(CalculatePriceAllAccomodation(price, accomodations, durationOfStay));
            totalPrice.AddPrice(CalculatePriceAllGuests(totalPrice, guests));

            return totalPrice;
        }

        
    }
}