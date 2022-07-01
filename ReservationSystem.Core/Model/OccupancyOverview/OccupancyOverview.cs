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
                return Cache.ReservationModels.Count;
            }

            private List<Reservation> RetrieveReservations()
            {
                List<Reservation> Reservations = new List<Reservation>();

                for (var i = 0; i < Cache.ReservationModels.Count; i++)
                {
                    Reservations.Add(new Reservation(
                        new DurationOfStay(
                            new DateTime(Cache.ReservationModels[i].ArrivalDate.Year, Cache.ReservationModels[i].ArrivalDate.Month, Cache.ReservationModels[i].ArrivalDate.Day),
                            new DateTime(Cache.ReservationModels[i].DepartureDate.Year, Cache.ReservationModels[i].DepartureDate.Month, Cache.ReservationModels[i].DepartureDate.Day)),
                        new List<Accomodation>() { new Camper(Cache.ReservationModels[i].AccommodationId[0]) },
                        new GuestContactDetail(
                            new FirstName(Cache.ReservationModels[i].FirstName),
                            new LastName(Cache.ReservationModels[i].LastName),
                            new PrefixName(Cache.ReservationModels[i].PrefixName),
                            new StreetName(Cache.ReservationModels[i].StreetName),
                            new LicensePlateName(Cache.ReservationModels[i].LicensePlateName)),
                        new List<Guest>()
                    ));
                }
                return Reservations;
            }
        }
    }
}
