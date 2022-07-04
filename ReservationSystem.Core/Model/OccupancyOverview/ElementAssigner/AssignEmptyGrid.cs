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
    internal class AssignEmptyGrid : IAssignElement
    {
        private Grid _grid;

        public AssignEmptyGrid(Grid grid)
        {
            this._grid = grid;
        }

        public void AddElement(int row, int column)
        {
            Windows.UI.Xaml.Shapes.Rectangle rextangle = new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0, 5, 0, 5)
            };
            Grid.SetColumn(rextangle, column);
            Grid.SetRow(rextangle, row);
            _grid.Children.Add(rextangle);

            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            _grid.Children.Add(textBlock);
        }
    }
}
 