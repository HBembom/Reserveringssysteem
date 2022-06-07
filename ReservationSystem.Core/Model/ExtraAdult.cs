using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class ExtraAdult : Guest
    {
        public ExtraAdult(Price price, AmmountOfNight ammountOfNight) : base(price, ammountOfNight)
        {

        }
        // Api Call to retrieve price necessary
        public override void RetrievePrice()
        {
            throw new NotImplementedException();
        }
    }
}
