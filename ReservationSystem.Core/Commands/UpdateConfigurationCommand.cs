using ReservationSystem.Core.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Commands
{
    internal class UpdateConfigurationCommand : CommandBase
    {
        private PriceConfigurationControl _control;
        
        public UpdateConfigurationCommand(PriceConfigurationControl control)
        {
            PriceConfigurationControl _control = control;
            
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
