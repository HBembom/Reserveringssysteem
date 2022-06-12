namespace ReservationSystem.Core.Model.OccupancyOverview
{
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
            public GridOccupancyOverviewBasisCreator GridCreator;
            public int AmmountOfAccommodations;
            public List<Reservation> Reservations;
            public DateTime SelectedWeek;
            public Grid _grid;
            private DateTime datetime;
            private int PitchCountIndex;
            private List<DateTimeColumnSpan> DateTimeColumnSpans;
            private DateTimeColumnSpan _minDateTimeColumnSpan;
            private DateTimeColumnSpan _maxDateTimeColumnSpan;

            public OccupancyOverview(int accomodations, List<Reservation> reservations, Grid grid, DateTime selectedWeek)
            {
                this.AmmountOfAccommodations = accomodations;
                this.Reservations = reservations;
                _grid = grid;
                this.SelectedWeek = selectedWeek;
                this.PitchCountIndex = 1;
                this.DateTimeColumnSpans = new List<DateTimeColumnSpan>();
                this.datetime = this.SelectedWeek;
            }

            public Grid Draw()
            {
                CreateGrid();
                FillOverview();
                return _grid;
            }

            public void CreateGrid()
            {
                CreateCollumns();
                CreateRows();
                CreateDateTimeAndPitchIndex();
            }

            public void FillOverview()
            {
                this._minDateTimeColumnSpan = GetMinimumColumnSpan();
                this._maxDateTimeColumnSpan = GetMaximumColumnSpan();

                foreach (Reservation reservation in Reservations)
                {
                    foreach (Accomodation accomodation in reservation.Accomodations)
                    {
                        int rowIndex = accomodation.ID.value;

                        if (ArrivalAndDepartureIsBeforeScope(reservation))
                        {

                        }
                        else if (ArrivalIsBeforeScopeAndDepartureIsWithinScope(reservation))
                        {
                            DateTimeColumnSpan minimumScopeDateTime = _minDateTimeColumnSpan;
                            DateTime departureTime = reservation.DurationOfStay.DepartureDateTime;
                            int totalDays = (departureTime - minimumScopeDateTime.DateTime).Days * 2 + 1;

                            if (reservation.hasPaid.GetStatus() == false)
                            {
                                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Red),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleTwo, minimumScopeDateTime.ColumnNumber - 1);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, totalDays);
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
                                Grid.SetColumn(rextangleTwo, minimumScopeDateTime.ColumnNumber - 1);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, totalDays);
                                _grid.Children.Add(rextangleTwo);
                            }

                            TextBlock textBlockTwo = new TextBlock()
                            {
                                Text = reservation.ContactDetail.LastName.value,
                                TextAlignment = TextAlignment.Center,
                                FontSize = 25,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };

                            Grid.SetColumn(textBlockTwo, minimumScopeDateTime.ColumnNumber - 1);
                            Grid.SetRow(textBlockTwo, rowIndex);
                            Grid.SetColumnSpan(textBlockTwo, totalDays);
                            _grid.Children.Add(textBlockTwo);
                        }
                        else if (ArrivalAndDepartureIsWithinScope(reservation))
                        {
                            AmmountOfNights ammountOfNights = reservation.DurationOfStay.GetAmmountOfNights();
                            int columnSpan = ammountOfNights.Value * 2;
                            DateTimeColumnSpan dateTimeIndex = GetDateTimeIndex(reservation);

                            if (reservation.hasPaid.GetStatus() == false)
                            {
                                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Red),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, columnSpan);
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
                                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, columnSpan);
                                _grid.Children.Add(rextangleTwo);
                            }

                            TextBlock textBlockTwo = new TextBlock()
                            {
                                Text = reservation.ContactDetail.LastName.value,
                                TextAlignment = TextAlignment.Center,
                                FontSize = 25,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };

                            Grid.SetColumn(textBlockTwo, dateTimeIndex.ColumnNumber);
                            Grid.SetRow(textBlockTwo, rowIndex);
                            Grid.SetColumnSpan(textBlockTwo, columnSpan);
                            _grid.Children.Add(textBlockTwo);
                        }
                        else if (ArrivalAndDepartureAreOutsideScope(reservation))
                        {
                            int ammountOfNights = DateTimeColumnSpans.Count * 2;

                            if (reservation.hasPaid.GetStatus() == false)
                            {
                                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Red),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleTwo, _minDateTimeColumnSpan.ColumnNumber - 1);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
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
                                Grid.SetColumn(rextangleTwo, _minDateTimeColumnSpan.ColumnNumber - 1);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
                                _grid.Children.Add(rextangleTwo);
                            }

                            TextBlock textBlockTwo = new TextBlock()
                            {
                                Text = reservation.ContactDetail.LastName.value,
                                TextAlignment = TextAlignment.Center,
                                FontSize = 25,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };

                            Grid.SetColumn(textBlockTwo, _minDateTimeColumnSpan.ColumnNumber - 1);
                            Grid.SetRow(textBlockTwo, rowIndex);
                            Grid.SetColumnSpan(textBlockTwo, ammountOfNights);
                            _grid.Children.Add(textBlockTwo);
                        }
                        else if (ArrivalIsInsideScopeButDepartureIsNot(reservation))
                        {
                            DateTimeColumnSpan dateTimeIndex = GetDateTimeIndex(reservation);
                            DateTimeColumnSpan maxDateTimeColumnSpan = GetMaximumColumnSpan();
                            int ammountOfNights = (maxDateTimeColumnSpan.DateTime - dateTimeIndex.DateTime).Days * 2;

                            if (ammountOfNights == 0)
                            {
                                ammountOfNights = 1;
                            }

                            if (reservation.hasPaid.GetStatus() == false)
                            {
                                Windows.UI.Xaml.Shapes.Rectangle rextangleTwo = new Windows.UI.Xaml.Shapes.Rectangle()
                                {
                                    Stroke = new SolidColorBrush(Colors.Black),
                                    StrokeThickness = 2,
                                    Fill = new SolidColorBrush(Colors.Red),
                                    Margin = new Thickness(0, 5, 0, 5)
                                };
                                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
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
                                Grid.SetColumn(rextangleTwo, dateTimeIndex.ColumnNumber);
                                Grid.SetRow(rextangleTwo, rowIndex);
                                Grid.SetColumnSpan(rextangleTwo, ammountOfNights);
                                _grid.Children.Add(rextangleTwo);
                            }

                            TextBlock textBlockTwo = new TextBlock()
                            {
                                Text = reservation.ContactDetail.LastName.value,
                                TextAlignment = TextAlignment.Center,
                                FontSize = 25,
                                HorizontalAlignment = HorizontalAlignment.Center,
                            };

                            Grid.SetColumn(textBlockTwo, dateTimeIndex.ColumnNumber);
                            Grid.SetRow(textBlockTwo, rowIndex);
                            Grid.SetColumnSpan(textBlockTwo, ammountOfNights);
                            _grid.Children.Add(textBlockTwo);
                        }
                    }
                }
            }

            private DateTimeColumnSpan GetDateTimeIndex(Reservation reservation)
            {
                DateTimeColumnSpan span = GetMinimumColumnSpan();

                foreach (DateTimeColumnSpan dateTime in DateTimeColumnSpans)
                {
                    if (dateTime.DateTime == reservation.DurationOfStay.ArrivalDateTime)
                    {
                        span = dateTime;
                    }
                }

                return span;
            }

            private bool ArrivalIsInsideScopeButDepartureIsNot(Reservation reservation)
            {
                if (ArrivalIsTimeIsWithinScope(reservation) && DepartureIsAfterScope(reservation))
                {
                    return true;
                }

                return false;

            }

            private bool ArrivalAndDepartureAreOutsideScope(Reservation reservation)
            {
                if (ArrivalTimeIsBeforeScope(reservation) && DepartureIsAfterScope(reservation))
                {
                    return true;
                }

                return false;
            }

            private bool DepartureIsAfterScope(Reservation reservation)
            {
                if (reservation.DurationOfStay.DepartureDateTime > _maxDateTimeColumnSpan.DateTime)
                {
                    return true;
                }

                return false;
            }

            private bool ArrivalAndDepartureIsWithinScope(Reservation reservation)
            {
                if (ArrivalIsTimeIsWithinScope(reservation) && DepartureTimeIsWithinScope(reservation))
                {
                    return true;
                }

                return false;
            }

            private bool ArrivalIsBeforeScopeAndDepartureIsWithinScope(Reservation reservation)
            {
                if (ArrivalTimeIsBeforeScope(reservation) && DepartureTimeIsWithinScope(reservation))
                {
                    return true;
                }

                return false;
            }

            private bool ArrivalAndDepartureIsBeforeScope(Reservation reservation)
            {
                if (ArrivalTimeIsBeforeScope(reservation) && DepartureTimeIsBeforeScope(reservation))
                {
                    return true;
                }
                return false;
            }
            private bool ArrivalIsTimeIsWithinScope(Reservation reservation)
            {
                if (reservation.DurationOfStay.ArrivalDateTime >= _minDateTimeColumnSpan.DateTime && reservation.DurationOfStay.ArrivalDateTime <= _maxDateTimeColumnSpan.DateTime)
                {
                    return true;
                }

                return false;
            }

            private bool DepartureTimeIsWithinScope(Reservation reservation)
            {
                if (reservation.DurationOfStay.DepartureDateTime >= _minDateTimeColumnSpan.DateTime && reservation.DurationOfStay.DepartureDateTime <= _maxDateTimeColumnSpan.DateTime)
                {
                    return true;
                }

                return false;
            }

            private bool ArrivalTimeIsBeforeScope(Reservation reservation)
            {
                if (reservation.DurationOfStay.ArrivalDateTime < _minDateTimeColumnSpan.DateTime)
                {
                    return true;
                }

                return false;
            }

            private bool DepartureTimeIsBeforeScope(Reservation reservation)
            {
                if (reservation.DurationOfStay.DepartureDateTime < _minDateTimeColumnSpan.DateTime)
                {
                    return true;
                }

                return false;
            }

            private DateTimeColumnSpan GetMinimumColumnSpan()
            {
                int minColumn = _grid.ColumnDefinitions.Count;
                DateTimeColumnSpan span = new DateTimeColumnSpan(DateTime.Now, 0);

                foreach (DateTimeColumnSpan ColumnSpan in DateTimeColumnSpans)
                {
                    if (ColumnSpan.ColumnNumber < minColumn)
                    {
                        minColumn = ColumnSpan.ColumnNumber;
                        span = ColumnSpan;
                    }
                }

                return span;
            }

            private DateTimeColumnSpan GetMaximumColumnSpan()
            {
                int minColumn = 0;
                DateTimeColumnSpan span = new DateTimeColumnSpan(DateTime.Now, 0);

                foreach (DateTimeColumnSpan ColumnSpan in DateTimeColumnSpans)
                {
                    if (ColumnSpan.ColumnNumber > minColumn)
                    {
                        minColumn = ColumnSpan.ColumnNumber;
                        span = ColumnSpan;
                    }
                }

                return span;
            }

            private void CreateDateTimeAndPitchIndex()
            {
                for (int row = 0; row < _grid.RowDefinitions.Count; row++)
                {
                    for (int column = 0; column < _grid.ColumnDefinitions.Count; column++)
                    {
                        if (row == 0 && column == 0)
                        {
                            CreatePitchNumberTextBox(row, column);
                        }
                        if (row == 0)
                        {
                            CreateDateTimeGrids(row, column);
                            column += 1;
                        }
                        if (row > 0 && column == 0)
                        {
                            CreatePitchGrid(row, column);
                        }
                        if (row > 0 && column > 0)
                        {
                            CreateEmptyTimeSpanGrid(row, column);
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
                DateTimeColumnSpans.Add(new DateTimeColumnSpan(datetime, column + 2));
                _grid.Children.Add(textBlock);
                datetime = datetime.AddDays(1);
            }

            private void CreatePitchNumberTextBox(int row, int column)
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

            public void CreateCollumns()
            {
                for (int i = 0; i < 14; i++)
                {
                    if (i == 0)
                    {
                        _grid.ColumnDefinitions.Add(new ColumnDefinition()
                        {
                            Width = new GridLength(75),
                        });
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
                for (int i = 0; i <= AmmountOfAccommodations; i++)
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

}
