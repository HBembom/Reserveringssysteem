using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    internal class OccupancyOverview
    {
        public List<Accomodation> Accomodations;
        public List<Reservation> Reservations;
        public DateTime SelectedWeek;

        public OccupancyOverview(List<Accomodation> accomodations, List<Reservation> reservations)
        {
            

        }

        public void Draw()
        {
            CreateCollumns();
            CreateRows();
            CreateRectangles();
        }

        private void CreateRectangles()
        {
            OccupancyCanvas canvas = new OccupancyCanvas();

            foreach (Reservation reservation in Reservations)
            {
                Rect rect = new Rect();
            }
        }

        public void CreateCollumns()
        {
            for (int i = 0; i < 7; i++) ;
            {
                
            }
        }

        private void CreateRows()
        {
            for (int i = 0; i < Accomodations.Count; i++)
            {

            }
        }

        
    }
}
