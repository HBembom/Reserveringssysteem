using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    internal class AssignDateTimeGrid : IAssignElement
    {
        private Grid _grid;
        private DateTime _dateTime;
        private List<DateTimeColumnSpan> DateTimeColumnSpans;

        public AssignDateTimeGrid(Grid grid, DateTime currentTime)
        {
            this._grid = grid;
            this._dateTime = currentTime;
            this.DateTimeColumnSpans = new List<DateTimeColumnSpan>();
        }

        public void AddElement(int row, int column)
        {
            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                Text = _dateTime.ToString("dddd, dd MMMM yyyy")
            };

            Grid.SetColumn(textBlock, column + 1);
            Grid.SetRow(textBlock, row);
            Grid.SetColumnSpan(textBlock, 2);
            DateTimeColumnSpans.Add(new DateTimeColumnSpan(_dateTime, column + 2));
            _grid.Children.Add(textBlock);
            _dateTime = _dateTime.AddDays(1);
        }

        public List<DateTimeColumnSpan> GetDateTimeColumnSpans()
        {
            return this.DateTimeColumnSpans;
        }

    }
}
