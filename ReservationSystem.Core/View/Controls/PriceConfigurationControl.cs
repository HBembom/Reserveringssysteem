using ReservationSystem.Core.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Core.View.Controls
{
    internal class PriceConfigurationControl : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PricesClient _pricesClient;

        private double _adultPrice;
        public double AdultPrice
        {
            get { return _adultPrice; }
            set { _adultPrice = value; OnPropertyChanged(nameof(AdultPrice)); }
        }

        private double _childPrice;
        public double ChildPrice
        {
            get { return _childPrice; }
            set { _childPrice = value; OnPropertyChanged(nameof(ChildPrice)); }
        }

        private double _petPrice;
        public double PetPrice
        {
            get { return _petPrice; }
            set { _petPrice = value; OnPropertyChanged(nameof(PetPrice)); }
        }

        private double _normalTax;
        public double NormalTax
        {
            get { return _normalTax; }
            set { _normalTax = value; OnPropertyChanged(nameof(NormalTax)); }
        }

        private double _tourismTax;
        public double TourismTax
        {
            get { return _tourismTax; }
            set { _tourismTax = value; OnPropertyChanged(nameof(TourismTax)); }
        }

        // public ICommand UpdateConfigurationCommand { get; set; }


        public PriceConfigurationControl()
        {
            _pricesClient = new PricesClient();
            //AdultPrice = _pricesClient.GetById("Adult");
            //ChildPrice = GetChildPrice("Child");
            //PetPrice = GetPetPrice("Pet");
            //NormalTax = GetNormalTax("NormalTax");
            //TourismTax = GetTourismTax("TourismTax");
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
}
