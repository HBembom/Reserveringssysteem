using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    public class Camper : Accomodation
    {
        public Camper(int id)
        {
            this.ID = new ID(id);
            this.Price = new Price(18.50);
        }
    }
}
