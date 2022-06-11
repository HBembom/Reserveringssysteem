using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Commands
{
    internal class AddGuestCommand : CommandBase
    {
        private readonly CreateReservationViewModel _reservation;
        public AddGuestCommand(ref CreateReservationViewModel reservation)
        {
            this._reservation = reservation;
        }

        public override void Execute(object parameter)
        {
 
        }
    }
}
