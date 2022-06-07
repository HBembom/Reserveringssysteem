﻿using ReservationSystem.Core.Model;
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
    public sealed partial class MainPage : Page
    {

         Core.Model.OccupancyOverview.OccupancyOverview occupancy;
        Reservation reservation = new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(0),
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
             //new Camper(4),
             //new Camper(5),
            };

            List<Reservation> Reservations = new List<Reservation>()
            {
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
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
                reservation
                //new Reservation(
                //    new DurationOfStay(
                //        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(4),
                //        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(6)),
                //    new List<Accomodation>(){ new Camper(1)},
                //    new GuestContactDetail(
                //        new Model.Names.FirstName("harry"),
                //        new Model.Names.LastName("Arkes"),
                //        new Model.Names.PrefixName(""),
                //        new Model.Names.StreetName("laan v/d bork"),
                //        new LicensePlateName("blabla")),
                //    new List<Guest>())


            };

            occupancy = new Core.Model.OccupancyOverview.OccupancyOverview(Accomodations, Reservations, new Grid(), new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day));

            this.InitializeComponent();
            this.Content = occupancy.Draw();
            
        }
    }
}
