using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ReservationSystem.Core.Model.OccupancyOverview.ReservationSystem.Core.Model.OccupancyOverview
{
    public class AssignReservationGrid : IAssignElement
    {
        private Grid _grid;
        private List<Reservation> _reservations;
        private Scope _scope;
        private int _maxAmountOfNights;

        public AssignReservationGrid(Grid grid, List<Reservation> reservations, Scope scope)
        {
            this._grid = grid;
            this._reservations = reservations;
            this._scope = scope;
            this._maxAmountOfNights = grid.ColumnDefinitions.Count * 2;
        }

        public void AssignReservations()
        {
            foreach (Reservation reservation in _reservations)
            {
                foreach (Accomodation accomodation in reservation.Accomodations)
                {
                    int rowIndex = accomodation.ID.value;

                    if (ArrivalAndDepartureIsBeforeScope(reservation))
                    {

                    }
                    else if (ArrivalIsBeforeScopeAndDepartureIsWithinScope(reservation))
                    {
                        ArrivalBeforeAndDepartureWithinScopeStrategy strategy = new ArrivalBeforeAndDepartureWithinScopeStrategy(_grid, reservation, _scope);
                        strategy.AddElement(rowIndex, _scope.MinDateTimeColumnSpan.ColumnNumber - 1);
                    }
                    else if (ArrivalAndDepartureIsWithinScope(reservation))
                    {
                        ArrivalAndDepartureIsWithinScopeStrategy strategy = new ArrivalAndDepartureIsWithinScopeStrategy(_grid, reservation, _scope);
                        strategy.AddElement(rowIndex, reservation.DurationOfStay.GetAmmountOfNights().Value * 2);
                    }
                    else if (ArrivalAndDepartureAreOutsideScope(reservation))
                    {
                        ArrivalAndDepartureAreOutsideScopeStrategy strategy = new ArrivalAndDepartureAreOutsideScopeStrategy(_grid, reservation);
                        strategy.AddElement(rowIndex, _grid.ColumnDefinitions.Count * 2);
                    }
                    else if (ArrivalIsInsideScopeButDepartureIsNot(reservation))
                    {
                        ArrivalIsInsideButDepartureIsOutsideScopeStrategy strategy = new ArrivalIsInsideButDepartureIsOutsideScopeStrategy(_grid, reservation, _scope);
                        strategy.AddElement(rowIndex, (_scope.MaxDateTimeColumnSpan.DateTime - _scope.MinDateTimeColumnSpan.DateTime).Days * 2);
                    }
                }
            }
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
            if (reservation.DurationOfStay.DepartureDateTime > _scope.MaxDateTimeColumnSpan.DateTime)
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
            if (reservation.DurationOfStay.ArrivalDateTime >= _scope.MinDateTimeColumnSpan.DateTime && reservation.DurationOfStay.ArrivalDateTime <= _scope.MaxDateTimeColumnSpan.DateTime)
            {
                return true;
            }

            return false;
        }

        private bool DepartureTimeIsWithinScope(Reservation reservation)
        {
            if (reservation.DurationOfStay.DepartureDateTime >= _scope.MinDateTimeColumnSpan.DateTime && reservation.DurationOfStay.DepartureDateTime <= _scope.MaxDateTimeColumnSpan.DateTime)
            {
                return true;
            }

            return false;
        }

        private bool ArrivalTimeIsBeforeScope(Reservation reservation)
        {
            if (reservation.DurationOfStay.ArrivalDateTime < _scope.MinDateTimeColumnSpan.DateTime)
            {
                return true;
            }

            return false;
        }

        private bool DepartureTimeIsBeforeScope(Reservation reservation)
        {
            if (reservation.DurationOfStay.DepartureDateTime < _scope.MinDateTimeColumnSpan.DateTime)
            {
                return true;
            }

            return false;
        }

        public void AddElement(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}