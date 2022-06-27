using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.Names;
using ReservationSystem.Core.ViewModel;

namespace ReservationSystem.Core.Commands
{
    internal class CreateReservationCommand : CommandBase
    {
        readonly CreateReservationViewModel CreateReservation;
      
        public CreateReservationCommand(CreateReservationViewModel createReservation)
        {
            this.CreateReservation = createReservation;
        }
        public override void Execute(object parameter)
        {
            // Pass Fields to object first to insure integrity of Data
            Reservation reservation = new Reservation(
                new DurationOfStay(
                    CreateReservation.Accomodations.ArrivalDateTime, 
                    CreateReservation.Accomodations.DepartureDateTime),
                CreateReservation.Accomodations.AccomodationsList,
                new GuestContactDetail(
                    new FirstName(CreateReservation.GuestInformation.FirstName),
                    new LastName(CreateReservation.GuestInformation.LastName),
                    new PrefixName(CreateReservation.GuestInformation.PrefixName),
                    new StreetName(CreateReservation.GuestInformation.StreetName),
                    new LicensePlateName(CreateReservation.GuestInformation.LicensePlate)),
                CreateReservation.ExtraGuest.Guests);

            // Send Reservation to database
            // Open New Screen
        }
    }
}