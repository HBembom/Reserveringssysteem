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
        private int PitchCountIndex;
        private List<DateTimeColumnSpan> DateTimeColumnSpans; 
       
        public OccupancyOverview(List<Accomodation> accomodations, List<Reservation> reservations, Grid grid, DateTime selectedWeek)
        {
            _grid = grid;
            this.SelectedWeek = selectedWeek.AddDays(1);
            this.Accomodations = accomodations;
            this.Reservations = reservations;
            datetime = SelectedWeek;
            this.PitchCountIndex = 1;
            this.DateTimeColumnSpans = new List<DateTimeColumnSpan>();
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
                    // Create DateTimeColumns in Grid
                    if (row == 0 && column == 0)
                    {
                        TextBlock textBlockOne = new TextBlock()
                        {
                            Text = "PitchNumber",
                            TextAlignment = TextAlignment.Center,
                            FontSize = 10,
                            HorizontalAlignment = HorizontalAlignment.Center,
                        };

                        Grid.SetColumn(textBlockOne, column);
                        Grid.SetRow(textBlockOne, row);
                        _grid.Children.Add(textBlockOne);
                    }
                    if (row == 0)
                    {
                        CreateDateTimeGrids(row, column);
                        column += 1;
                    }
                    // Create Rectangles and Textboxes in Grid
                    if (row > 0 && column > 0)
                    {
                        DateTimeColumnSpan dateTimeColumnSpan = new DateTimeColumnSpan(datetime, 0);
                        dateTimeColumnSpan = GetMatchingDates(column, dateTimeColumnSpan);
                        
                        // datum gebruik en vergelijken met dataspanlist en de juiste columnumber ophalen. 


                        if (IsMatch(dateTimeColumnSpan, row, column))
                        {                  
                            Reservation reservation = GetReservation(dateTimeColumnSpan, row);
                            AmmountOfNights nights = reservation.DurationOfStay.GetAmmountOfNights();
                            
                            if ((dateTimeColumnSpan.ColumnNumber + nights.Value) > _grid.ColumnDefinitions.Count)
                            {
                                Windows.UI.Xaml.Shapes.Rectangle rextangleOne = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Green),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleOne, ((column + nights.Value) - _grid.ColumnDefinitions.Count));
                                Grid.SetRow(rextangleOne, row);
                                Grid.SetColumnSpan(rextangleOne, (column + nights.Value) - _grid.ColumnDefinitions.Count);
                                _grid.Children.Add(rextangleOne);

                                TextBlock textBlockOne = new TextBlock()
                                {
                                    Text = reservation.ContactDetail.LastName.value,
                                    TextAlignment = TextAlignment.Center,
                                    FontSize = 25,
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                };

                                Grid.SetColumn(textBlockOne, column);
                                Grid.SetRow(textBlockOne, row);
                                Grid.SetColumnSpan(textBlockOne, (nights.Value) - _grid.ColumnDefinitions.Count);
                                _grid.Children.Add(textBlockOne);
                            }
                            else if(reservation.DurationOfStay.ArrivalDateTime < dateTimeColumnSpan.DateTime)
                            {
                                var tempColumn = dateTimeColumnSpan.DateTime.Subtract(reservation.DurationOfStay.ArrivalDateTime).Days;

                                Windows.UI.Xaml.Shapes.Rectangle rextangleOne = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Green),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleOne, tempColumn);
                                Grid.SetRow(rextangleOne, row);
                                Grid.SetColumnSpan(rextangleOne, tempColumn);
                                _grid.Children.Add(rextangleOne);

                                TextBlock textBlockOne = new TextBlock()
                                {
                                    Text = reservation.ContactDetail.LastName.value,
                                    TextAlignment = TextAlignment.Center,
                                    FontSize = 25,
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                };

                                Grid.SetColumn(textBlockOne, tempColumn);
                                Grid.SetRow(textBlockOne, row);
                                Grid.SetColumnSpan(textBlockOne, tempColumn);
                                _grid.Children.Add(textBlockOne);
                            }

                            else
                            {
                                if (reservation.hasPaid.GetStatus() == false)
                                {
                                    Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                    {
                                        Stroke = new SolidColorBrush(Colors.Black),
                                        StrokeThickness = 2,
                                        Fill = new SolidColorBrush(Colors.Red),
                                        Margin = new Thickness(0, 5, 0, 5)
                                    };
                                    Grid.SetColumn(rextangleTwo, column);
                                    Grid.SetRow(rextangleTwo, row);
                                    Grid.SetColumnSpan(rextangleTwo, 1 + nights.Value);
                                    _grid.Children.Add(rextangleTwo);
                                }
                                else
                                {
                                    Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                    {
                                        Stroke = new SolidColorBrush(Colors.Black),
                                        StrokeThickness = 2,
                                        Fill = new SolidColorBrush(Colors.Green),
                                        Margin = new Thickness(0, 5, 0, 5)
                                    };
                                    Grid.SetColumn(rextangleTwo, column);
                                    Grid.SetRow(rextangleTwo, row);
                                    Grid.SetColumnSpan(rextangleTwo, 1 + nights.Value);
                                    _grid.Children.Add(rextangleTwo);
                                }

                                TextBlock textBlockTwo = new TextBlock()
                                {
                                    Text = reservation.ContactDetail.LastName.value,
                                    TextAlignment = TextAlignment.Center,
                                    FontSize = 25,
                                    HorizontalAlignment = HorizontalAlignment.Center,
                                };

                                Grid.SetColumn(textBlockTwo, column);
                                Grid.SetRow(textBlockTwo, row);
                                Grid.SetColumnSpan(textBlockTwo, 1 + nights.Value);
                                _grid.Children.Add(textBlockTwo);
                                column += nights.Value;
                            }
                        }
                        else
                        {
                            CreateEmptyTimeSpanGrid(row, column);
                        }
                    }
                    // Create PitchNr In Grids
                    if (row > 0 && column == 0)
                    {
                        CreatePitchGrid(row, column);
                    }
                }
            }
        }

        private void CreateEmptyTimeSpanGrid(int row, int column)
        {
            Windows.UI.Xaml.Shapes.Rectangle rextangle = new Windows.UI.Xaml.Shapes.Rectangle()
            {
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0, 5, 0, 5)
            };
            Grid.SetColumn(rextangle, column);
            Grid.SetRow(rextangle, row);
            _grid.Children.Add(rextangle);

            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            _grid.Children.Add(textBlock);
        }

        private void CreatePitchGrid(int row, int column)
        {
            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            textBlock.Text = PitchCountIndex.ToString();
            PitchCountIndex++;
            Grid.SetColumn(textBlock, column);
            Grid.SetRow(textBlock, row);
            _grid.Children.Add(textBlock);
        }

        private void CreateDateTimeGrids(int row, int column)
        {
            TextBlock textBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                Text = datetime.ToString("dddd, dd MMMM yyyy")
            };

            Grid.SetColumn(textBlock, column + 1);
            Grid.SetRow(textBlock, row);
            Grid.SetColumnSpan(textBlock, 2);
            DateTimeColumnSpans.Add(new DateTimeColumnSpan(datetime, column + 1));
            _grid.Children.Add(textBlock);
            datetime = datetime.AddDays(1);
        }

        private DateTimeColumnSpan GetMatchingDates(int column, DateTimeColumnSpan dateTimeColumnSpan)
        {
            foreach (DateTimeColumnSpan DateTimeColumnSpan in DateTimeColumnSpans)
            {
                if (DateTimeColumnSpan.ColumnNumber.Equals(column))
                {
                    dateTimeColumnSpan = DateTimeColumnSpan;
                }
            }

            return dateTimeColumnSpan;
        }

        public bool IsMatch(DateTimeColumnSpan dateTimeColumnSpan, int row, int column)
        {

            foreach (Reservation reservation in Reservations)
            {
                if (reservation.DurationOfStay.ArrivalDateTime.Year == dateTimeColumnSpan.DateTime.Year && reservation.DurationOfStay.ArrivalDateTime.Month == dateTimeColumnSpan.DateTime.Month && reservation.DurationOfStay.ArrivalDateTime.Day == dateTimeColumnSpan.DateTime.Day || reservation.DurationOfStay.DepartureDateTime.Year == dateTimeColumnSpan.DateTime.Year && reservation.DurationOfStay.DepartureDateTime.Month == dateTimeColumnSpan.DateTime.Month && reservation.DurationOfStay.DepartureDateTime.Day == dateTimeColumnSpan.DateTime.Day)
                {
                    if(dateTimeColumnSpan.ColumnNumber == column)
                    {
                        foreach (Accomodation accomdation in reservation.Accomodations)
                        {
                            if (accomdation.ID.value.Equals(row))
                            {
                                return true;
                            }
                        }
                    }  
                }
            }
            return false;
        }

        public Reservation GetReservation(DateTimeColumnSpan dateTimeColumnSpan, int row)
        {
            foreach (Reservation reservation in Reservations)
            {
                if (reservation.DurationOfStay.ArrivalDateTime.Year == dateTimeColumnSpan.DateTime.Year && reservation.DurationOfStay.ArrivalDateTime.Month == dateTimeColumnSpan.DateTime.Month && reservation.DurationOfStay.ArrivalDateTime.Day == dateTimeColumnSpan.DateTime.Day || reservation.DurationOfStay.DepartureDateTime.Year == dateTimeColumnSpan.DateTime.Year && reservation.DurationOfStay.DepartureDateTime.Month == dateTimeColumnSpan.DateTime.Month && reservation.DurationOfStay.DepartureDateTime.Day == dateTimeColumnSpan.DateTime.Day)
                {
                    foreach (Accomodation accomdation in reservation.Accomodations)
                    {
                        if (accomdation.ID.value.Equals(row))
                        {
                            return reservation;
                        }
                    }
                }
            }
            return null;
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
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.White),
                Margin = new Thickness(0, 5, 0, 5)
            };
        }

        //private void AddTextBlockDateTime(int row, int column)
        //{
        //    TextBlock textBlock = new TextBlock()
        //    {
        //        Text = datetime.ToString()
        //    };

        //    Grid.SetColumn(textBlock, column);
        //    Grid.SetRow(textBlock, row);
        //    Grid.SetColumnSpan(textBlock, 2);
        //    _grid.Children.Add(textBlock);
        //    datetime = datetime.AddDays(1);
        //}

        //private void AddTextBlockPitch(int row, int column)
        //{
        // TextBlock textBlock = CreateTextBlockPitch();
        // textBlock.Text = PitchCountIndex.ToString();
        //    PitchCountIndex++;
        //    Grid.SetColumn(textBlock, column);
        //    Grid.SetRow(textBlock, row);
        //    _grid.Children.Add(textBlock);
        //}



        //private TextBlock CreateTextBlockPitch()
        //{
        //    return new TextBlock()
        //{
        //    TextAlignment = TextAlignment.Center,
        //        FontSize = 25,
        //        HorizontalAlignment = HorizontalAlignment.Center,
        //    };
        //}

        //private void AddTextBlockOccupancy(int row, int column, int columnSpan)
        //{
        //    foreach (Reservation reservation in Reservations)
        //    {
        //            TextBlock textBlock = CreateTextBlockGuest(reservation);
        //            Grid.SetColumn(textBlock, column);
        //            Grid.SetRow(textBlock, row);
        //            Grid.SetColumnSpan(textBlock, columnSpan);
        //            _grid.Children.Add(textBlock);
        //    }
        //}

        //private void AddRectangleOccupancy(int row, int column, int columnSpan)
        //{
        //    foreach (Reservation reservation in Reservations)
        //    {
        //            Windows.UI.Xaml.Shapes.Rectangle rextangle = CreateRectangle(reservation);
        //            Grid.SetColumn(rextangle, column);
        //            Grid.SetRow(rextangle, row);
        //            Grid.SetColumnSpan(rextangle, columnSpan);
        //            _grid.Children.Add(rextangle);
        //    }
        //}

        //private TextBlock CreateTextBlockGuest(Reservation reservation)
        //{
        //        return new TextBlock()
        //{
        //    Text = reservation.ContactDetail.LastName.value,
        //            TextAlignment = TextAlignment.Center,
        //            FontSize = 25,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //        };
        //}

        //private TextBlock CreateTextBlockDateTime()
        //{
        //    return new TextBlock()
        //    {
        //        Text = DateTime.UtcNow.ToString(),
        //        TextAlignment = TextAlignment.Center,
        //        FontSize = 25,
        //        HorizontalAlignment = HorizontalAlignment.Center,
        //    };
        //}

        //private Windows.UI.Xaml.Shapes.Rectangle CreateRectangle(Reservation reservation)
        //{          
        //    if (reservation.haspaid.getstatus())
        //    {
        //        return new windows.ui.xaml.shapes.rectangle()
        //        {
        //            stroke = new solidcolorbrush(colors.black),
        //            strokethickness = 10,
        //            fill = new solidcolorbrush(colors.green),
        //        };
        //    }
        //    else 
        //    {
        //        return new windows.ui.xaml.shapes.rectangle()
        //        {
        //            stroke = new solidcolorbrush(colors.black),
        //            strokethickness = 10,
        //            fill = new solidcolorbrush(colors.red)
        //        };
        //    }
        //}


        public void CreateGrid()
        {
            CreateCollumns();
            CreateRows();
        }

        public void CreateCollumns()
        {
            for (int i = 0; i < 14; i++)
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
            for (int i = 0; i <= Accomodations.Count; i++)
            {
                if (i == 0)
                {
                    _grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(50)
                    });
                }
                else
                {
                    _grid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = new GridLength(40)
                    });
                }
            }
        }
    }
}
