using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.CalculatePrice;
using ReservationSystem.Core.Model.Guests;
using ReservationSystem.Core.ViewModel;
using ReservationSystem.Core.ViewModel.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Commands
{
    internal class AddGuestCommand : CommandBase
    {
        private CreateReservationViewModel _createreservation;
        private GuestFactory _guestFactory;
        public AddGuestCommand(CreateReservationViewModel createreservation)
        {
            this._createreservation = createreservation;
            this._guestFactory = new GuestFactory();
        }

        public override void Execute(object parameter)
        {
            
                if (_createreservation.NumberOfNights <= 0)
                {
                    throw new ArgumentException("Guest cannot stay zero or less nights");
                }
                Guest guest = _guestFactory.Create(_createreservation.SelectedGuest, _createreservation.NumberOfNights);

                if (_createreservation.SelectedGuest.Equals(nameof(Pet)))
                {
                    _createreservation.Guests.Add(guest);
                    _createreservation.NumberOfPets = _createreservation.Guests.Count;
                    _createreservation.TotalAmountOfNightExtraPets += guest.AmmountOfNights.Value;
                    _createreservation.TotalPetPrice = _createreservation.NumberOfPets * (_createreservation.TotalAmountOfNightExtraPets * _createreservation.PetPricePerNight);
                    _createreservation.TotalPrice += _createreservation.TotalPetPrice;
                    TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    _createreservation.Tax = normalTax.Price.Value;
                    _createreservation.TouristTax = tourismTax.Price.Value;
                    _createreservation.NetProfit = _createreservation.TotalPrice;
                }
                else if (_createreservation.SelectedGuest.Equals(nameof(Child)))
                {
                    _createreservation.Guests.Add(guest);
                    _createreservation.NumberOfChilds = _createreservation.Guests.Count;
                    _createreservation.TotalAmountOfNightExtraChilds += guest.AmmountOfNights.Value;
                    _createreservation.TotalChildPrice = _createreservation.NumberOfChilds * (_createreservation.TotalAmountOfNightExtraChilds * _createreservation.ChildPricePerNight);
                    _createreservation.TotalPrice += _createreservation.TotalChildPrice;
                    TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    _createreservation.Tax = normalTax.Price.Value;
                    _createreservation.TouristTax = tourismTax.Price.Value;
                    _createreservation.NetProfit = _createreservation.TotalPrice;

                }
                else if (_createreservation.SelectedGuest.Equals(nameof(Adult)))
                {
                    _createreservation.Guests.Add(guest);
                    _createreservation.NumberOfAdults = _createreservation.Guests.Count;
                    _createreservation.TotalAmountOfNightExtraAdults += guest.AmmountOfNights.Value;
                    _createreservation.TotalAdultPrice = _createreservation.NumberOfAdults * (_createreservation.TotalAmountOfNightExtraAdults * _createreservation.AdultPricePerNight);
                    _createreservation.TotalPrice += _createreservation.TotalAdultPrice;
                    TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.TotalPrice));
                    _createreservation.Tax = normalTax.Price.Value;
                    _createreservation.TouristTax = tourismTax.Price.Value;
                    _createreservation.NetProfit = _createreservation.TotalPrice;

            }

            _createreservation.NumberOfNights = 0;
            
        }
    }
}
