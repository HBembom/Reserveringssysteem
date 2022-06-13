using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class StreetName
    {
        const int MINIMUM_STREETNAME_LENGTH = 1;
        const int MAXIMUM_STREETNAME_LENGTH = 20;
        const string ALLOWED_CHARACTERS = "^[A-Za-z0-9_]*$";
        public readonly string Value;

        public StreetName(string streetName)
        {
            CheckIfNameLengthIsInclusive(streetName);
            CheckIfStringContainsIllegalCharacters(streetName);
            Value = streetName;
        }
        private void CheckIfNameLengthIsInclusive(string name)
        {
            if (name.Length < MINIMUM_STREETNAME_LENGTH || MAXIMUM_STREETNAME_LENGTH > 20)
            {
                throw new ArgumentException("StreetName is too long");
            };
        }

        private void CheckIfStringContainsIllegalCharacters(string name)
        {
            if (!Regex.IsMatch(name, ALLOWED_CHARACTERS))
            {
                throw new ArgumentException("Streetname is not a valid input");
            }
        }
    }
}