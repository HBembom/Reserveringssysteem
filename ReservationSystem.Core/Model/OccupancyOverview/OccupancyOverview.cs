namespace ReservationSystem.Core.Model.OccupancyOverview
{
    using System;
    using System.Collections.Generic;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    namespace ReservationSystem.Core.Model.OccupancyOverview
    {
        public class OccupancyOverview
        {
            public GridGenerator GridCreator;
            public AssignReservationGrid GridReservationAssigner;
            public GridElementAssigner GridAssigner;
            public Grid _grid;
            public Scope OccupancyScope;

            public OccupancyOverview(int accomodations, List<Reservation> reservations, DateTime selectedWeek)
            {
                this.GridCreator = new GridGenerator(accomodations);
                _grid = GridCreator.CreateGrid();
                this.GridAssigner = new GridElementAssigner(_grid, selectedWeek, reservations);
            }

            public Grid Draw()
            {
                return _grid;
            }
        }
    }

}
