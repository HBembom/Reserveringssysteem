using ReservationSystem.Core.Commands;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.ViewModel
{
    internal class UpdateCommand : CommandBase
    {
        public EditReservationViewModel ViewModel { get; }
        public UpdateCommand(EditReservationViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // Insert Update Code


            var rootFrame = Window.Current.Content as Frame;

            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(HomePage));
            }
        }
    }
}