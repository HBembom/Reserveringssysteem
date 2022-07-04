using ReservationSystem.Core.Commands;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class UpdateCommand : CommandBase
    {
        public UpdateCommand(EditReservationViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public EditReservationViewModel ViewModel { get; }

        public override void Execute(object parameter)
        {
            
        }
    }
}