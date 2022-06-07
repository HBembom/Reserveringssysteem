using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class FirstName
    {
        public readonly string value;

        public FirstName(string firstName)
        {
            CheckIfLenghtIsNotLongerThanTwenty(firstName);
            CheckIfStringContainsIllegalCharacters(firstName);
            value = firstName;
        }

        private void CheckIfLenghtIsNotLongerThanTwenty(string firstName)
        {
            if(firstName.Length > 20)
            {
                throw new ArgumentException("First Name is too long");
            };
        }

        private static void CheckIfStringContainsIllegalCharacters(string firstName)
        {
            if (!Regex.IsMatch(firstName, "^[a-zA]*$"))
            {
                throw new ArgumentException("First name is not a valid input");
            }
        }
    }
}