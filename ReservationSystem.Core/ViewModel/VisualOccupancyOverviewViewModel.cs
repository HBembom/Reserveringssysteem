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
    internal class VisualOccupancyOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public OccupancyOverview overview;
        public int _ammountOfAccomodations;
        public List<Reservation> _reservations;
        public readonly Page page;

        public ICommand GetNextWeekCommand { get; set; }
        public ICommand GetPreviousWeekCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }
        public ICommand ViewReservationCommand { get; set; }

        private DateTime _dateTimeScopeStart;
        public DateTime DateTimeScopeStart
        {
            get { return _dateTimeScopeStart; }
            set { _dateTimeScopeStart = value; OnPropertyChanged(nameof(DateTimeScopeStart)); }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public VisualOccupancyOverviewViewModel(Page page)
        {
            this.GetNextWeekCommand = new GetNextWeekCommand(this);
            this._ammountOfAccomodations = RetrieveAccomodations();
            this._reservations = new List<Reservation>();
            this.DateTimeScopeStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            this._reservations = RetrieveReservations();
            this.overview = new OccupancyOverview(_ammountOfAccomodations, _reservations, _dateTimeScopeStart);
            this.page = page;
            page.Content = overview.Draw();
        }

        private int RetrieveAccomodations()
        {
            return 8;
        }

        private List<Reservation> RetrieveReservations()
        {
            return new List<Reservation>()
            { new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-2),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(0)),
                    new List<Accomodation>() { new Camper(2) },
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Kosse"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()
                    ),
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(1)),
                    new List<Accomodation>()
                    {
                        new Camper(1),
                        new Camper(3)
                    },
                    new GuestContactDetail(
                        new Model.Names.FirstName("Henk"),
                        new Model.Names.LastName("Bembom"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("Laan v/d Bork"),
                        new LicensePlateName("BlaBla")),
                    new List<Guest>()
                    ),
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(5)),
                    new List<Accomodation>() { new Camper(4) },
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Leuw"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(2)),
                    new List<Accomodation>() { new Camper(5) },
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Pipo"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(8)),
                    new List<Accomodation>() { new Camper(6) },
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Buzz"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(5),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(8)),
                    new List<Accomodation>() { new Camper(7) },
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Woody"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()) 
            }; 
        }
    }
}
