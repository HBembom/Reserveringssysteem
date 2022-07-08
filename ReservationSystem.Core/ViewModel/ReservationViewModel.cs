using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel.ReservationViewModel
{
    internal class ReservationViewModel : ViewModelBase
    {
        public readonly ReservationModel _reservation;

        public string GuestFirstName => _reservation.FirstName;
        public string ArrivalDate => _reservation.ArrivalDate.ToString("d");
        public string DepartureDate => _reservation.DepartureDate.ToString("d");
        public int ReservationId => _reservation.ReservationId;
        public string GuestLastName => _reservation.LastName;
        public string PrefixName => _reservation.PrefixName;
        public string StreetName => _reservation.StreetName;
        public string LicensePlateName => _reservation.LicensePlateName;
        public string[] AccommodationId => _reservation.AccommodationId;
        public int AmountOfExtraAdults => _reservation.AmountOfExtraAdults;
        public int AmountOfExtraChildren => _reservation.AmountOfExtraChildren;
        public int AmountOfExtraPets => _reservation.AmountOfExtraPets;
        public double TotalCost => _reservation.TotalCost;
        public bool PaymentStatus => _reservation.PaymentStatus;
        public ICommand EditReservationCommand { get; set; }
        public ReservationViewModel(ReservationModel reservation)
        {
            _reservation = reservation;
            EditReservationCommand = new EditReservationCommand(reservation);
        }
    }
}