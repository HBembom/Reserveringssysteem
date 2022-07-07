using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.View;
using ReservationSystem.Core.ViewModel.ReservationViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            set
            {
                _selectedReservationModel = value;

                ((Frame)Window.Current.Content).Navigate(typeof(ReservationDetail), _selectedReservationModel.ReservationId);
            }
        }

        public ICommand ViewReservationCommand;

        public ReservationCollectionViewModel()
        {
            ViewReservationCommand = new ViewReservationCommand(this);
            _reservationsClient = new ReservationsClient();
            _reservations = new List<ReservationModel>();

            List<ReservationModel> list = new List<ReservationModel>();

            var reservations = Task.Run(async () =>
            {
                list = await _reservationsClient.GetAll();
            });
            reservations.Wait();

            foreach(ReservationModel reservation in list)
            {
                _reservations.Add(reservation);
            }
        }
    }
}
