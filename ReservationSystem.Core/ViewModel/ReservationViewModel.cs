using ReservationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.ViewModel.ReservationViewModel
{
    internal class ReservationViewModel : ViewModelBase
    {
        private readonly Clients.ReservationModel _reservation;

        public string GuestFirstName => _reservation.LastName.ToString();
        public string ArrivalDate => _reservation.ArrivalDate.ToString();
        public string DepartureDate => _reservation.DepartureDate.ToString();

        public ReservationViewModel(Clients.ReservationModel reservation)
        {
            _reservation = reservation;
        }
    }
}
