using System;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    public class DateTimeColumnSpan
    {
        public readonly int ColumnNumber;
        public readonly DateTime DateTime;
        public DateTimeColumnSpan(DateTime dateTime, int columnNumber)
        {
            this.DateTime = dateTime;
            this.ColumnNumber = columnNumber;
        }
    }
}