using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    interface IGuest
    {
          Price Price { get; }
          AmmountOfNight AmmountOfNights {get;}
    }
}
