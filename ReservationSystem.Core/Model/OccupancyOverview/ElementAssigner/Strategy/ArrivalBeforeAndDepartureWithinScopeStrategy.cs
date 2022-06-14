using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview
{
    internal class ArrivalBeforeAndDepartureWithinScopeStrategy : IAssignElement
    {
        private Grid _grid;
        private Reservation _reservation;
        private Scope _scope;

        public ArrivalBeforeAndDepartureWithinScopeStrategy(Grid grid, Reservation reservation, Scope scope)
        {
            _grid = grid;
            _reservation = reservation;
            _scope = scope;
        }

        public void AddElement(int row, int column)
        {
            DateTimeColumnSpan minimumScopeDateTime = _scope.MinDateTimeColumnSpan;
            DateTime departureTime = _reservation.DurationOfStay.DepartureDateTime;
            int totalDays = (departureTime - minimumScopeDateTime.DateTime).Days * 2 + 1;

            if (_reservation.hasPaid.GetStatus() == false)
            {
                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(Colors.Red),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Grid.SetColumn(rextangleTwo, column);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, totalDays);
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
                Grid.SetColumn(rextangleTwo, column);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, totalDays);
                _grid.Children.Add(rextangleTwo);
            }

            TextBlock textBlockTwo = new TextBlock()
            {
                Text = _reservation.ContactDetail.LastName.value,
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(textBlockTwo, column);
            Grid.SetRow(textBlockTwo, row);
            Grid.SetColumnSpan(textBlockTwo, totalDays);
            _grid.Children.Add(textBlockTwo);
        }
    }
}