using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    public class GridElementAssigner
    {
        private int _amountOfRows;
        private int _amountOfColumns;
        public readonly List<DateTimeColumnSpan> DateTimeColumnSpans;
        private AssignReservationGrid _assignReservationGrid;
        private AssignDateTimeGrid _assignDateTimeGrid;
        private AssignPitchIndexGrid _assignPitchIndexGrid;
        private AssignEmptyGrid _assignEmptyGrid;
        private AssignPitchGrid _assignPitchGrid;

        public GridElementAssigner(Grid grid, DateTime currentTime, List<Reservation> reservation)
        {
            this._assignDateTimeGrid = new AssignDateTimeGrid(grid, currentTime);
            this._assignEmptyGrid = new AssignEmptyGrid(grid);
            this._assignPitchGrid = new AssignPitchGrid(grid);
            this._assignPitchIndexGrid = new AssignPitchIndexGrid(grid);
            this._amountOfRows = grid.RowDefinitions.Count;
            this._amountOfColumns = grid.ColumnDefinitions.Count;     
            AddElements();
            this._assignReservationGrid = new AssignReservationGrid(grid, reservation, new Scope(_assignDateTimeGrid.GetDateTimeColumnSpans(), grid));
            _assignReservationGrid.AssignReservations();
        }

        public void AddElements()
        {
            for (int row = 0; row < _amountOfRows; row++)
            {
                for (int column = 0; column < _amountOfColumns; column++)
                {
                    if (row == 0 && column == 0)
                    {
                        _assignPitchGrid.AddElement(row, column);
                    }
                    if (row == 0)
                    {
                        _assignDateTimeGrid.AddElement(row, column);
                        column += 1;
                    }
                    if (row > 0 && column == 0)
                    {
                        _assignPitchIndexGrid.AddElement(row, column);
                    }
                    if (row > 0 && column > 0)
                    {
                        _assignEmptyGrid.AddElement(row, column);
                    }
                }
            }
        }
    }
}
