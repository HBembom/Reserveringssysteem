using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
<<<<<<<< HEAD:ReservationSystem.Core/View/Configuration.xaml.cs
    public sealed partial class Configuration : Page
    {
        public Configuration()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage));
========
    public sealed partial class ShowReservationResult : Page
    {
        public ShowReservationResult()
        {
            this.InitializeComponent();
>>>>>>>> 9f30f8689482d056f31ba7d15be56ae61d24879d:ReservationSystem.Core/View/ShowReservationResult.xaml.cs
        }
    }
}
