using ReserveeringsSysteemApi.Models;

namespace ReserveeringsSysteemApi.Controllers.Extra
{
    public class CalculateReservationPrice
    {
        public double NormalTax { get; set; }
        public double TourismTax { get; set; }
        public double AdultPrice { get; set; }
        public double ChildPrice { get; set; }
        public double PetPrice { get; set; }

        public CalculateReservationPrice(double normalTax, double tourismTax, double adultPrice, double childPrice, double petPrice)
        {
            NormalTax = normalTax;
            TourismTax = tourismTax;
            AdultPrice = adultPrice;
            ChildPrice = childPrice;
            PetPrice = petPrice;
        }

        public double CalculatePriceWithoutTax(Reservations reservation)
        {
            var price = 0.0;
            price += (reservation.AmountOfExtraAdults * AdultPrice);
            price += (reservation.AmountOfExtraChildren * ChildPrice);
            price += (reservation.AmountOfExtraPets * PetPrice);

            return price;
        }

        public double CalculateTourismTax(double price)
        {
            return price * TourismTax;
        }

        public double CalculateNormalTax(double price)
        {
            return price * NormalTax;
        }

        public double CalculatePriceWithAllTax(Reservations reservation)
        {
            var priceWithoutTax = CalculatePriceWithoutTax(reservation);
            var priceWithTourismTax = CalculateTourismTax(priceWithoutTax);
            var priceWithAllTax = CalculateNormalTax(priceWithTourismTax);

            return priceWithAllTax;
        }
    }
}
