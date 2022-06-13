using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview
{
    internal class ArrivalAndDepartureAreOutsideScopeStrategy : IAssignElement
    {
        private Grid _grid;
        private Reservation _reservation;

        public ArrivalAndDepartureAreOutsideScopeStrategy(Grid grid, Reservation reservation)
        {
            this._grid = grid;
            this._reservation = reservation;
        }

        public void AddElement(int row, int column)
        {
            if (_reservation.hasPaid.GetStatus() == false)
            {
                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(Colors.Red),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Grid.SetColumn(rextangleTwo, 1);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, column);
                _grid.Children.Add(rextangleTwo);
            }
            else
            {
                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(Colors.Green),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Grid.SetColumn(rextangleTwo, 1);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, column);
                _grid.Children.Add(rextangleTwo);
            }

            TextBlock textBlockTwo = new TextBlock()
            {
                Text = _reservation.ContactDetail.LastName.value,
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(textBlockTwo, 1);
            Grid.SetRow(textBlockTwo, row);
            Grid.SetColumnSpan(textBlockTwo, column);
            _grid.Children.Add(textBlockTwo);
        }
    }
}