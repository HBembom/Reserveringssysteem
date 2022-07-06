﻿using ReservationSystem.Core.View;
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
            this.Frame.Navigate(typeof(VisualReservation));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //configurations/profit
            this.Frame.Navigate(typeof(Configuration));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //reservation details
        }
    }
}
