using System;

namespace ReservationSystem.Core.Model
{
    public class ID
    {
        public readonly int value;

        public ID(int id)
        {
            IsNotLessThanZero(id);
            this.value = id;
        }

        private void IsNotLessThanZero(int id)
        {
            if(id < 0)
            {
                throw new ArgumentException("Can not be less than zero");
            }
        }
    }
}