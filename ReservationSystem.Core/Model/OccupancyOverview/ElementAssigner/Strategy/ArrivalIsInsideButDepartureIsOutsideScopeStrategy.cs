using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview
{
    internal class ArrivalIsInsideButDepartureIsOutsideScopeStrategy : IAssignElement
    {
        private Grid _grid;
        private Reservation _reservation;
        private Scope _scope;

        public ArrivalIsInsideButDepartureIsOutsideScopeStrategy(Grid grid, Reservation reservation, Scope scope)
        {
            this._grid = grid;
            this._reservation = reservation;
            this._scope = scope;
        }

        public void AddElement(int row, int column)
        {
            DateTimeColumnSpan dateTimeIndex = GetDateTimeIndex(_reservation);
            DateTimeColumnSpan maxDateTimeColumnSpan = _scope.MaxDateTimeColumnSpan;

            int ammountOfNights = (maxDateTimeColumnSpan.DateTime - dateTimeIndex.DateTime).Days * 2;

            if (ammountOfNights == 0)
            {
                ammountOfNights = 1;
            }

            if (_reservation.hasPaid.GetStatus() == false)
            {
                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 2,
                    Fill = new SolidColorBrush(Colors.Red),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
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
                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                Grid.SetRow(rextangleTwo, row);
                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
                _grid.Children.Add(rextangleTwo);
            }

            TextBlock textBlockTwo = new TextBlock()
            {
                Text = _reservation.ContactDetail.LastName.value,
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(textBlockTwo, dateTimeIndex.ColumnNumber);
            Grid.SetRow(textBlockTwo, row);
            Grid.SetColumnSpan(textBlockTwo, ammountOfNights);
            _grid.Children.Add(textBlockTwo);
        }

        private DateTimeColumnSpan GetDateTimeIndex(Reservation reservation)
        {
            DateTimeColumnSpan span = _scope.MinDateTimeColumnSpan;

            foreach (DateTimeColumnSpan dateTime in _scope.DateTimeColumnSpans)
            {
                if (dateTime.DateTime == reservation.DurationOfStay.ArrivalDateTime)
                {
                    span = dateTime;
                }
            }

            return span;
        }
    }
}