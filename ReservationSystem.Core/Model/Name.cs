using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class Name
    {
        public readonly string value;

        public Name(string name)
        {
            CheckIfLenghtIsNotLongerThanTwenty(name);
            CheckIfStringContainsIllegalCharacters(name);
            value = name;
        }

        private void CheckIfLenghtIsNotLongerThanTwenty(string firstName)
        {
            if (firstName.Length > 20)
            {
                throw new ArgumentException("Name is too long");
            };
        }

        private static void CheckIfStringContainsIllegalCharacters(string firstName)
        {
            if (!Regex.IsMatch(firstName, "^[a-zA]*$"))
            {
                throw new ArgumentException("Name is not a valid input");
            }
        }
    }
}