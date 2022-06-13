using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using ReservationSystem.Core.ViewModel;

namespace ReservationSystem.Core.Commands
{
    internal class GetPreviousWeekCommand : CommandBase
    {
        private VisualOccupancyOverviewViewModel _viewModel;
        public GetPreviousWeekCommand(VisualOccupancyOverviewViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.overview = new OccupancyOverview(_viewModel._ammountOfAccomodations, _viewModel._reservations, _viewModel.DateTimeScopeStart.AddDays(-7));
            _viewModel.overview.Draw();
        }
    }
}
