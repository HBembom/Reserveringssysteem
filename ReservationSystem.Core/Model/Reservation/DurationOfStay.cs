using System;

namespace ReservationSystem.Core.Model
{
    public class DurationOfStay
    {
        public DateTime ArrivalDateTime;
        public DateTime DepartureDateTime;

        public DurationOfStay(DateTime arrivalDateTime, DateTime departureDateTime)
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

        private void NotNull(DateTime arrivalDateTime, DateTime departureDateTime)
        {
            if(arrivalDateTime.Equals(null) || departureDateTime.Equals(null))
            {
                throw new ArgumentException("You must select a Date");
            }
        }

        private void CheckIfDepartureIsLaterThanArrival(DateTime arrivalDateTime, DateTime departureDateTime)
        {
            if (departureDateTime < arrivalDateTime)
            {
                throw new ArgumentException("Not possible to book a departure before arrival");
            }
            
        }

        private void CheckIfArrivalIsPresentOrFuture(DateTime arrivalDateTime)
        {
            if(arrivalDateTime.DayOfWeek < DateTime.UtcNow.DayOfWeek)
            {
                throw new ArgumentException("Not possible to book in the past");
            };
        }
    }
}