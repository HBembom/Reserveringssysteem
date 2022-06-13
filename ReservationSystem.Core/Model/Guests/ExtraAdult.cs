using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Guests
{
    internal class ExtraAdult : Guest
    {
        public ExtraAdult(Price price, AmmountOfNights ammountOfNights) : base(price, ammountOfNights)
        {
        }
    }
}
