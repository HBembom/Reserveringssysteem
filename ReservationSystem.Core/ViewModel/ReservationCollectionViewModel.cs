using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Commands;

namespace ReservationSystem.Core.ViewModel
{
    internal class ReservationCollectionViewModel : ViewModelBase
    {
        private readonly List<ReservationModel> _reservations;
        private ReservationsClient _reservationsClient;
        public List<ReservationModel> Reservations => _reservations;

        public ReservationModel _selectedReservationModel { get; set; }
        public ReservationModel SelectedReservationModel
        {
            get { return _selectedReservationModel; }
            set { _selectedReservationModel = value;  ViewReservationCommand.Execute(null); }
        }

        public ICommand ViewReservationCommand;

        public ReservationCollectionViewModel()
        {
            ViewReservationCommand = new ViewReservationCommand(this);
            _reservationsClient = new ReservationsClient();
            _reservations = new List<ReservationModel>();

            List<ReservationModel> list = new List<ReservationModel>();

            var reservationsTask = Task.Run(async () =>
            {
                list = await _reservationsClient.GetAll();
            });
            reservationsTask.Wait();

            foreach(ReservationModel reservation in list)
            {
                _reservations.Add(reservation);
            }
        }
    }
}
