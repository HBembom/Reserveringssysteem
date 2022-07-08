using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.CalculatePrice;
using ReservationSystem.Core.Model.Guests;
using ReservationSystem.Core.ViewModel;
using ReservationSystem.Core.ViewModel.Factory;

namespace ReservationSystem.Core.Commands
{
    internal class UpdateGuestCommand : CommandBase
    {
        private EditReservationViewModel _editreservation;
        private GuestFactory _guestFactory;
        public UpdateGuestCommand(EditReservationViewModel editereservation)
        {
            this._editreservation = editereservation;
            this._guestFactory = new GuestFactory();
        }

        public override void Execute(object parameter)
        {
            if (_editreservation.ExtraGuest.NumberOfNights <= 0)
            {
                throw new ArgumentException("Guest cannot stay zero or less nights");
            }
            Guest guest = _guestFactory.Create(_editreservation.ExtraGuest.SelectedGuest, _editreservation.ExtraGuest.NumberOfNights);

            if (_editreservation.ExtraGuest.SelectedGuest.Equals(nameof(Pet)))
            {
                AddPet(guest);
            }
            else if (_editreservation.ExtraGuest.SelectedGuest.Equals(nameof(Child)))
            {
                AddChild(guest);

            }
            else if (_editreservation.ExtraGuest.SelectedGuest.Equals(nameof(Adult)))
            {
                AddAdult(guest);
            }

            _editreservation.ExtraGuest.NumberOfNights = 0;
        }

        private void AddAdult(Guest guest)
        {
            _editreservation.ExtraGuest.Guests.Add(guest);
            ++_editreservation.PriceStructure.NumberOfAdults;
            _editreservation.PriceStructure.TotalAmountOfNightExtraAdults += guest.AmmountOfNights.Value;
            _editreservation.PriceStructure.TotalAdultPrice = Math.Round(_editreservation.PriceStructure.TotalAmountOfNightExtraAdults * _editreservation.PriceStructure.AdultPricePerNight, 2);
            _editreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            _editreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _editreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value, 2);
            _editreservation.PriceStructure.NetProfit = Math.Round(_editreservation.PriceStructure.TotalPrice, 2);
        }

        private void AddChild(Guest guest)
        {
            _editreservation.ExtraGuest.Guests.Add(guest);
            ++_editreservation.PriceStructure.NumberOfChilds;
            _editreservation.PriceStructure.TotalAmountOfNightExtraChilds += guest.AmmountOfNights.Value;
            _editreservation.PriceStructure.TotalChildPrice = Math.Round(_editreservation.PriceStructure.TotalAmountOfNightExtraChilds * _editreservation.PriceStructure.ChildPricePerNight, 2);
            _editreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            _editreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _editreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value, 2);
            _editreservation.PriceStructure.NetProfit = Math.Round(_editreservation.PriceStructure.TotalPrice, 2);
        }

        private void AddPet(Guest guest)
        {
            _editreservation.ExtraGuest.Guests.Add(guest);
            ++_editreservation.PriceStructure.NumberOfPets;
            _editreservation.PriceStructure.TotalAmountOfNightExtraPets += guest.AmmountOfNights.Value;
            _editreservation.PriceStructure.TotalPetPrice = Math.Round(_editreservation.PriceStructure.TotalAmountOfNightExtraPets * _editreservation.PriceStructure.PetPricePerNight, 2);
            _editreservation.PriceStructure.TotalPrice = Math.Round(GetTotalPrice(), 2);
            TotalNormalTaxPriceCalculator normalTax = new TotalNormalTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            TotalTourismTaxPriceCalculator tourismTax = new TotalTourismTaxPriceCalculator(new Price(_editreservation.PriceStructure.TotalPrice));
            _editreservation.PriceStructure.Tax = Math.Round(normalTax.Price.Value, 2);
            _editreservation.PriceStructure.TouristTax = Math.Round(tourismTax.Price.Value, 2);
            _editreservation.PriceStructure.NetProfit = Math.Round(_editreservation.PriceStructure.TotalPrice, 2);
        }

        private double GetTotalPrice()
        {
            return (_editreservation.PriceStructure.TotalCamperPrice + _editreservation.PriceStructure.TotalChildPrice + _editreservation.PriceStructure.TotalAdultPrice + _editreservation.PriceStructure.TotalPetPrice);
        }
    }
}
