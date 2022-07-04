using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Diagnostics;

namespace ReservationSystem.Core.View
{
    public sealed partial class Heatmap : Page
    {
        private SolidColorBrush _1_7HeatmapColor { get; set; }
        private SolidColorBrush _8_11HeatmapColor { get; set; }
        private SolidColorBrush _12_15HeatmapColor { get; set; }
        private SolidColorBrush _16_22HeatmapColor { get; set; }
        private SolidColorBrush _23_29HeatmapColor { get; set; }
        private DateTimeOffset _startDate { get; set; } = DateTimeOffset.Now;
        private DateTimeOffset _endDate { get; set; } = DateTimeOffset.Now.AddDays(7);

        public Heatmap()
        {
            this.InitializeComponent();
            UpdateHeatmapColors();
        }

        public void UpdateHeatmapColors()
        {
            _1_7HeatmapColor = new SolidColorBrush(Color.FromArgb(200, 255, 45, 45));
            _8_11HeatmapColor = new SolidColorBrush(Color.FromArgb(200, 45, 255, 45));
            _12_15HeatmapColor = new SolidColorBrush(Color.FromArgb(200, 45, 45, 255));
            _16_22HeatmapColor = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255));
            _23_29HeatmapColor = new SolidColorBrush(Color.FromArgb(200, 45, 45, 45));
        }

        private void startDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            _startDate = args.NewDate.Value;
            _endDate = args.NewDate.Value.AddDays(7);

            endDate.Date = _endDate;
        }

        private void endDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            _startDate = args.NewDate.Value.AddDays(-7);
            _endDate = args.NewDate.Value;

            startDate.Date = _startDate;
        }
    }
}
