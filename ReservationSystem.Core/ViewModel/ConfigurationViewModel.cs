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

        public ICommand UpdateConfigurationCommand { get; set; }

        public ConfigurationViewModel()
        {
            PricesClient = new PricesClient();

            // var setConfigurationTask = Task.Run(() =>
            // {
            // });
            // setConfigurationTask.Wait();

            SetConfiguration();


            UpdateConfigurationCommand = new UpdateConfigurationCommand(this);
        }

        private async void SetConfiguration()
        {
            var adultPrice = await PricesClient.GetByName("Adult");
            var childPrice = await PricesClient.GetByName("Child");
            var petPrice = await PricesClient.GetByName("Pet");
            var normalTax = await PricesClient.GetByName("NormalTax");
            var tourismTax = await PricesClient.GetByName("TourismTax");
            
            AdultPrice = new Price(adultPrice.Amount).Value;
            ChildPrice = new Price(childPrice.Amount).Value;
            PetPrice = new Price(petPrice.Amount).Value;
            NormalTax = new Price(normalTax.Amount).Value;
            TourismTax = new Price(tourismTax.Amount).Value;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
}
