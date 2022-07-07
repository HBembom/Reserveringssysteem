using System;

namespace ReservationSystem.Core.Model
{
    public class DurationOfStay
    {
        public readonly DateTimeOffset ArrivalDateTime;
        public readonly DateTimeOffset DepartureDateTime;

        public DurationOfStay(DateTimeOffset arrivalDateTime, DateTimeOffset departureDateTime)
        {
            NotNull(arrivalDateTime, departureDateTime);
            // CheckIfArrivalIsPresentOrFuture(arrivalDateTime);
            CheckIfDepartureIsLaterThanArrival(arrivalDateTime, departureDateTime);
            this.ArrivalDateTime = arrivalDateTime;
            this.DepartureDateTime = departureDateTime;
        }

        public AmmountOfNights GetAmmountOfNights()
        {
            return new AmmountOfNights(DepartureDateTime.Subtract(ArrivalDateTime).Days);
        }

        private void NotNull(DateTimeOffset arrivalDateTime, DateTimeOffset departureDateTime)
        {
            if(arrivalDateTime.Equals(null) || departureDateTime.Equals(null))
            {
                throw new ArgumentException("You must select a Date");
            }
        }

        private void CheckIfDepartureIsLaterThanArrival(DateTimeOffset arrivalDateTime, DateTimeOffset departureDateTime)
        {
            if (departureDateTime < arrivalDateTime)
            {
                throw new ArgumentException("Not possible to book a departure before arrival");
            }
            
        }

        private void CheckIfArrivalIsPresentOrFuture(DateTimeOffset arrivalDateTime)
        {
            if(arrivalDateTime.DayOfWeek < DateTimeOffset.Now.DayOfWeek)
            {
                throw new ArgumentException("Not possible to book in the past");
            };
        }
    }
}