using ReservationSystem.Core.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ReservationSystem.Core.View.Controls
{
    public sealed partial class RevenueChart : UserControl
    {
        public readonly ProfitsClient ProfitModel;
        public DateTime EndTime;
        public List<ProfitModel> DateTimeScope;

        public RevenueChart()
        {
            EndTime = DateTime.UtcNow;
            ProfitModel = new ProfitsClient();
            // DateTimeScope = ProfitModel.GetProfitFromPeriod(EndTime.AddDays(-30).ToString(), EndTime.ToString()).Result;
            DateTimeScope = new List<ProfitModel>()
            {
                new ProfitModel() {AmountOfProfit = 100, Period = 1},
            };

            this.InitializeComponent();
            this.DataContext = "";
        }
    }
}
