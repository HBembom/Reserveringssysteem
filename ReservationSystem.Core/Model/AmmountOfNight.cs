using System;

namespace ReservationSystem.Core.Model
{
    internal class AmmountOfNight
    {
        public int Value;
        public AmmountOfNight(int ammountOfNights)
        {
            AmmountOfNightIsNotLessThanZero(ammountOfNights);
            this.Value = ammountOfNights;
        }

        private void AmmountOfNightIsNotLessThanZero(int ammountOfNights)
        {
            if (ammountOfNights < 0)
            {
                throw new ArgumentException("Ammount of nights cannot be less than 0");
            }
        }
    }
}