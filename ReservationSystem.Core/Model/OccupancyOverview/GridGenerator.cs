using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    public class GridGenerator
    {
        private Grid _grid;
        private int _ammountOfAccomodations;

        public GridGenerator(int ammountOfAccomodations)
        {
            this._grid = new Grid();
            this._ammountOfAccomodations = ammountOfAccomodations;
        }

        public Grid CreateGrid()
        {
            CreateCollumns();
            CreateRows();

            return _grid;           
        }
        private void CreateCollumns()
        {
            for (int i = 0; i < 14; i++)
            {
                if (i == 0)
                {
                    _grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = new GridLength(75),
                    });
                }
                else
                {
                    _grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = new GridLength(100)
                    });
                }
            }
        }

        private void CreateRows()
        {
            for (int i = 0; i <= _ammountOfAccomodations; i++)
            {
                if (i == 0)
                {
                    _grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(50)
                    });
                }
                else
                {
                    _grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(40)
                    });
                }
            }
        }
    }
}