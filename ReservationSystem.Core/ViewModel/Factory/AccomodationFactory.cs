using ReservationSystem.Core.Model;
using System;

namespace ReservationSystem.Core.ViewModel
{
    public class AccomodationFactory
    {
        public Accomodation Create(string accomodation, int id)
        {
            switch (accomodation)
            {
                case nameof(Camper):
                    return new Camper(id);

                case nameof(House):
                    return new House();
                
                default: throw new ArgumentException(nameof(accomodation));
            }
        }
    }
}