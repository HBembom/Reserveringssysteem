using ReservationSystem.Core.Model;
using ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using Guest = ReservationSystem.Core.Model.Guest;
using Reservation = ReservationSystem.Core.Model.Reservation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReservationSystem.Core
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class MainPage : Page
    {
       
        public MainPage()
        {        
            this.InitializeComponent();
        }
    }
}
