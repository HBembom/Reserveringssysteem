using ReservationSystem.Core.View;
using ReservationSystem.Core.View.Controls;
using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            var PutPrices = Task.Run(async () =>
            {
                await _control.PricesClient.Put("Adult", _control.AdultPrice, false);
                await _control.PricesClient.Put("Child", _control.ChildPrice, false);
                await _control.PricesClient.Put("Pet", _control.PetPrice, false);
                await _control.PricesClient.Put("NormalTax", _control.NormalTax, true);
                await _control.PricesClient.Put("TourismTax", _control.TourismTax, true);
            });
            PutPrices.Wait();
        }
    }
}
