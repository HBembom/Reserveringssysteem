using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class Name
    {
        const int MINIMUM_NAME_LENGTH = 1;
        const int MAXIMUM_NAME_LENGHT = 20;
        const string ALLOWED_CHARACTERS = "^[a-zA]*$";
        public readonly string value;

        public Name(string name)
        {
            CheckIfNameLengthIsInclusive(name);
            CheckIfStringContainsIllegalCharacters(name);
            value = name;
        }

        private void CheckIfNameLengthIsInclusive(string name)
        {
            if (name.Length < MINIMUM_NAME_LENGTH || MAXIMUM_NAME_LENGHT > 20)
            {
                throw new ArgumentException("Name is too long");
            };
        }

        private void CheckIfStringContainsIllegalCharacters(string name)
        {
            if (!Regex.IsMatch(name, ALLOWED_CHARACTERS))
            {
                throw new ArgumentException("Name is not a valid input");
            }
        }
    }
}