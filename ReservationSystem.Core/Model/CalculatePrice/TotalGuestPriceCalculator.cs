using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalGuestPriceCalculator
    {
        private List<Guest> guests;
        public Price Price;

        public TotalGuestPriceCalculator(List<Guest> guests)
        {
            if (guests == null)
            {
                throw new ArgumentNullException();
            }

            this.guests = guests;
            this.Price = Calculate();
        }

        private Price Calculate()
        {
            double totalPrice = 0.0;

            foreach (Guest guest in guests)
            {
                totalPrice += guest.GetPriceMultipliedByNights();
            }

            return new Price(totalPrice);
        }
    }
}
