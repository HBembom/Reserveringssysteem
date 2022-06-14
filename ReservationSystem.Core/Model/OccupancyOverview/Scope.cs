using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview
{
    public class Scope
        {
        public readonly DateTimeColumnSpan MinDateTimeColumnSpan;
        public readonly DateTimeColumnSpan MaxDateTimeColumnSpan;
        public readonly List<DateTimeColumnSpan> DateTimeColumnSpans;
        private Grid _grid;

        public Scope(List<DateTimeColumnSpan> dateTimeColumnSpans, Grid _grid)
        {
            this._grid = _grid;
            this.DateTimeColumnSpans = dateTimeColumnSpans;
            this.MinDateTimeColumnSpan = GetMinimumColumnSpan();
            this.MaxDateTimeColumnSpan = GetMaximumColumnSpan();
        }

        private DateTimeColumnSpan GetMinimumColumnSpan()
        {
            int minColumn = _grid.ColumnDefinitions.Count;
            DateTimeColumnSpan span = new DateTimeColumnSpan(DateTime.Now, 0);

            foreach (DateTimeColumnSpan ColumnSpan in DateTimeColumnSpans)
            {
                if (ColumnSpan.ColumnNumber < minColumn)
                {
                    minColumn = ColumnSpan.ColumnNumber;
                    span = ColumnSpan;
                }
            }

            return span;
        }

        private DateTimeColumnSpan GetMaximumColumnSpan()
        {
            int minColumn = 0;
            DateTimeColumnSpan span = new DateTimeColumnSpan(DateTime.Now, 0);

            foreach (DateTimeColumnSpan ColumnSpan in DateTimeColumnSpans)
            {
                if (ColumnSpan.ColumnNumber > minColumn)
                {
                    minColumn = ColumnSpan.ColumnNumber;
                    span = ColumnSpan;
                }
            }

            return span;
        }
    }
}