using ReservationSystem.Core.View;
using ReservationSystem.Core.View.Controls;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Commands
{
    internal class UpdateConfigurationCommand : CommandBase
    {
        private ConfigurationViewModel _control;
        
        public UpdateConfigurationCommand(ConfigurationViewModel control)
        {
            _control = control;
            
        }

        public override void Execute(object parameter)
        {
            _control.PricesClient.Put("Adult", _control.AdultPrice);
            _control.PricesClient.Put("Child", _control.ChildPrice);
            _control.PricesClient.Put("Pet", _control.PetPrice);
            _control.PricesClient.Put("NormalTax", _control.NormalTax);
            _control.PricesClient.Put("TourismTax", _control.TourismTax);
        }
    }
}
