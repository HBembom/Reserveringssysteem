using ReservationSystem.Core.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReservationCollection : Page
    {
        public ReservationCollection()
        {
            this.InitializeComponent();
            this.DataContext = new ReservationCollectionViewModel();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
