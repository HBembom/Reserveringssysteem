using System;
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
        private Reservation _reservation;

        public CreateReservationCommand(CreateReservationViewModel createReservation)
        {
            this.CreateReservation = createReservation;
            this.ReservationClient = new ReservationsClient();
        }

        public override void Execute(object parameter)
        {

            //Check if reservation object is complete
            var reservationComplete = CheckReservation();

            if (reservationComplete)
            {
                // Send Reservation to database
                var postReservationTask = Task.Run(() =>
                {
                    PostReservation(_reservation);
                });
                postReservationTask.Wait();

                // Open New Screen
                var rootFrame = Window.Current.Content as Frame;

                if (rootFrame != null)
                {
                    rootFrame.Navigate(typeof(HomePage));
                }

                //set data new page
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

        private bool CheckReservation()
        {
            if (CreateReservation.Accomodations.AccomodationsList.Count == 0)
            {
                CreateReservation.ErrorMessage = "Please choose at least 1 Accommodation.";
                return false;
            }

            if (CreateReservation.GuestInformation.FirstName == null)
            {
                CreateReservation.ErrorMessage = "Please Fill in your first name to make a reservation.";
                return false;
            }

            if (CreateReservation.GuestInformation.LastName == null)
            {
                CreateReservation.ErrorMessage = "Please Fill in your last name to make a reservation.";
                return false;
            }

            if (CreateReservation.GuestInformation.PrefixName == null)
            {
                CreateReservation.ErrorMessage = "Please Fill in your prefix name to make a reservation.";
                return false;
            }

            if (CreateReservation.GuestInformation.StreetName == null)
            {
                CreateReservation.ErrorMessage = "Please Fill in your street name to make a reservation.";
                return false;
            }

            if (CreateReservation.GuestInformation.LicensePlate == null)
            {
                CreateReservation.ErrorMessage = "Please Fill in your license plate to make a reservation.";
                return false;
            }

            var reservationsList = new List<ReservationModel>();
            var accommodations = new List<int>();

            for (var i = 0; i < CreateReservation.Accomodations.AccomodationsList.Count; i++)
            {
                accommodations.Add(CreateReservation.Accomodations.AccomodationsList[i].ID.value);
            }
            var getReservationsTask = Task.Run(async () =>
            {
                reservationsList = await ReservationClient.GetByAccommodation(accommodations.ToArray(), $"{CreateReservation.Accomodations.ArrivalDateTime.Year}-{CreateReservation.Accomodations.ArrivalDateTime.Month}-{CreateReservation.Accomodations.ArrivalDateTime.Day}", $"{CreateReservation.Accomodations.DepartureDateTime.Year}-{CreateReservation.Accomodations.DepartureDateTime.Month}-{CreateReservation.Accomodations.DepartureDateTime.Day}");
            });
            getReservationsTask.Wait();

            if (reservationsList !=  null)
            {
                var accommodationString = "";
                for (var i = 0; i < accommodations.Count; i++)
                {
                    if (i == 0)
                    {
                        accommodationString += $"{accommodations[i]}";
                        continue;
                    }
                    accommodationString += $", {accommodations[i]}";
                }
                CreateReservation.ErrorMessage = $"Accommodations {accommodationString} are not available during your stay.{Environment.NewLine}Please choose different accommodations.";
                return false;
            }

            // Pass Fields to object first to insure integrity of Data
            _reservation = new Reservation(
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

            if (CreateReservation.HasPaid)
            {
                _reservation.hasPaid.Paid();
            }

            return true;
        }
    }
}