using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    namespace ReservationSystem.Core.Model.OccupancyOverview
    {
        public class OccupancyOverview
        {
            public readonly Grid _grid;

            public OccupancyOverview(int accomodations, List<Reservation> reservations, DateTime selectedWeek)
            {
                _grid = new GridGenerator(accomodations).CreateGrid();
                _grid = new GridElementAssigner(_grid, selectedWeek, reservations).AssignElements();
            }

            public Grid Draw()
            {
                return _grid;
            }
        }
    }
}
