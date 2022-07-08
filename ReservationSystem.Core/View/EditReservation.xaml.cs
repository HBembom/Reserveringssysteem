using Windows.UI.Xaml;
using ReservationSystem.Core.Clients;
using ReservationSystem.Core.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditReservation : Page
    {
        public EditReservation(ReservationModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = new EditReservationViewModel(viewModel);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rootFrame = new Frame();
            Window.Current.Content = rootFrame;

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(HomePage), null);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
}
