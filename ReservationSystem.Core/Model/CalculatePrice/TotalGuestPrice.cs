using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.CalculatePrice
{
    public class TotalGuestPrice
    {
        private List<Guest> guests;
        public readonly double Value;

        public TotalGuestPrice(List<Guest> guests)
        {
            if (guests == null)
            {
                throw new ArgumentNullException();
            }

            this.guests = guests;
            this.Value = Calculate();
        }

        private double Calculate()
        {
            double totalPrice = 0.0;

            foreach (Guest guest in guests)
            {
                totalPrice += guest.GetPriceMultipliedByNights();
            }

            return totalPrice;
        }
    }
}
