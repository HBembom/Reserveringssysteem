using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class PlanningBoardViewModel : ViewModelBase
    {
        public readonly OccupancyOverview overview;

        private DateTime _dateTimeScopeStart;
        public DateTime DateTimeScopeStart
        {
            get { return _dateTimeScopeStart; }
            set { _dateTimeScopeStart = value; OnPropertyChanged(nameof(DateTimeScopeStart)); }
        }
        public ICommand GetNextWeekCommand { get; set; }
        public ICommand GetPreviousWeekCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand ViewReservationCommand { get; set; }

        public PlanningBoardViewModel()
        {
            this.GetNextWeekCommand = new GetNextWeekCommand(this);
            this.GetPreviousWeekCommand = new GetPreviousWeekCommand(this);
            this.DateTimeScopeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            this.overview = new OccupancyOverview(_dateTimeScopeStart);
        }
    }
}
