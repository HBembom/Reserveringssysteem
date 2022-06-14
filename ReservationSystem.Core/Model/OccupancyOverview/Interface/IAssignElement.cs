using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    internal interface IAssignElement
    {
        void AddElement(int row, int column);
    }
}
