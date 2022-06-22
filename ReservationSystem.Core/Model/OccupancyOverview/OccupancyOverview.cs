using ReservationSystem.Core.Model.Names;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    namespace ReservationSystem.Core.Model.OccupancyOverview
    {
        public class OccupancyOverview
        {
            public Grid _grid;

            public OccupancyOverview(DateTime selectedWeek)
            {
                // Need Api Calls for Accomodations amount and Reservations

                _grid = new GridGenerator(RetrieveAccomodations()).CreateGrid();
                _grid = new GridElementAssigner(_grid, selectedWeek, RetrieveReservations()).AssignElements();
            }

            public Grid Draw()
            {
                return _grid;
            }

            public void Update(DateTime indexDateTime)
            {
                _grid = new Grid();
                _grid = new GridGenerator(RetrieveAccomodations()).CreateGrid();
                _grid = new GridElementAssigner(_grid, indexDateTime, RetrieveReservations()).AssignElements();
            }

            // Hardcoded for fast testing purposes

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
                        new FirstName("harry"),
                        new LastName("Kosse"),
                        new PrefixName(""),
                        new StreetName("laan v/d bork"),
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
                        new FirstName("Henk"),
                        new LastName("Bembom"),
                        new PrefixName(""),
                        new StreetName("Laan v/d Bork"),
                        new LicensePlateName("BlaBla")),
                    new List<Guest>()
                    ),
                new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(5)),
                    new List<Accomodation>() { new Camper(4) },
                    new GuestContactDetail(
                        new FirstName("harry"),
                        new LastName("Leuw"),
                        new PrefixName(""),
                        new StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(2)),
                    new List<Accomodation>() { new Camper(5) },
                    new GuestContactDetail(
                        new FirstName("harry"),
                        new LastName("Pipo"),
                        new PrefixName(""),
                        new StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(-1),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(8)),
                    new List<Accomodation>() { new Camper(6) },
                    new GuestContactDetail(
                        new FirstName("harry"),
                        new LastName("Buzz"),
                        new PrefixName(""),
                        new StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>()),
                 new Reservation(
                    new DurationOfStay(
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(5),
                        new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).AddDays(8)),
                    new List<Accomodation>() { new Camper(7) },
                    new GuestContactDetail(
                        new FirstName("harry"),
                        new LastName("Woody"),
                        new PrefixName(""),
                        new StreetName("laan v/d bork"),
                        new LicensePlateName("blabla")),
                    new List<Guest>())
            };
            }
        }
    }
}
