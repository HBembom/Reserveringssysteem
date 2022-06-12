using ReservationSystem.Core.Model;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (Accomodation accomodation1 in _createReservationViewModel.Accomodations)
            {
                if (accomodation1.ID.value == id)
                {
                    throw new ArgumentException("Id Already taken for chosen period");
                }
            }
            // need get and setters in _createreservation for accomdatointype
            Accomodation accomodation = _accomodationFactory.Create(_createReservationViewModel.AccomodationType, id);

            if (_createReservationViewModelaccomodationType == nameof(Camper))
            {
                _createReservationViewModel.Accomodations.Add(accomodation);
                _createReservationViewModel.NumberOfCampers = _createReservationViewModel.Accomodations.Count;
                _createReservationViewModel.TotalAmountOfNightCampers += (_createReservationViewModel.DepartureDateTime - _createReservationViewModel.ArrivalDateTime).Days;
                _createReservationViewModel.TotalPrice += _createReservationViewModel.NumberOfCampers * _createReservationViewModel.TotalAmountOfNightCampers * 2;
                _createReservationViewModel.TouristTax = new TotalTourismTaxPriceCalculator(new Price(_createReservationViewModel.TotalPrice)).Price.Value;
                _createReservationViewModel.Tax = new TotalNormalTaxPriceCalculator(new Price(_createReservationViewModel.TotalPrice)).Price.Value;
                _createReservationViewModel.NetProfit = new Price(_createReservationViewModel.TouristTax + _createReservationViewModel.Tax + _createReservationViewModel.TotalPrice).Value;
            }
            else if (accomodationType == nameof(House))
            {
                // Not Yet Implemented
            }

        }
    }
}
