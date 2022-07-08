using ReservationSystem.Core.ViewModel;
using System.Threading.Tasks;
using ReservationSystem.Core.Clients;

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
            var putPricesTask = Task.Run(async () =>
            {
                await _control.PricesClient.Put(new PriceModel() {Name = "Adult", Amount = _control.AdultPrice, IsTax = false});
                await _control.PricesClient.Put(new PriceModel() { Name = "Child", Amount = _control.ChildPrice, IsTax = false });
                await _control.PricesClient.Put(new PriceModel() {Name = "Pet", Amount = _control.PetPrice, IsTax = false });
                await _control.PricesClient.Put(new PriceModel() { Name = "NormalTax", Amount = _control.NormalTax, IsTax = true});
                await _control.PricesClient.Put(new PriceModel() { Name = "TourismTax", Amount = _control.TourismTax, IsTax = true});
            });
            putPricesTask.Wait();
        }
    }
}
