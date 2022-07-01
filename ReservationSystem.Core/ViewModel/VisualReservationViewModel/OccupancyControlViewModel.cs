using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.ViewModel
{
    internal class OccupancyOverviewUserControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public OccupancyOverviewUserControl()
        {
            this.GetNextWeekCommand = new GetNextWeekCommand(this);
            this.GetPreviousWeekCommand = new GetPreviousWeekCommand(this);
            this.DateTimeScopeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            this.overview = new OccupancyOverview(_dateTimeScopeStart);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
