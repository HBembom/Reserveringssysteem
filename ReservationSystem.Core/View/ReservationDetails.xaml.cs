using ReservationSystem.Core.Clients;
using ReservationSystem.Core.ViewModel.ReservationViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class ReservationDetail : Page
    {
        public ReservationDetail(ReservationModel reservationModel)
        {
            this.InitializeComponent();
            this.DataContext = new ReservationViewModel(reservationModel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
