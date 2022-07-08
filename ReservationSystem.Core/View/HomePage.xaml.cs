using ReservationSystem.Core.View;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["launchedWithPrefSize"] == null)
            {
                // first app launch only!!
                ApplicationView.PreferredLaunchViewSize = new Size(1920, 1080);
                ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
                localSettings.Values["launchedWithPrefSize"] = true;
            }
            // resetting the auto-resizing -> next launch the system will control the PreferredLaunchViewSize
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReservationCollection));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateReservation));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //occupancy overview
            this.Frame.Navigate(typeof(PlanningBoard));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //configurations/profit
            this.Frame.Navigate(typeof(Configuration));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Heatmap));
        }
    }
}
