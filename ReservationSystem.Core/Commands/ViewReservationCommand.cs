using ReservationSystem.Core.Clients;
using ReservationSystem.Core.View;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Commands
{
    internal class ViewReservationCommand : CommandBase
    {
        private ReservationCollectionViewModel _viewModel { get; set; }

        public ViewReservationCommand(ReservationCollectionViewModel viewmodel)
        {
            _viewModel = viewmodel;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
