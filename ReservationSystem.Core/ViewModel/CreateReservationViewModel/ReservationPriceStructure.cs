using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Model.Taxes;

namespace ReservationSystem.Core.ViewModel
{
    internal class ReservationPriceStructure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _numberOfAdults;

        public int NumberOfAdults
        {
            get { return _numberOfAdults; }
            set { _numberOfAdults = value; OnPropertyChanged(nameof(NumberOfAdults)); }
        }
        private int _totalAmountOfNightExtraAdults;
        public int TotalAmountOfNightExtraAdults
        {
            get { return _totalAmountOfNightExtraAdults; }
            set { _totalAmountOfNightExtraAdults = value; OnPropertyChanged(nameof(TotalAmountOfNightExtraAdults)); }
        }

        private double _adultPricePerNight;
        public double AdultPricePerNight
        {
            get { return _adultPricePerNight; }
            set { _adultPricePerNight = value; OnPropertyChanged(nameof(AdultPricePerNight)); }
        }

        private double _totalAdultPrice;
        public double TotalAdultPrice
        {
            get { return _totalAdultPrice; }
            set { _totalAdultPrice = value; OnPropertyChanged(nameof(TotalAdultPrice)); }
        }

        private int _numberOfChilds;
        public int NumberOfChilds
        {
            get { return _numberOfChilds; }
            set { _numberOfChilds = value; OnPropertyChanged(nameof(NumberOfChilds)); }
        }
        private int _totalAmountOfNightExtraChilds;
        public int TotalAmountOfNightExtraChilds
        {
            get { return _totalAmountOfNightExtraChilds; }
            set { _totalAmountOfNightExtraChilds = value; OnPropertyChanged(nameof(TotalAmountOfNightExtraChilds)); }
        }
        private double _childPricePerNight;
        public double ChildPricePerNight
        {
            get { return _childPricePerNight; }
            set { _childPricePerNight = value; OnPropertyChanged(nameof(ChildPricePerNight)); }
        }
        private double _totalChildPrice;
        public double TotalChildPrice
        {
            get { return _totalChildPrice; }
            set { _totalChildPrice = value; OnPropertyChanged(nameof(TotalChildPrice)); }
        }

        private int _numberOfPets;
        public int NumberOfPets
        {
            get { return _numberOfPets; }
            set { _numberOfPets = value; OnPropertyChanged(nameof(NumberOfPets)); }
        }
        private int _totalAmountOfNightExtraPets;
        public int TotalAmountOfNightExtraPets
        {
            get { return _totalAmountOfNightExtraPets; }
            set { _totalAmountOfNightExtraPets = value; OnPropertyChanged(nameof(TotalAmountOfNightExtraPets)); }
        }
        private double _petPricePerNight;
        public double PetPricePerNight
        {
            get { return _petPricePerNight; }
            set { _petPricePerNight = value; OnPropertyChanged(nameof(_petPricePerNight)); }
        }
        private double _totalPetPrice;

        public double TotalPetPrice
        {
            get { return _totalPetPrice; }
            set { _totalPetPrice = value; OnPropertyChanged(nameof(TotalPetPrice)); }
        }

        private int _numberOfCampers;
        public int NumberOfCampers
        {
            get { return _numberOfCampers; }
            set { _numberOfCampers = value; OnPropertyChanged(nameof(NumberOfCampers)); }
        }
        private int _totalAmountOfNightsCampers;
        public int TotalAmountOfNightCampers
        {
            get { return _totalAmountOfNightsCampers; }
            set { _totalAmountOfNightsCampers = value; OnPropertyChanged(nameof(TotalAmountOfNightCampers)); }
        }
        private double _camperPricePerNight;
        public double CamperPricePerNight
        {
            get { return _camperPricePerNight; }
            set { _camperPricePerNight = value; OnPropertyChanged(nameof(CamperPricePerNight)); }
        }
        private double _totalCamperPrice;
        public double TotalCamperPrice
        {
            get { return _totalCamperPrice; }
            set { _totalCamperPrice = value; OnPropertyChanged(nameof(TotalCamperPrice)); }
        }

        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice)); }
        }
        private double _touristTax;
        public double TouristTax
        {
            get { return _touristTax; }
            set { _touristTax = value; OnPropertyChanged(nameof(TouristTax)); }
        }
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; OnPropertyChanged(nameof(Tax)); }
        }
        private double _netProfit;
        public double NetProfit
        {
            get { return _netProfit; }
            set { _netProfit = value; OnPropertyChanged(nameof(NetProfit)); }
        }

        internal ReservationPriceStructure()
        {
            var pricesClient = new PricesClient();

            var adultPrice = new PriceModel();
            var childPrice = new PriceModel();
            var petPrice = new PriceModel();
            var normalTax = new PriceModel();
            var touristTax = new PriceModel();

            var setPricesTask = Task.Run(async () =>
            {
                adultPrice = await pricesClient.GetByName("Adult");
                childPrice = await pricesClient.GetByName("Child");
                petPrice = await pricesClient.GetByName("Pet");
                normalTax = await pricesClient.GetByName("NormalTax");
                touristTax = await pricesClient.GetByName("TourismTax");
            });
            setPricesTask.Wait();

            AdultPricePerNight = adultPrice == null ? 20.00 : adultPrice.Amount;
            ChildPricePerNight = childPrice == null ? 15.00 : childPrice.Amount;
            PetPricePerNight = petPrice == null ? 10.00 : petPrice.Amount;
            Tax = normalTax == null ? 15.00 : normalTax.Amount;
            TouristTax = touristTax == null ? 15.00 : touristTax.Amount;
        }
    }
}