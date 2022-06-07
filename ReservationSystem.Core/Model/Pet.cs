using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class Pet : Guest
    {
        public Pet(Price price, AmmountOfNight ammountOfNight) : base(price, ammountOfNight)
        {
            
        }
        // Api Call to Retrieve price
        public override void RetrievePrice()
        {
            throw new NotImplementedException();
        }
    }
}
