using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReservationSystem.Core.Clients;
using Guest = ReservationSystem.Core.Model.Guest;
using Reservation = ReservationSystem.Core.Model.Reservation;

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

        private int accomodationsAmount;
       
        public MainPage()
        {
            this.InitializeComponent();
            reservation.hasPaid.Paid();
            var ReservationsAmount = Cache.ReservationModels;

            List<Accomodation> Accomodations = new List<Accomodation>();
            for (var i = 0; i < Cache.AccommodationModels.Count; i++)
            {
                Accomodations.Add(new Camper(Cache.AccommodationModels[i].AccommodationId));
            }

            List<Reservation> Reservations = new List<Reservation>();


            for (var i = 0; i < Cache.ReservationModels.Count; i++)
            {
                Reservations.Add(new Reservation(
                    new DurationOfStay(
                        new DateTime(Cache.ReservationModels[i].ArrivalDate.Year, Cache.ReservationModels[i].ArrivalDate.Month, Cache.ReservationModels[i].ArrivalDate.Day),
                        new DateTime(Cache.ReservationModels[i].DepartureDate.Year, Cache.ReservationModels[i].DepartureDate.Month, Cache.ReservationModels[i].DepartureDate.Day)),
                    new List<Accomodation>() { new Camper(Cache.ReservationModels[i].AccommodationId[0]) },
                    new GuestContactDetail(
                        new Model.Names.FirstName(Cache.ReservationModels[i].FirstName),
                        new Model.Names.LastName(Cache.ReservationModels[i].LastName),
                        new Model.Names.PrefixName(Cache.ReservationModels[i].PrefixName),
                        new Model.Names.StreetName(Cache.ReservationModels[i].StreetName),
                        new LicensePlateName(Cache.ReservationModels[i].LicensePlateName)),
                    new List<Guest>()
                ));
            }
            Reservations.Add(reservation);

            occupancyOverview = new OccupancyOverview(Accomodations.Count, Reservations, new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day));
            this.Content = occupancyOverview.Draw();
        }

        private void SetReservations(List<Reservation> Reservations)
        {
            
        }
    }
}
