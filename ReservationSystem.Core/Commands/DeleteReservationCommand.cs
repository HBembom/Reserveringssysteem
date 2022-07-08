using ReservationSystem.Core.Clients;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Commands
{
    internal class DeleteReservationCommand : CommandBase
    {
        private readonly ReservationModel _viewModel;
        private readonly ReservationsClient _client;

        public DeleteReservationCommand(ReservationModel viewModel)
        {
            _viewModel = viewModel;
            _client = new ReservationsClient();
        }
        public override async void Execute(object parameter)
        {
            await _client.Delete(_viewModel.ReservationId);

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
