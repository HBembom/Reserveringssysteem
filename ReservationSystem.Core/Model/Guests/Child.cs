using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Guests
{
    internal class Child : Guest
    {
        public Child(PriceExplanation price, AmmountOfNights ammountOfNights) : base(price, ammountOfNights)
        {

        }
    }
}
