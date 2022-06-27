﻿using System;
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
using ReservationSystem.Core.Clients;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReservationSystem.Core.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        private readonly AccommodationClient _accommodationsClient = new AccommodationClient();

        public BlankPage1()
        {
            this.InitializeComponent();
            Test();
        }

        private async void Test()
        {

            var test = await _accommodationsClient.GetAll();
            TextBlockTest.Text = test[0].AccommodationType;
        }
    }
}
