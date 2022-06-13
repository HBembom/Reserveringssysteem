using System;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    public class DateTimeColumnSpan
    {
        public int ColumnNumber;
        public DateTime DateTime;
        public DateTimeColumnSpan(DateTime dateTime, int columnNumber)
        {
            this.DateTime = dateTime;
            this.ColumnNumber = columnNumber;
        }
    }
}