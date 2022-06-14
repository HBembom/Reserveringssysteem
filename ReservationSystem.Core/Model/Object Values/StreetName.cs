using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model.Names
{
    public class StreetName : Name
    {
        public StreetName(string streetName) : base(streetName)
        {
            MinimumLength = 1;
            MaximumLength = 20;
            AllowedCharacters = "[A-Za-z0-9_]";
        }
    }
}