using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Commands
{
    internal class GetNextWeekCommand : CommandBase
    {
        private PlanningBoardViewModel _viewModel;
        public GetNextWeekCommand(PlanningBoardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.DateTimeScopeStart = _viewModel.DateTimeScopeStart.AddDays(7);
            _viewModel.overview.Update(_viewModel.DateTimeScopeStart);   
        }
    }
}
