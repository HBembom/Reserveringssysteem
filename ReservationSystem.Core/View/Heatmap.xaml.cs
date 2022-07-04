using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using System.Diagnostics;
using ReservationSystem.Core.Clients;
using Windows.Foundation;

namespace ReservationSystem.Core.View
{
    public sealed partial class Heatmap : Page
    {
        private SolidColorBrush _1_7HeatmapColor { get; set; }
        private SolidColorBrush _8_11HeatmapColor { get; set; }
        private SolidColorBrush _12_15HeatmapColor { get; set; }
        private SolidColorBrush _16_22HeatmapColor { get; set; }
        private SolidColorBrush _23_29HeatmapColor { get; set; }
        private LinearGradientBrush _LegendColor { get; set; } = new LinearGradientBrush();
        private DateTimeOffset _startDate { get; set; } = DateTimeOffset.Now;
        private DateTimeOffset _endDate { get; set; } = DateTimeOffset.Now.AddDays(7);
        private Dictionary<string, List<int>> _campingPlaces { get; } = new Dictionary<string, List<int>>();
        private ReservationsClient _reservationsClient { get; set; } = new ReservationsClient();
        private List<ReservationModel> _response { get; set; } = new List<ReservationModel>();

        public Heatmap()
        {
            this.InitializeComponent();
            _campingPlaces.Add("1_7", new List<int>() {1,2,3,4,5,6,7 });
            _campingPlaces.Add("8_11", new List<int>() {8,9,10,11 });
            _campingPlaces.Add("12_15", new List<int>() {12,13,14,15 });
            _campingPlaces.Add("16_22", new List<int>() {16,17,18,19,20,21,22 });
            _campingPlaces.Add("23_29", new List<int>() {23,24,25,26,27,28,29 });

            UpdateLegendColor();
            UpdateHeatmapColors();
        }

        private void UpdateLegendColor()
        {
            _LegendColor.StartPoint = new Point(0, 0.5);
            _LegendColor.EndPoint = new Point(1, 0.5);

            var Green = new GradientStop();
            var Yellow = new GradientStop();
            var Red = new GradientStop();

            Green.Color = Colors.Green;
            Green.Offset = 0;
            Yellow.Color = Colors.Yellow;
            Yellow.Offset = 0.5;
            Red.Color = Colors.Red;
            Red.Offset = 1;

            _LegendColor.GradientStops.Add(Green);
            _LegendColor.GradientStops.Add(Yellow);
            _LegendColor.GradientStops.Add(Red);
        }

        public void UpdateHeatmapColors()
        {
            foreach (var campingPlace in _campingPlaces)
            {
                var campingNumbers = campingPlace.Value;
                List<int> res = new List<int>
                {
                    1,
                    1,
                    1,
                    1
                };

                var whole = campingNumbers.Count();
                var part = res.Count();
                var gradientOffset = float.Parse($"0.{(part * 100) / whole}");

                var newColor = GetRelativeColorOfLegend(gradientOffset);

                switch (campingPlace.Key)
                {
                    case "1_7":
                        _1_7HeatmapColor = new SolidColorBrush(newColor);
                        break;
                    case "8_11":
                        _8_11HeatmapColor = new SolidColorBrush(newColor);
                        break;
                    case "12_15":
                        _12_15HeatmapColor = new SolidColorBrush(newColor);
                        break;
                    case "16_22":
                        _16_22HeatmapColor = new SolidColorBrush(newColor);
                        break;
                    case "23_29":
                        _23_29HeatmapColor = new SolidColorBrush(newColor);
                        break;
                }
            }
        }

        public Color GetRelativeColorOfLegend(float offset)
        {
            var gsc = _LegendColor.GradientStops;
            var point = gsc.SingleOrDefault(x => x.Offset == offset);

            if (point != null)
                return point.Color;

            var before = gsc.Where(x => x.Offset == gsc.Min(m => m.Offset)).First();
            var after = gsc.Where(x => x.Offset == gsc.Max(m => m.Offset)).First();

            foreach (var gs in gsc)
            {
                if (gs.Offset < offset && gs.Offset > before.Offset)
                    before = gs;
                if (gs.Offset > offset && gs.Offset < after.Offset)
                    after = gs;
            }

            var color = new Color
            {
                A = 195,
                R = (byte)((offset - before.Offset) * (after.Color.R - before.Color.R) / (after.Offset - before.Offset) + before.Color.R),
                G = (byte)((offset - before.Offset) * (after.Color.G - before.Color.G) / (after.Offset - before.Offset) + before.Color.G),
                B = (byte)((offset - before.Offset) * (after.Color.B - before.Color.B) / (after.Offset - before.Offset) + before.Color.B)
            };

            return color;
        }

        private void startDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            _startDate = args.NewDate.Value;
            _endDate = args.NewDate.Value.AddDays(7);

            endDate.Date = _endDate;
            UpdateHeatmapColors();
        }

        private void endDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            _startDate = args.NewDate.Value.AddDays(-7);
            _endDate = args.NewDate.Value;

            startDate.Date = _startDate;
            UpdateHeatmapColors();
        }
    }
}
