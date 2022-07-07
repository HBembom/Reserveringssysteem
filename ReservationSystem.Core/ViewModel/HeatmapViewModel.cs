using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using ReservationSystem.Core.Clients;
using Windows.Foundation;
using System.Runtime.CompilerServices;

namespace ReservationSystem.Core.ViewModel
{
    internal class HeatmapViewModel : ViewModelBase
    {
        private SolidColorBrush _1_7HeatmapColor;
        public SolidColorBrush HeatmapColor1_7
        {
            get { return _1_7HeatmapColor; }
            set
            {
                _1_7HeatmapColor = value;
                OnPropertyChanged(nameof(HeatmapColor1_7));
            }
        }

        private SolidColorBrush _8_11HeatmapColor;
        public SolidColorBrush HeatmapColor8_11
        {
            get { return _8_11HeatmapColor; }
            set
            {
                _8_11HeatmapColor = value;
                OnPropertyChanged(nameof(HeatmapColor8_11));
            }
        }

        private SolidColorBrush _12_15HeatmapColor;
        public SolidColorBrush HeatmapColor12_15
        {
            get { return _12_15HeatmapColor; }
            set
            {
                _12_15HeatmapColor = value;
                OnPropertyChanged(nameof(HeatmapColor12_15));
            }
        }

        private SolidColorBrush _16_22HeatmapColor;
        public SolidColorBrush HeatmapColor16_22
        {
            get { return _16_22HeatmapColor; }
            set
            {
                _16_22HeatmapColor = value;
                OnPropertyChanged(nameof(HeatmapColor16_22));
            }
        }

        private SolidColorBrush _23_29HeatmapColor;
        public SolidColorBrush HeatmapColor23_29
        {
            get { return _23_29HeatmapColor; }
            set
            {
                _23_29HeatmapColor = value;
                OnPropertyChanged(nameof(HeatmapColor23_29));
            }
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
            set
            {
                _endDate = value;
                _startDate = value.AddDays(-7);
                UpdateHeatmapColors();
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private LinearGradientBrush _LegendColor;
        public LinearGradientBrush LegendColor
        {
            get { return _LegendColor; }
            set { _LegendColor = value; }
        }
        private Dictionary<string, List<int>> _campingPlaces { get; } = new Dictionary<string, List<int>>();
        private ReservationsClient _reservationsClient { get; set; } = new ReservationsClient();
        private List<ReservationModel> _response { get; set; } = new List<ReservationModel>();

        public HeatmapViewModel()
        {
            _startDate = DateTimeOffset.Now;
            _endDate = DateTimeOffset.Now.AddDays(7);
            _LegendColor = new LinearGradientBrush();

            _campingPlaces.Add("1_7", new List<int>() { 1, 2, 3, 4, 5, 6, 7 });
            _campingPlaces.Add("8_11", new List<int>() { 8, 9, 10, 11 });
            _campingPlaces.Add("12_15", new List<int>() { 12, 13, 14, 15 });
            _campingPlaces.Add("16_22", new List<int>() { 16, 17, 18, 19, 20, 21, 22 });
            _campingPlaces.Add("23_29", new List<int>() { 23, 24, 25, 26, 27, 28, 29 });

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
            var sMonth = _startDate.DateTime.Month < 10 ? $"0{_startDate.DateTime.Month}" : _startDate.DateTime.Month.ToString();
            var sDay = _startDate.DateTime.Day < 10 ? $"0{_startDate.DateTime.Day}" : _startDate.DateTime.Day.ToString();
            var eMonth = _endDate.DateTime.Month < 10 ? $"0{_endDate.DateTime.Month}" : _endDate.DateTime.Month.ToString();
            var eDay = _endDate.DateTime.Day < 10 ? $"0{_endDate.DateTime.Day}" : _endDate.DateTime.Day.ToString();

            var startDate = $"{_startDate.DateTime.Year}-{sMonth}-{sDay}";
            var endDate = $"{_endDate.DateTime.Year}-{eMonth}-{eDay}";

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
            {
                return new Color
                {
                    A = 195,
                    R = point.Color.R,
                    G = point.Color.G,
                    B = point.Color.B,
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

            var color = new Color
            {
                A = 195,
                R = (byte)((offset - before.Offset) * (after.Color.R - before.Color.R) / (after.Offset - before.Offset) + before.Color.R),
                G = (byte)((offset - before.Offset) * (after.Color.G - before.Color.G) / (after.Offset - before.Offset) + before.Color.G),
                B = (byte)((offset - before.Offset) * (after.Color.B - before.Color.B) / (after.Offset - before.Offset) + before.Color.B)
            };

            return color;
        }
    }
}
