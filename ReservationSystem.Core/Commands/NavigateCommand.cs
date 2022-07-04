using ReservationSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReservationSystem.Core.Commands
{
    internal abstract class NavigationCommand : CommandBase
    {

        public override void Execute(object parameter)
        {
            Frame dikkeFrame = Window.Current.Content as Frame;
            switch (parameter)
            {
                case "home":
                    dikkeFrame.Navigate(typeof(HomePage));
                    break;
                case "CreateReservation":
                    dikkeFrame.Navigate(typeof(CreateReservation));
                    break;
            }
        }

        

    }
}
