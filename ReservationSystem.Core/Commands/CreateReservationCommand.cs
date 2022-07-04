using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.Guests;
using ReservationSystem.Core.Model.Names;
using ReservationSystem.Core.ViewModel;

namespace ReservationSystem.Core.Commands
{
    internal class CreateReservationCommand : CommandBase
    {
        readonly CreateReservationViewModel CreateReservation;
        readonly ReservationsClient ReservationClient;

        public CreateReservationCommand(CreateReservationViewModel createReservation)
        {
            this.CreateReservation = createReservation;
            this.ReservationClient = new ReservationsClient();
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

            if(CreateReservation.HasPaid)
            {
                reservation.hasPaid.Paid();
            }

            // Send Reservation to database
            var postReservationTask = Task.Run(() =>
            {
                PostReservation(reservation);
            });
            postReservationTask.Wait();
            // Open New Screen
            var rootFrame = Window.Current.Content as Frame;
            
            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(HomePage));
            }
        }

        private async void PostReservation(Reservation reservation)
        {
            var reservationModel = new ReservationModel();
            var list = new List<string>();
            foreach (var res in reservation.Accomodations)
            {
                list.Add(res.ID.value.ToString());
            }

            reservationModel.FirstName = reservation.ContactDetail.FirstName.value;
            reservationModel.LastName = reservation.ContactDetail.LastName.value;
            reservationModel.PrefixName = reservation.ContactDetail.PrefixName.value;
            reservationModel.StreetName = reservation.ContactDetail.StreetName.value;
            reservationModel.LicensePlateName = reservation.ContactDetail.LicensePlate.value;
            reservationModel.ArrivalDate = reservation.DurationOfStay.ArrivalDateTime;
            reservationModel.DepartureDate = reservation.DurationOfStay.DepartureDateTime;
            reservationModel.AccommodationId = list.ToArray();
            var adults = 0;
            var children = 0;
            var pets = 0;
            foreach (var guest in reservation.Occupancy)
            {
                if (guest.GetType() == typeof(Adult))
                {
                    adults++;
                }

                if (guest.GetType() == typeof(Child))
                {
                    children++;
                }

                if (guest.GetType() == typeof(Pet))
                {
                    pets++;
                }
            }
            reservationModel.AmountOfExtraAdults = adults;
            reservationModel.AmountOfExtraChildren = children;
            reservationModel.AmountOfExtraPets = pets;
            reservationModel.TotalCost = reservation.PriceStructure.TotalPrice.Value;
            reservationModel.PaymentStatus = reservation.hasPaid.GetStatus();

            await ReservationClient.Post(reservationModel);
        }
    }
}