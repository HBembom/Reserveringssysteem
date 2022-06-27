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
        private int _rows;
        private int _columns;
        private AssignReservationGrid _assignReservationGrid;
        private AssignDateTimeGrid _assignDateTimeGrid;
        private AssignPitchIndexGrid _assignPitchIndexGrid;
        private AssignEmptyGrid _assignEmptyGrid;
        private AssignPitchGrid _assignPitchGrid;
        private Grid _grid;
        private List<Reservation> _reservations;

        public GridElementAssigner(Grid grid, DateTime currentTime, List<Reservation> reservation)
        {
            this._grid = grid;
            this._reservations = reservation;
            this._assignDateTimeGrid = new AssignDateTimeGrid(_grid, currentTime);
            this._assignEmptyGrid = new AssignEmptyGrid(_grid);
            this._assignPitchGrid = new AssignPitchGrid(_grid);
            this._assignPitchIndexGrid = new AssignPitchIndexGrid(_grid);
            this._rows = _grid.RowDefinitions.Count;
            this._columns = _grid.ColumnDefinitions.Count;     
        }

        public Grid AssignElements()
        {
            AddElements();
            this._assignReservationGrid = new AssignReservationGrid(_grid, _reservations, new Scope(_assignDateTimeGrid.GetDateTimeColumnSpans(), _grid));
            _assignReservationGrid.AssignReservations();

            return _grid;
        }


        private void AddElements()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
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
