using ReservationSystem.Core.Commands;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.CalculatePrice;
using ReservationSystem.Core.Model.Guests;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class CreateReservationViewModel : ViewModelBase
    {
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
        private int _numberOfNights;
        public int NumberOfNights
        {
            get { return _numberOfNights; }
            set { _numberOfNights = value; OnPropertyChanged(nameof(NumberOfNights)); }
        }

        private List<Guest> _guests;
        public List<Guest> Guests
        {
            get { return _guests; }
            set { _guests = value;  OnPropertyChanged(nameof(Guests)); }
        }
        private int _numberOfAdults;

        public int NumberOfAdults
        {
            get { return _numberOfAdults; }
            set { _numberOfAdults = value; OnPropertyChanged(nameof(NumberOfAdults));}
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
            get { return _totalAdultPrice;}
            set { _totalAdultPrice = value; OnPropertyChanged(nameof(TotalAdultPrice)); }
        }

        private int _numberOfChilds;
        public int NumberOfChilds
        {
            get { return _numberOfChilds; }
            set { _numberOfChilds = value; OnPropertyChanged(nameof(NumberOfChilds));}
        }
        private int _totalAmountOfNightExtraChilds;
        public int TotalAmountOfNightExtraChilds
        {
            get { return _totalAmountOfNightExtraChilds; }
            set { _totalAmountOfNightExtraAdults = value; OnPropertyChanged(nameof(TotalAmountOfNightExtraChilds)); }
        }
        private double _childPricePerNight;
        public double ChildPricePerNight
        {
            get { return _childPricePerNight;}
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
            set { _numberOfPets = value; OnPropertyChanged(nameof(NumberOfPets));}
        }
        private int _totalAmountOfNightExtraPets;
        public int TotalAmountOfNightExtraPets
        {
            get { return _totalAmountOfNightExtraPets; }
            set { _totalAmountOfNightExtraAdults = value; OnPropertyChanged(nameof(TotalAmountOfNightExtraPets)); }
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
            set { _totalPetPrice = value; OnPropertyChanged(nameof(TotalPetPrice));}
        }

        private List<Accomodation> _accomdations;
        public List<Accomodation> Accomodations
        {
            get { return _accomdations; }
            set { _accomdations = value; OnPropertyChanged(nameof(Accomodations));}
        }
        private int _numberOfCampers;
        public int NumberOfCampers
        {
            get { return _numberOfCampers; }
            set { _numberOfCampers = value; OnPropertyChanged(nameof(NumberOfCampers));  }
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
            get { return _camperPricePerNight;}
            set { _camperPricePerNight = value; OnPropertyChanged(nameof(CamperPricePerNight)); }
        }
        private double _totalCamperPrice;
        public double TotalCamperPrice
        {
            get { return _totalCamperPrice;}
            set { _totalCamperPrice = value; OnPropertyChanged(nameof(TotalCamperPrice)); }
        }
        
        private DateTime _arrivalDateTime;
        public DateTime ArrivalDateTime
        {
            get { return _arrivalDateTime; }
            set { _arrivalDateTime = value; OnPropertyChanged(nameof(ArrivalDateTime)); }
        }
        private DateTime _departureDateTime;
        public DateTime DepartureDateTime
        {
            get { return _departureDateTime;}
            set { _departureDateTime = value;OnPropertyChanged(nameof(DepartureDateTime));}
        }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice));}
        }
        private double _touristTax;
        public double TouristTax
        {
            get { return _touristTax; }
            set { _touristTax = value; OnPropertyChanged(nameof(TouristTax));}
        }
        private double _tax;
        public double Tax
        {
            get { return _tax; }
            set { _tax = value; OnPropertyChanged(nameof(Tax));}
        }
        private double _netProfit;
        public double NetProfit
        {
            get { return _netProfit; }
            set { _netProfit = value; OnPropertyChanged(nameof(NetProfit));}
        }


        private readonly GuestFactory _guestFactory;
        private readonly AccomodationFactory _accomodationFactory;
        public ICommand AddGuestCommand;
        public ICommand AddAccomodationCommand;
        public ICommand SubmitCommand;

        public CreateReservationViewModel()
        {
            this.ArrivalDateTime = DateTime.UtcNow;
            this.DepartureDateTime = DateTime.UtcNow.AddDays(1);
            this._guestFactory = new GuestFactory();
            this._accomodationFactory = new AccomodationFactory();
        }

        // Could be refactored
        public void AddGuest(string guestType, int ammountOfNights)
        {
            if (ammountOfNights <= 0)
            {
                throw new ArgumentException("Guest cannot stay zero or less nights");
            }
            Guest guest  = _guestFactory.Create(guestType, ammountOfNights);

            if (guestType == nameof(Pet))
            {
                Guests.Add(guest);
                NumberOfPets = Guests.Count;
                TotalAmountOfNightExtraPets += guest.AmmountOfNights.Value;
                TotalPetPrice = NumberOfPets * TotalAmountOfNightExtraPets * PetPricePerNight;
                TotalPrice += TotalPetPrice;
            }
            else if (guestType == nameof(Child))
            {
                Guests.Add(guest);
                NumberOfChilds = Guests.Count;
                TotalAmountOfNightExtraChilds += guest.AmmountOfNights.Value;
                TotalChildPrice = NumberOfChilds * TotalAmountOfNightExtraChilds * ChildPricePerNight;
                TotalPrice += TotalChildPrice;

            }
            else if(guestType == nameof(ExtraAdult))
            {
                Guests.Add(guest);
                NumberOfAdults = Guests.Count;
                TotalAmountOfNightExtraAdults += guest.AmmountOfNights.Value;
                TotalAdultPrice = NumberOfAdults * TotalAmountOfNightExtraAdults * AdultPricePerNight;
                TotalPrice += TotalChildPrice;
            }
        }

        // Could be refactored // Should also
        public void AddAccomodation(string accomodationType, int id)
        {
            foreach (Accomodation accomodation1 in Accomodations)
            {
                if (accomodation1.ID.value == id)
                {
                    throw new ArgumentException("Id Already taken for chosen period");
                }
            }

            Accomodation accomodation = _accomodationFactory.Create(accomodationType, id);

            if (accomodationType == nameof(Camper))
            {
                Accomodations.Add(accomodation);
                NumberOfCampers = Accomodations.Count;
                TotalAmountOfNightCampers += (DepartureDateTime - ArrivalDateTime).Days;
                TotalPrice += NumberOfCampers * TotalAmountOfNightCampers * 2;
                TouristTax = new TotalTourismTaxPriceCalculator(new Price(TotalPrice)).Price.Value;
                Tax = new TotalNormalTaxPriceCalculator(new Price(TotalPrice)).Price.Value;
                NetProfit = new Price(TouristTax + Tax + TotalPrice).Value;
            }
            else if (accomodationType == nameof(House))
            {
                // Not Yet Implemented
            }
        }
    }
}