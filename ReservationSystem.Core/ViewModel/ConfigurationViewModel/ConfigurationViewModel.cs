using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Core.View
{
    internal class ConfigurationViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public readonly PricesClient PricesClient;
         
        private Price _adultPrice;
        public Price AdultPrice
        {
            get { return _adultPrice; }
            set { _adultPrice = value; OnPropertyChanged(nameof(AdultPrice)); }
        }

        private Price _childPrice;
        public Price ChildPrice
        {
            get { return _childPrice; }
            set { _childPrice = value; OnPropertyChanged(nameof(ChildPrice)); }
        }

        private Price _petPrice;
        public Price PetPrice
        {
            get { return _petPrice; }
            set { _petPrice = value; OnPropertyChanged(nameof(PetPrice)); }
        }

        private Price _normalTax;
        public Price NormalTax
        {
            get { return _normalTax; }
            set { _normalTax = value; OnPropertyChanged(nameof(NormalTax)); }
        }

        private Price _tourismTax;
        public Price TourismTax
        {
            get { return _tourismTax; }
            set { _tourismTax = value; OnPropertyChanged(nameof(TourismTax)); }
        }

        public ICommand UpdateConfigurationCommand { get; set; }

        public ConfigurationViewModel()
        {
            PricesClient = new PricesClient();
            AdultPrice = PricesClient.GetByName("Adult").Result;
            ChildPrice = PricesClient.GetByName("Child").Result;
            PetPrice = PricesClient.GetByName("Pet").Result;
            NormalTax = PricesClient.GetByName("NormalTax").Result;
            TourismTax = PricesClient.GetByName("TourismTax").Result;
            UpdateConfigurationCommand = new UpdateConfigurationCommand(this);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
}
