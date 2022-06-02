using System;

namespace ReservationSystem.Core.Model
{
    internal class AmmountOfNights
    {
        const int MINIMUM_AMMOUNT_OF_NIGHTS = 0;
        const int MAXIMUM_AMMOUNT_OF_NIGHTS = 365;
        public readonly int Value;

        public AmmountOfNights(int ammountOfNights)
        {
            AmmountIsInclusive(ammountOfNights);
            Value = ammountOfNights;
        }

        private void AmmountIsInclusive(int ammountOfNights)
        {
            if (MINIMUM_AMMOUNT_OF_NIGHTS > 0 || ammountOfNights > MAXIMUM_AMMOUNT_OF_NIGHTS)
            {
                throw new ArgumentException("Ammount of nights is not valid");
            }
        }
    }
}