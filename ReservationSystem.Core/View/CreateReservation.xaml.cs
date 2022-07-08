using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ReservationSystem.Core.View
{
    public sealed partial class CreateReservation : Page
    {
        public CreateReservation()
        {
            this.InitializeComponent();
            this.DataContext = new ViewModel.CreateReservationViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
