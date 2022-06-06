using ReservationSystem.Core.Model.Guests;
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview
{
    public class OccupancyOverview
    {
        public List<Accomodation> Accomodations;
        public List<Reservation> Reservations;
        public DateTime SelectedWeek;
        public Grid _grid;
        private DateTime datetime;


        public OccupancyOverview(List<Accomodation> accomodations, List<Reservation> reservations, Grid grid)
        {
            _grid = grid;
            this.SelectedWeek = DateTime.Now.AddDays(-1);
            this.Accomodations = accomodations;
            this.Reservations = reservations;
            datetime = SelectedWeek;
        }
        
        public Grid Draw()
        {
            CreateGrid();
            FillOverview();
            return _grid;
        }

        public void FillOverview()
        {
            for (int row = 0; row < _grid.RowDefinitions.Count; row++)
            {
                for (int column = 0; column < _grid.ColumnDefinitions.Count; column++)
                {
                    if (row == 0)
                    {
                        AddTextBlockDateTime(row, column);
                        column += 2;
                    }
                    else
                    {
                        foreach (Reservation reservation in Reservations)
                        {
                            if (reservation.DurationOfStay.ArrivalDateTime.DayOfWeek == SelectedWeek.DayOfWeek)
                            {
                                AmmountOfNights nights = reservation.DurationOfStay.GetAmmountOfNights();

                                if (column + nights.Value > _grid.ColumnDefinitions.Count)
                                {
                                    int columnsleft = column + nights.Value - _grid.ColumnDefinitions.Count;
                                    AddTextBlockOccupancy(row, column, columnsleft);
                                    AddRectangleOccupancy(row, column, nights.Value);
                                }

                                AddTextBlockOccupancy(row, column, nights.Value);
                                AddRectangleOccupancy(row, column, nights.Value);
                                column += nights.Value;
                            }
                            else
                            {
                                AddUnoccupiedRectangle(row, column);
                            }

                        }
                    }
                }
            }
        }

        private void AddUnoccupiedRectangle(int row, int column)
        {
            Windows.UI.Xaml.Shapes.Rectangle rextangle = CreateUnccupiedRectangle(row, column);
            Grid.SetColumn(rextangle, column);
            Grid.SetRow(rextangle, row);
            _grid.Children.Add(rextangle);
        }

        private Windows.UI.Xaml.Shapes.Rectangle CreateUnccupiedRectangle(int row, int column)
        {
            return new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 10,
                Fill = new SolidColorBrush(Colors.White)
            };
        }

        private void AddTextBlockDateTime(int row, int column)
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = datetime.ToString()
            };

            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            Grid.SetColumnSpan(textBlock, 2);
            _grid.Children.Add(textBlock);
            datetime = SelectedWeek.AddDays(1);
        }

        private void AddTextBlockOccupancy(int row, int column, int columnSpan)
        {
            foreach (Reservation reservation in Reservations)
            {
                    TextBlock textBlock = CreateTextBlockGuest(reservation);
                    Grid.SetColumn(textBlock, column);
                    Grid.SetRow(textBlock, row);
                    Grid.SetColumnSpan(textBlock, columnSpan);
                    _grid.Children.Add(textBlock);
            }
        }

        private void AddRectangleOccupancy(int row, int column, int columnSpan)
        {
            foreach (Reservation reservation in Reservations)
            {
                    Windows.UI.Xaml.Shapes.Rectangle rextangle = CreateRectangle(reservation);
                    Grid.SetColumn(rextangle, column);
                    Grid.SetRow(rextangle, row);
                    Grid.SetColumnSpan(rextangle, columnSpan);
                    _grid.Children.Add(rextangle);
            }
        }

        private TextBlock CreateTextBlockGuest(Reservation reservation)
        {
            return new TextBlock()
            {
                Text = reservation.ContactDetail.LastName.value,
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
        }

        private TextBlock CreateTextBlockDateTime()
        {
            return new TextBlock()
            {
                Text = DateTime.UtcNow.ToString(),
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
        }

        private Windows.UI.Xaml.Shapes.Rectangle CreateRectangle(Reservation reservation)
        {          
            if (reservation.hasPaid.GetStatus())
            {
                return new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                    Fill = new SolidColorBrush(Colors.Green),
                };
            }
            else 
            {
                return new Windows.UI.Xaml.Shapes.Rectangle()
                {
                    Stroke = new SolidColorBrush(Colors.Black),
                    StrokeThickness = 10,
                    Fill = new SolidColorBrush(Colors.Red)
                };
            }
        }

        public void CreateGrid()
        {
            CreateCollumns();
            CreateRows();
        }

        public void CreateCollumns()
        {
            for (int i = 0; i < 16; i++)
            {
                if(i == 0)
                {
                    _grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = new GridLength(75), 
                    }) ; 
                }
                else
                {
                    _grid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = new GridLength(100)
                    });
                }
            }
        }

        private void CreateRows()
        {
            for (int i = 0; i < Accomodations.Count; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(75)
                }) ;
            }
        }
    }
}
