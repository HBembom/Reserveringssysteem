using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.Commands;

namespace ReservationSystem.Core.ViewModel
{
    internal class EditReservationViewModel : ViewModelBase
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
            set { _accomodation = value; OnPropertyChanged(nameof(ViewModel.Accomodations)); }
        }
        private bool _hasPaid;
        public bool HasPaid
        {
            get { return _hasPaid; }
            set { _hasPaid = value; OnPropertyChanged(nameof(HasPaid)); }
        }

        private readonly ReservationModel _reservationModel;
        private ReservationsClient _reservationsClient { get; set; } = new ReservationsClient();
        public ICommand UpdateCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }
        public ICommand UpdateAccommodationCommand { get; set; }
        public ICommand DeleteReservationCommand { get; set; }

        public EditReservationViewModel(ReservationModel viewModel)
        {
            this._reservationModel = viewModel;
            this.ExtraGuest = new ExtraGuest();

            this.Accomodations = new Accomodations()
            {
                ArrivalDateTime = viewModel.ArrivalDate,
                DepartureDateTime = viewModel.DepartureDate
            };

            this.GuestInformation = new GuestInformation()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                PrefixName = viewModel.PrefixName,
                StreetName = viewModel.StreetName,
                LicensePlate = viewModel.LicensePlateName
            };

            this.PriceStructure = new ReservationPriceStructure()
            {
                TotalPrice = viewModel.TotalCost,
                NumberOfAdults = viewModel.AmountOfExtraAdults,
                NumberOfChilds = viewModel.AmountOfExtraChildren,
                NumberOfPets = viewModel.AmountOfExtraPets,
                NumberOfCampers = viewModel.AccommodationId.Length
            };

            HasPaid = viewModel.PaymentStatus;

            this.UpdateCommand = new UpdateCommand(this);
            this.DeleteReservationCommand = new DeleteReservationCommand(viewModel);
        }
    }
}
