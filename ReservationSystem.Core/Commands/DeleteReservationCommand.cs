using ReservationSystem.Core.Clients;
using ReservationSystem.Core.View;
using ReservationSystem.Core.ViewModel.ReservationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
        public override async void Execute(object parameter)
        {
            _client.Delete(_viewModel.ReservationId);

            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(HomePage));
            }

        }
    }
}
