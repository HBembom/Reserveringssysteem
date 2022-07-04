﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReservationSystem.Core.ViewModel
{
    internal class EditReservationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand UpdateCommand { get; set; }

        public EditReservationViewModel()
        {
            this.UpdateCommand = new UpdateCommand(this);
            this.GuestInformation = new GuestInformation();
            this.ExtraGuest = new ExtraGuest();
            this.PriceStructure = new ReservationPriceStructure();
            this.Accomodations = new Accomodations();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
