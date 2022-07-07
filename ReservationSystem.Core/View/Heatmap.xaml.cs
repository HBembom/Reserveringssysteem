using ReservationSystem.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.View
{
    public sealed partial class Heatmap : Page
    {
        private HeatmapViewModel _hmvm { get; set; }

        public Heatmap()
        {
            this.InitializeComponent();
            this.DataContext = new HeatmapViewModel();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
