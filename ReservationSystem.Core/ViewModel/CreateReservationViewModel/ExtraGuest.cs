using ReservationSystem.Core.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReservationSystem.Core.ViewModel
{
    internal class ExtraGuest : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _numberOfNights;
        public int NumberOfNights
        {
            get { return _numberOfNights; }
            set { _numberOfNights = value; OnPropertyChanged(nameof(NumberOfNights)); }
        }

        public List<string> SelectablesGuests
        {
            get { return _selectablesGuests; }
            set { _selectablesGuests = value; OnPropertyChanged(nameof(_selectablesGuests)); }
        }


        private List<string> _selectablesGuests;

        public string _selectedGuest;
        public string SelectedGuest
        {
            get { return _selectedGuest; }
            set { _selectedGuest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }

        private List<Guest> _guests;

        public List<Guest> Guests
        {
            get { return _guests; }
            set { _guests = value; OnPropertyChanged(nameof(Guests)); }
        }

        public ExtraGuest()
        {
            this.Guests = new List<Guest>();
            this.SelectablesGuests = new List<string>()
            {
                "Adult",
                "Child",
                "Pet"
            };

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetExtraGuestInformation(int id)
        {

        }
    }
}