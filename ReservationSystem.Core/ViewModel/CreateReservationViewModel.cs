using ReservationSystem.Core.Commands;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class CreateReservationViewModel : ViewModelBase
    {    
        private ExtraGuest _extraGuest;
        public ExtraGuest ExtraGuest
        {
            get { return _extraGuest; }
            set { _extraGuest = value; OnPropertyChanged(nameof(ExtraGuest)); }
        }
        private GuestInformation _guestInformation;
        public GuestInformation GuestInformation
        {
            get { return _guestInformation; }
            set { _guestInformation = value; OnPropertyChanged(nameof(GuestInformation)); }
        }
        private ReservationPriceStructure _priceStructure;
        public ReservationPriceStructure PriceStructure
        {
            get { return _priceStructure; }
            set { _priceStructure = value; OnPropertyChanged(nameof(PriceStructure)); }
        }
        private Accomodations _accomodation;
        public Accomodations Accomodations
        {
            get { return _accomodation; }
            set { _accomodation = value; OnPropertyChanged(nameof(ViewModel.Accomodations));}
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        private bool _hasPaid;
        public bool HasPaid
        {
            get { return _hasPaid; }
            set { _hasPaid = value; OnPropertyChanged(nameof(HasPaid)); }
        }
        public ICommand AddGuestCommand { get; set; }
        public ICommand AddAccomodationCommand { get; set; }
        public ICommand CreateReservationCommand { get; set; }

        public CreateReservationViewModel()
        {
            this.Accomodations = new Accomodations();
            this.AddGuestCommand = new AddGuestCommand(this);
            this.AddAccomodationCommand = new AddAccomodationCommand(this);
            this.GuestInformation = new GuestInformation();
            this.ExtraGuest = new ExtraGuest();
            this.PriceStructure = new ReservationPriceStructure();
            this.CreateReservationCommand = new CreateReservationCommand(this);
        }
    }
}