using System;

namespace ReservationSystem.Core.Model
{
    internal class AmmountOfNights
    {
        public readonly int Value;

        public AmmountOfNights(int ammountOfNights)
        {
            AmmountIsNotLessThanZero(ammountOfNights);
            Value = ammountOfNights;
        }

        private void AmmountIsNotLessThanZero(int ammountOfNights)
        {
            throw new ArgumentException("Ammount cannot be less than Zero");
        }
    }
}