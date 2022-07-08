using ReservationSystem.Core.View;
using ReservationSystem.Core.ViewModel;
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
            Page page = new ReservationDetail(_viewModel.SelectedReservationModel);
            Window.Current.Content = page;
        }
    }
}
