using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.CalculatePrice;
using ReservationSystem.Core.ViewModel;

namespace ReservationSystem.Core.Commands
{
    internal class UpdateAccommodationCommand : CommandBase
    {
        private EditReservationViewModel _editReservationViewModel;
        private AccomodationFactory _accomodationFactory;

        public UpdateAccommodationCommand(EditReservationViewModel editReservationViewModel)
        {
            this._editReservationViewModel = editReservationViewModel;
            this._accomodationFactory = new AccomodationFactory();
        }

        public override void Execute(object parameter)
        {

            foreach (Accomodation accomodation1 in _editReservationViewModel.Accomodations.AccomodationsList)
            {
                if (accomodation1.ID.value == _editReservationViewModel.Accomodations.SelectedPitchNumber)
                {
                    throw new ArgumentException("Id Already taken for chosen period");
                }
            }
            // need get and setters in _createreservation for accomdationntype
            Accomodation accomodation = _accomodationFactory.Create(_editReservationViewModel.Accomodations.SelectedAccomodation, _editReservationViewModel.Accomodations.SelectedPitchNumber);

            if (_editReservationViewModel.Accomodations.SelectedAccomodation.Equals(nameof(Camper)))
            {
                _editReservationViewModel.Accomodations.AccomodationsList.Add(accomodation);
                ++_editReservationViewModel.PriceStructure.NumberOfCampers;
                _editReservationViewModel.PriceStructure.TotalAmountOfNightCampers += (_editReservationViewModel.Accomodations.DepartureDateTime - _editReservationViewModel.Accomodations.ArrivalDateTime).Days;
                _editReservationViewModel.PriceStructure.TotalCamperPrice = _editReservationViewModel.PriceStructure.CamperPricePerNight * _editReservationViewModel.PriceStructure.TotalAmountOfNightCampers;
                _editReservationViewModel.PriceStructure.TotalPrice = GetTotalPrice();
                TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_editReservationViewModel.PriceStructure.TotalPrice));
                TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_editReservationViewModel.PriceStructure.TotalPrice));
                _editReservationViewModel.PriceStructure.Tax = normalTax.Price.Value;
                _editReservationViewModel.PriceStructure.TouristTax = tourismTax.Price.Value;
                _editReservationViewModel.PriceStructure.NetProfit = _editReservationViewModel.PriceStructure.TotalPrice;
            }
            else if (_editReservationViewModel.Accomodations.SelectedAccomodation == nameof(House))
            {
                // Not Yet Implemented
            }

            _editReservationViewModel.Accomodations.SelectedPitchNumber = 1;

        }

        private double GetTotalPrice()
        {
            return (_editReservationViewModel.PriceStructure.TotalCamperPrice + _editReservationViewModel.PriceStructure.TotalChildPrice + _editReservationViewModel.PriceStructure.TotalAdultPrice + _editReservationViewModel.PriceStructure.TotalPetPrice);
        }
    }
}
