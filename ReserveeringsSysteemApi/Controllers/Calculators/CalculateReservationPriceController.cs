using ReserveeringsSysteemApi.Models;

namespace ReserveeringsSysteemApi.Controllers.Calculators
{
    public class CalculateReservationPriceController
    {
        public double NormalTax { get; set; }
        public double TourismTax { get; set; }
        public double AdultPrice { get; set; }
        public double ChildPrice { get; set; }
        public double PetPrice { get; set; }

        public CalculateReservationPriceController(double normalTax, double tourismTax, double adultPrice, double childPrice, double petPrice)
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
            price += (reservation.AmountOfExtraAdults * AdultPrice) + (reservation.AmountOfExtraChildren * ChildPrice) + (reservation.AmountOfExtraPets * PetPrice);

            return price;
        }

        public double CalculatePriceWithTourismTax(double price)
        {
            return price * TourismTax;
        }

       
        public double CalculatePriceWithNormalTax(double price)
        {
            return price * NormalTax;
        }

        public double CalculatePriceWithAllTax(Reservations reservation)
        {
            var priceWithoutTax = CalculatePriceWithoutTax(reservation);
            var priceWithTourismTax = CalculatePriceWithTourismTax(priceWithoutTax);
            var priceWithAllTax = CalculatePriceWithNormalTax(priceWithTourismTax);

            return priceWithAllTax;
        }
    }
}
