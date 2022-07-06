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
        private readonly Reservation _reservation;

        public string GuestFirstName => _reservation.ContactDetail.LastName.ToString();
        public DateTime ArrivalDate => _reservation.DurationOfStay.ArrivalDateTime;
        public DateTime DepartureDate => _reservation.DurationOfStay.DepartureDateTime;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
