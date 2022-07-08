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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class ConfigurationViewModel : ViewModelBase
    {
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
            SetConfiguration();
            UpdateConfigurationCommand = new UpdateConfigurationCommand(this);
        }

        private void SetConfiguration()
        {
            var adultPrice = new PriceModel();
            var childPrice = new PriceModel();
            var petPrice = new PriceModel();
            var normalTax = new PriceModel();
            var tourismTax = new PriceModel();

            var pricesTask = Task.Run(async () =>
            {
                adultPrice = await PricesClient.GetByName("Adult");
                childPrice = await PricesClient.GetByName("Child");
                petPrice = await PricesClient.GetByName("Pet");
                normalTax = await PricesClient.GetByName("NormalTax");
                tourismTax = await PricesClient.GetByName("TourismTax");
            });
            pricesTask.Wait();

            AdultPrice = new Price(adultPrice.Amount).Value;
            ChildPrice = new Price(childPrice.Amount).Value;
            PetPrice = new Price(petPrice.Amount).Value;
            NormalTax = new Price(normalTax.Amount).Value;
            TourismTax = new Price(tourismTax.Amount).Value;
        }
    }
}
