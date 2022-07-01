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
    internal class Configuration : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
         
        private PriceModel _adultPrice;
        public PriceModel AdultPrice
        {
            get { return _adultPrice; }
            set { _adultPrice = value; OnPropertyChanged(nameof(AdultPrice)); }
        }

        private PriceModel _childPrice;
        public PriceModel ChildPrice
        {
            get { return _childPrice; }
            set { _childPrice = value; OnPropertyChanged(nameof(ChildPrice)); }
        }

        private PriceModel _petPrice;
        public PriceModel PetPrice
        {
            get { return _petPrice; }
            set { _petPrice = value; OnPropertyChanged(nameof(PetPrice)); }
        }

        private PriceModel _normalTax;
        public PriceModel NormalTax
        {
            get { return _normalTax; }
            set { _normalTax = value; OnPropertyChanged(nameof(NormalTax)); }
        }

        private PriceModel _tourismTax;
        public PriceModel TourismTax
        {
            get { return _tourismTax; }
            set { _tourismTax = value; OnPropertyChanged(nameof(TourismTax)); }
        }

        public ICommand UpdateConfigurationCommand { get; set; }


        public Configuration()
        {
            // AdultPrice = _pricesClient.GetById("Adult");
            // ChildPrice = GetChildPrice("Child");
            // PetPrice = GetPetPrice("Pet");
            // NormalTax = GetNormalTax("NormalTax");
            // TourismTax = GetTourismTax("TourismTax");
            // UpdateConfigurationCommand = new UpdateConfigurationCommand(this)
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
}
