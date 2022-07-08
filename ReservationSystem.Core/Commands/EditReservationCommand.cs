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
    internal class EditReservationCommand : CommandBase
    {
        private ReservationModel _viewModel;

        public EditReservationCommand(ReservationModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            Page page = new EditReservation(_viewModel);
            Window.Current.Content = page;
        }
    }
}
