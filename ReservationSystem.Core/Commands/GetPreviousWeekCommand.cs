using ReservationSystem.Core.ViewModel;

namespace ReservationSystem.Core.Commands
{
    internal class GetPreviousWeekCommand : CommandBase
    {
        private PlanningBoardViewModel _viewModel;
        public GetPreviousWeekCommand(PlanningBoardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            
        }
    }
}
