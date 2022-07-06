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
                if (_createreservation.ExtraGuest.NumberOfNights <= 0)
                {
                    throw new ArgumentException("Guest cannot stay zero or less nights");
                }
                Guest guest = _guestFactory.Create(_createreservation.ExtraGuest.SelectedGuest, _createreservation.ExtraGuest.NumberOfNights);

                if (_createreservation.ExtraGuest.SelectedGuest.Equals(nameof(Pet)))
                {
                    AddPet(guest);
                }
                else if (_createreservation.ExtraGuest.SelectedGuest.Equals(nameof(Child)))
                {
                    AddChild(guest);

                }
                else if (_createreservation.ExtraGuest.SelectedGuest.Equals(nameof(Adult)))
                {
                    AddAdult(guest);
                }

                _createreservation.ExtraGuest.NumberOfNights = 0;
        }

        private void AddAdult(Guest guest)
        {
            _createreservation.ExtraGuest.Guests.Add(guest);
            ++_createreservation.PriceStructure.NumberOfAdults;
            _createreservation.PriceStructure.TotalAmountOfNightExtraAdults += guest.AmmountOfNights.Value;
            _createreservation.PriceStructure.TotalAdultPrice = Math.Round(_createreservation.PriceStructure.TotalAmountOfNightExtraAdults * _createreservation.PriceStructure.AdultPricePerNight, 2);
            _createreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            _createreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _createreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value, 2);
            _createreservation.PriceStructure.NetProfit = Math.Round(_createreservation.PriceStructure.TotalPrice, 2);
        }

        private void AddChild(Guest guest)
        {
            _createreservation.ExtraGuest.Guests.Add(guest);
            ++_createreservation.PriceStructure.NumberOfChilds;
            _createreservation.PriceStructure.TotalAmountOfNightExtraChilds += guest.AmmountOfNights.Value;
            _createreservation.PriceStructure.TotalChildPrice = Math.Round(_createreservation.PriceStructure.TotalAmountOfNightExtraChilds * _createreservation.PriceStructure.ChildPricePerNight, 2);
            _createreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            _createreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _createreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value, 2);
            _createreservation.PriceStructure.NetProfit = Math.Round(_createreservation.PriceStructure.TotalPrice,2);
        }

        private void AddPet(Guest guest)
        {
            _createreservation.ExtraGuest.Guests.Add(guest);
            ++_createreservation.PriceStructure.NumberOfPets;
            _createreservation.PriceStructure.TotalAmountOfNightExtraPets += guest.AmmountOfNights.Value;
            _createreservation.PriceStructure.TotalPetPrice = Math.Round(_createreservation.PriceStructure.TotalAmountOfNightExtraPets * _createreservation.PriceStructure.PetPricePerNight,2);
            _createreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_createreservation.PriceStructure.TotalPrice));
            _createreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _createreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value,2);
            _createreservation.PriceStructure.NetProfit = Math.Round(_createreservation.PriceStructure.TotalPrice, 2);
        }

        private double GetTotalPrice()
        {
            return (_createreservation.PriceStructure.TotalCamperPrice + _createreservation.PriceStructure.TotalChildPrice + _createreservation.PriceStructure.TotalAdultPrice + _createreservation.PriceStructure.TotalPetPrice);
        }
    }
}
