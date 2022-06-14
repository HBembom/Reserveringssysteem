using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    internal class AssignPitchGrid : IAssignElement
    {
        private Grid _grid;

        public AssignPitchGrid(Grid grid)
        {
            this._grid = grid;
        }

        public void AddElement(int row, int column)
        {
            TextBlock textBlockOne = new TextBlock()
            {
                Text = "PitchNumber",
                TextAlignment = TextAlignment.Center,
                FontSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(textBlockOne, column);
            Grid.SetRow(textBlockOne, row);
            _grid.Children.Add(textBlockOne);
        }
    }
}