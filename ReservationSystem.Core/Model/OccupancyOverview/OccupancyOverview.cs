using ReservationSystem.Core.Model.Names;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ReservationSystem.Core.Clients;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    namespace ReservationSystem.Core.Model.OccupancyOverview
    {
        public class OccupancyOverview
        {
            public Grid _grid;
            private ReservationsClient _client;
            private List<ReservationModel> ReservationModels;

            public OccupancyOverview(DateTime selectedWeek)
            {
                _client = new ReservationsClient();
                ReservationModels = new List<ReservationModel>();

                var getReservationsTask = Task.Run(async () =>
                {
                    ReservationModels = await _client.GetAll();
                });
                getReservationsTask.Wait();

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

            private int RetrieveAccomodations()
            {
                return ReservationModels.Count;
            }

            private List<Reservation> RetrieveReservations()
            {
                List<Reservation> Reservations = new List<Reservation>();

                for (var i = 0; i < ReservationModels.Count; i++)
                {
                    Reservations.Add(new Reservation(
                        new DurationOfStay(
                            new DateTime(ReservationModels[i].ArrivalDate.Year, ReservationModels[i].ArrivalDate.Month, ReservationModels[i].ArrivalDate.Day),
                            new DateTime(ReservationModels[i].DepartureDate.Year, ReservationModels[i].DepartureDate.Month, ReservationModels[i].DepartureDate.Day)),
                        new List<Accomodation>() { new Camper(Int32.Parse(ReservationModels[i].AccommodationId[0])) },
                        new GuestContactDetail(
                            new FirstName(ReservationModels[i].FirstName),
                            new LastName(ReservationModels[i].LastName),
                            new PrefixName(ReservationModels[i].PrefixName),
                            new StreetName(ReservationModels[i].StreetName),
                            new LicensePlateName(ReservationModels[i].LicensePlateName)),
                        new List<Guest>()
                    ));
                }
                return Reservations;
            }
        }
    }
}
