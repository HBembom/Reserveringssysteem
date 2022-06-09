using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReservationSystem.Core
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class MainPage : Page
    {
        public OccupancyOverview occupancyOverview;

        Reservation reservation = new Reservation(
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
                    );
        public MainPage()
        {
            reservation.hasPaid.Paid();
            List<Accomodation> Accomodations = new List<Accomodation>()
            {
              new Camper(1),
              new Camper(2),
              new Camper(3),
              new Camper(4),
              new Camper(5),
              new Camper(6),
              new Camper(7)
            };

            List<Reservation> Reservations = new List<Reservation>()
            {
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-2),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(0)),
                    new List<Accomodation>(){ new Camper(2)},
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Kosse"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()
                    ),
                reservation,
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(5)),
                    new List<Accomodation>(){ new Camper(4)},
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
                    new List<Accomodation>(){ new Camper(5)},
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
                    new List<Accomodation>(){ new Camper(6)},
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
                    new List<Accomodation>(){ new Camper(7)},
                    new GuestContactDetail(
                        new Model.Names.FirstName("harry"),
                        new Model.Names.LastName("Woody"),
                        new Model.Names.PrefixName(""),
                        new Model.Names.StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>())
            };

            occupancyOverview = new OccupancyOverview(Accomodations.Count, Reservations, new Grid(), new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day));

            this.InitializeComponent();
            this.Content = occupancyOverview.Draw();
            
        }
    }
}
