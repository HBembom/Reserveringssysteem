using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model
{
    internal class Guest
    {
        public Price Price;
        public AmmountOfNights AmmountOfNights;

        public Guest(Price price, AmmountOfNights ammountOfNights)
        {
            Price = price;
            AmmountOfNights = ammountOfNights;
        }

        public double GetPrice()
        {
            return Price.Value;
        }

        public int GetAmmountOfNights()
        {
            return AmmountOfNights.Value;
        }
    }
}
