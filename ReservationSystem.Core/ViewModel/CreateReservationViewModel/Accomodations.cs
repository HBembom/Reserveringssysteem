using ReservationSystem.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReservationSystem.Core.Clients;

namespace ReservationSystem.Core.ViewModel
{
    internal class Accomodations : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AccommodationClient _accommodationClient;

        private List<Accomodation> _accomdations;
        public List<Accomodation> AccomodationsList
        {
            get { return _accomdations; }
            set { _accomdations = value; OnPropertyChanged(nameof(AccomodationsList)); }
        }

        private List<string> _selectableAccomodations;
        public List<string> SelectableAccomodations
        {
            get { return _selectableAccomodations; }
            set { _selectableAccomodations = value; OnPropertyChanged(nameof(SelectableAccomodations)); }
        }

        private DateTimeOffset _arrivalDateTime;
        public DateTimeOffset ArrivalDateTime
        {
            get { return _arrivalDateTime; }
            set { _arrivalDateTime = value; OnPropertyChanged(nameof(ArrivalDateTime)); }
        }
        private DateTimeOffset _departureDateTime;

        public DateTimeOffset DepartureDateTime
        {
            get { return _departureDateTime; }
            set { _departureDateTime = value; OnPropertyChanged(nameof(DepartureDateTime)); }
        }

        private string _selectedAccomodation;
        public string SelectedAccomodation
        {
            get { return _selectedAccomodation; }
            set { _selectedAccomodation = value; OnPropertyChanged(nameof(SelectedAccomodation)); }
        }

        private int _selectedPitchNumber;
        public int SelectedPitchNumber
        {
            get { return _selectedPitchNumber; }
            set { _selectedPitchNumber = value; OnPropertyChanged(nameof(SelectedPitchNumber)); }
        }

        private List<AccommodationModel> _accommodationList;
       
        protected List<int> _availableAccommodations;
        public List<int> AvailableAccommodations
        {
            get { return _availableAccommodations; }
            set { _availableAccommodations = value; OnPropertyChanged(nameof(_availableAccommodations)); }
        }

        public Accomodations()
        {
            _accommodationClient = new AccommodationClient();
            this._arrivalDateTime = DateTimeOffset.Now;
            this._departureDateTime = DateTimeOffset.Now.AddDays(1);
            this.AccomodationsList = new List<Accomodation>();
            this.SelectableAccomodations = new List<string>()
            {
                "Camper"
            };
            AvailableAccommodations = new List<int>();
            _accommodationList = new List<AccommodationModel>();
            SetAvailableAccommodationsTask();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private void SetAvailableAccommodationsTask()
        {
            var task = Task.Run(async () =>
            {
                _accommodationList = await _accommodationClient.GetAll();
            });
            task.Wait();
            for (var i = 0; i < _accommodationList.Count; i++)
            {
                this.AvailableAccommodations.Add(_accommodationList[i].AccommodationId);
            }
        }
    }
}