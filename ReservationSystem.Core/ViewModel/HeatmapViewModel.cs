using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI;
using ReservationSystem.Core.Clients;
using Windows.Foundation;
using System.Diagnostics;

namespace ReservationSystem.Core.ViewModel
{
    internal class HeatmapViewModel : ViewModelBase
    {
        private const int COLOR_A = 195;
        private SolidColorBrush _1_7HeatmapColor;
        public SolidColorBrush HeatmapColor1_7
        {
            get { return _1_7HeatmapColor; }
            set { _1_7HeatmapColor = value; OnPropertyChanged(nameof(HeatmapColor1_7)); }
        }

        private SolidColorBrush _8_11HeatmapColor;
        public SolidColorBrush HeatmapColor8_11
        {
            get { return _8_11HeatmapColor; }
            set { _8_11HeatmapColor = value; OnPropertyChanged(nameof(HeatmapColor8_11)); }
        }

        private SolidColorBrush _12_15HeatmapColor;
        public SolidColorBrush HeatmapColor12_15
        {
            get { return _12_15HeatmapColor; }
            set { _12_15HeatmapColor = value;  OnPropertyChanged(nameof(HeatmapColor12_15)); }
        }

        private SolidColorBrush _16_22HeatmapColor;
        public SolidColorBrush HeatmapColor16_22
        {
            get { return _16_22HeatmapColor; }
            set { _16_22HeatmapColor = value; OnPropertyChanged(nameof(HeatmapColor16_22)); }
        }

        private SolidColorBrush _23_29HeatmapColor;
        public SolidColorBrush HeatmapColor23_29
        {
            get { return _23_29HeatmapColor; }
            set { _23_29HeatmapColor = value;  OnPropertyChanged(nameof(HeatmapColor23_29)); }
        }

        private DateTimeOffset _startDate;
        public DateTimeOffset StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                _endDate = value.AddDays(7);
                UpdateHeatmapColors();
                OnPropertyChanged(nameof(EndDate));
            }
        }
        private DateTimeOffset _endDate;
        public DateTimeOffset EndDate
        {
            get { return _endDate; }
            set { StartDate = value.AddDays(-7); OnPropertyChanged(nameof(StartDate)); }
        }

        private LinearGradientBrush _LegendColor;
        public LinearGradientBrush LegendColor
        {
            get { return _LegendColor; }
            set { _LegendColor = value; }
        }
        private Dictionary<string, List<int>> _campingPlaces { get; }
        private ReservationsClient _reservationsClient { get; set; }
        private List<ReservationModel> _response { get; set; }

        public HeatmapViewModel()
        {
            _reservationsClient = new ReservationsClient();
            _response = new List<ReservationModel>();
            _campingPlaces = new Dictionary<string, List<int>>
            {
                { "1_7", new List<int>() { 1, 2, 3, 4, 5, 6, 7 } },
                { "8_11", new List<int>() { 8, 9, 10, 11 } },
                { "12_15", new List<int>() { 12, 13, 14, 15 } },
                { "16_22", new List<int>() { 16, 17, 18, 19, 20, 21, 22 } },
                { "23_29", new List<int>() { 23, 24, 25, 26, 27, 28, 29 } }
            };

            LegendColor = new LinearGradientBrush();
            UpdateLegendColor();

            StartDate = DateTimeOffset.Now;
        }

        private void UpdateLegendColor()
        {
            LegendColor.StartPoint = new Point(0, 0.5);
            LegendColor.EndPoint = new Point(1, 0.5);

            var Green = new GradientStop();
            var Yellow = new GradientStop();
            var Red = new GradientStop();

            Green.Color = Colors.Green;
            Green.Offset = 0;
            Yellow.Color = Colors.Yellow;
            Yellow.Offset = 0.5;
            Red.Color = Colors.Red;
            Red.Offset = 1;

            LegendColor.GradientStops.Add(Green);
            LegendColor.GradientStops.Add(Yellow);
            LegendColor.GradientStops.Add(Red);
        }

        private void UpdateHeatmapColors()
        {
            var sMonth = StartDate.DateTime.Month < 10 ? $"0{StartDate.DateTime.Month}" : StartDate.DateTime.Month.ToString();
            var sDay = StartDate.DateTime.Day < 10 ? $"0{StartDate.DateTime.Day}" : StartDate.DateTime.Day.ToString();
            var eMonth = EndDate.DateTime.Month < 10 ? $"0{EndDate.DateTime.Month}" : EndDate.DateTime.Month.ToString();
            var eDay = EndDate.DateTime.Day < 10 ? $"0{EndDate.DateTime.Day}" : EndDate.DateTime.Day.ToString();

            var startDate = $"{StartDate.DateTime.Year}-{sMonth}-{sDay}";
            var endDate = $"{EndDate.DateTime.Year}-{eMonth}-{eDay}";

            foreach (var campingPlace in _campingPlaces)
            {
                var campingNumbers = campingPlace.Value;

                var AllAcommodationsTask = Task.Run(async () =>
                {
                    var res = await _reservationsClient.GetByAccommodation(campingNumbers.ToArray(), startDate, endDate);
                    _ = res != null ? _response = res : _response = new List<ReservationModel>();
                });
                AllAcommodationsTask.Wait();

                var whole = campingNumbers.Count();
                var part = _response.Count();
                var gradientOffset = float.Parse($"0.{(part * 100) / whole}");

                var newColor = GetRelativeColorOfLegend(gradientOffset);

                switch (campingPlace.Key)
                {
                    case "1_7":
                        HeatmapColor1_7 = new SolidColorBrush(newColor);
                        break;
                    case "8_11":
                        HeatmapColor8_11 = new SolidColorBrush(newColor);
                        break;
                    case "12_15":
                        HeatmapColor12_15 = new SolidColorBrush(newColor);
                        break;
                    case "16_22":
                        HeatmapColor16_22 = new SolidColorBrush(newColor);
                        break;
                    case "23_29":
                        HeatmapColor23_29 = new SolidColorBrush(newColor);
                        break;
                }
            }
        }

        public Color GetRelativeColorOfLegend(float offset)
        {
            var gsc = LegendColor.GradientStops;
            var point = gsc.SingleOrDefault(x => x.Offset == offset);

            if (point != null)
            {
                return new Color
                {
                    A = COLOR_A,
                    R = point.Color.R,
                    G = point.Color.G,
                    B = point.Color.B
                };
            }

            var before = gsc.Where(x => x.Offset == gsc.Min(m => m.Offset)).First();
            var after = gsc.Where(x => x.Offset == gsc.Max(m => m.Offset)).First();

            foreach (var gs in gsc)
            {
                if (gs.Offset < offset && gs.Offset > before.Offset)
                    before = gs;
                if (gs.Offset > offset && gs.Offset < after.Offset)
                    after = gs;
            }

            return new Color
            {
                A = COLOR_A,
                R = (byte)((offset - before.Offset) * (after.Color.R - before.Color.R) / (after.Offset - before.Offset) + before.Color.R),
                G = (byte)((offset - before.Offset) * (after.Color.G - before.Color.G) / (after.Offset - before.Offset) + before.Color.G),
                B = (byte)((offset - before.Offset) * (after.Color.B - before.Color.B) / (after.Offset - before.Offset) + before.Color.B)
            };
        }
    }
}
