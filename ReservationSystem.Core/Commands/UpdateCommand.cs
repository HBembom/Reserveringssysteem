using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationSystem.Core.Commands;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Model.Guests;
using ReservationSystem.Core.View;

namespace ReservationSystem.Core.ViewModel
{
    internal class UpdateCommand : CommandBase
    {
        public EditReservationViewModel ViewModel { get; }
        private ReservationsClient _client { get; }
        public UpdateCommand(EditReservationViewModel viewModel)
        {
            ViewModel = viewModel;
            _client = new ReservationsClient();
        }

        public override void Execute(object parameter)
        {
            // Insert Update Code
            var accommodationsIds = new List<string>();
            for(var i = 0; i < ViewModel.Accomodations.AccomodationsList.Count; i++)
            {
                accommodationsIds.Add(ViewModel.Accomodations.AccomodationsList[i].ID.value.ToString());
            }

            var updateReservationTask = Task.Run(async () =>
            {
                var reservationModel = new ReservationModel()
                {
                    AccommodationId = accommodationsIds.ToArray(),
                    AmountOfExtraAdults = ViewModel.PriceStructure.NumberOfAdults,
                    AmountOfExtraChildren = ViewModel.PriceStructure.NumberOfChilds,
                    AmountOfExtraPets = ViewModel.PriceStructure.NumberOfPets,
                    ArrivalDate = ViewModel.Accomodations.ArrivalDateTime,
                    DepartureDate = ViewModel.Accomodations.DepartureDateTime,
                    FirstName = ViewModel.GuestInformation.FirstName,
                    LastName = ViewModel.GuestInformation.LastName,
                    PrefixName = ViewModel.GuestInformation.PrefixName,
                    LicensePlateName = ViewModel.GuestInformation.LicensePlate,
                    StreetName = ViewModel.GuestInformation.StreetName,
                    TotalCost = ViewModel.PriceStructure.TotalPrice,
                    PaymentStatus = ViewModel.HasPaid

                };
                await _client.Put(ViewModel.ReservationId, reservationModel);
            });
            var rootFrame = new Frame();
            Window.Current.Content = rootFrame;

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(HomePage), null);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
}