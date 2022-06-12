using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class Child : Guest
    {
        public Child(Price price, AmmountOfNight ammountOfNight) : base(price, ammountOfNight)
        {
        }

        // Api Call
        public override void RetrievePrice()
        {
            throw new NotImplementedException();
        }
    }
}
