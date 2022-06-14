using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.Guests;
using System;

namespace ReservationSystem.Core.ViewModel.Factory
{
    public class GuestFactory
    {
        public GuestFactory()
        {
            
        }

        public Guest Create(string guest, int ammountOfNights)
        {
            switch (guest)
            {
                case nameof(Pet):
                    return new Pet( new Price(2.50), new AmmountOfNights(ammountOfNights));
                    
                case nameof(Child):
                    return new Child(new Price(3.50), new AmmountOfNights(ammountOfNights));
                    
                case nameof(Adult):
                    return new Adult(new Price(5.00), new AmmountOfNights(ammountOfNights));
                
                default: throw new ArgumentException(nameof(guest));
            }
        }
    }
}
