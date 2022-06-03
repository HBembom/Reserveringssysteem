using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    internal class CalculateGuestPrice : CalculatePrice
    {
        public List<Guest> guests;

        public CalculateGuestPrice(List<Guest> guests)
        {
            if (guests == null)
            {
                throw new ArgumentNullException();
            }

            this.guests = guests;
        }

        public override Price Calculate()
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
