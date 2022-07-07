using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.ViewModel.ReservationViewModel;


namespace ReservationSystem.Core.ViewModel
{
    internal class ReservationCollectionViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationModel> _reservations;
        private readonly ReservationsClient _reservationsClient;
        public ObservableCollection<ReservationModel> Reservations => _reservations;
        
        private string _selected { get; set; }
        public string Selected
        {
            get { return _selected; }
            set { 
                _selected = value; 
                OnPropertyChanged(nameof(Selected));
                
                }
        }
        

        public ReservationCollectionViewModel()
        {
            _reservations = new ObservableCollection<ReservationModel>();

            var ReservationModelOne = new ReservationModel()
            {
                ReservationId = 1,
                FirstName = "Henk",
                LastName = "Bembom",
                PrefixName = "",
                StreetName = "Laan v/d Bork",
                LicensePlateName = "1234",
                ArrivalDate = DateTime.UtcNow.Date,
                DepartureDate = DateTime.UtcNow.Date,
            };
            var ReservationModelTwo = new ReservationModel()
            {
                ReservationId = 1,
                FirstName = "Jo",
                LastName = "Bro",
                PrefixName = "",
                StreetName = "Laan v/d Bork",
                LicensePlateName = "1234",
                ArrivalDate = DateTime.UtcNow.Date,
                DepartureDate = DateTime.UtcNow.Date,
            };
            _reservations.Add(ReservationModelOne);
            _reservations.Add(ReservationModelTwo);
        }
    }
}
