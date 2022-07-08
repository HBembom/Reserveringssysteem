using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.CalculatePrice;
using ReservationSystem.Core.ViewModel;
using System;

namespace ReservationSystem.Core.Commands
{
    internal class AddAccomodationCommand : CommandBase
    {
        private CreateReservationViewModel _createReservationViewModel;
        private AccomodationFactory _accomodationFactory;

        public AddAccomodationCommand(CreateReservationViewModel createReservationViewModel)
        {
            this._createReservationViewModel = createReservationViewModel;
            this._accomodationFactory = new AccomodationFactory();
        }

        public override void Execute(object parameter)
        {

            foreach (Accomodation accomodation1 in _createReservationViewModel.Accomodations.AccomodationsList)
            {
                if (accomodation1.ID.value == _createReservationViewModel.Accomodations.SelectedPitchNumber)
                {
                    throw new ArgumentException("Id Already taken for chosen period");
                }
            }
            // need get and setters in _createreservation for accomdationntype
            Accomodation accomodation = _accomodationFactory.Create(_createReservationViewModel.Accomodations.SelectedAccomodation, _createReservationViewModel.Accomodations.SelectedPitchNumber);

            if (_createReservationViewModel.Accomodations.SelectedAccomodation.Equals(nameof(Camper)))
            {
                _createReservationViewModel.Accomodations.AccomodationsList.Add(accomodation);
                ++_createReservationViewModel.PriceStructure.NumberOfCampers;
                _createReservationViewModel.PriceStructure.TotalAmountOfNightCampers += (_createReservationViewModel.Accomodations.DepartureDateTime - _createReservationViewModel.Accomodations.ArrivalDateTime).Days;
                _createReservationViewModel.PriceStructure.TotalCamperPrice = _createReservationViewModel.PriceStructure.CamperPricePerNight * _createReservationViewModel.PriceStructure.TotalAmountOfNightCampers;
                _createReservationViewModel.PriceStructure.TotalPrice = GetTotalPrice();
                TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createReservationViewModel.PriceStructure.TotalPrice));
                TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createReservationViewModel.PriceStructure.TotalPrice));
                _createReservationViewModel.PriceStructure.Tax = normalTax.Price.Value;
                _createReservationViewModel.PriceStructure.TouristTax = tourismTax.Price.Value;
                _createReservationViewModel.PriceStructure.NetProfit = _createReservationViewModel.PriceStructure.TotalPrice;
            }
            else if (_createReservationViewModel.Accomodations.SelectedAccomodation == nameof(House))
            {
                // Not Yet Implemented
            }

            _createReservationViewModel.Accomodations.SelectedPitchNumber = 1;

        }

        private double GetTotalPrice()
        {
            return (_createReservationViewModel.PriceStructure.TotalCamperPrice + _createReservationViewModel.PriceStructure.TotalChildPrice + _createReservationViewModel.PriceStructure.TotalAdultPrice + _createReservationViewModel.PriceStructure.TotalPetPrice);
        }
    }
}
