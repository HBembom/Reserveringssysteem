using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReservationSystem.Core.ViewModel
{
    public class GuestInformation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        private string _prefixName;
        public string PrefixName
        {
            get { return _prefixName; }
            set { _prefixName = value; OnPropertyChanged(nameof(PrefixName)); }
        }
        private string _streetName;
        public string StreetName
        {
            get { return _streetName; }
            set { _streetName = value; OnPropertyChanged(nameof(StreetName)); }
        }
        private string _licensePlate;

        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; OnPropertyChanged(nameof(LicensePlate)); }
        }

        public void GetContactDetail(int id)
        {

        }
    }
}