using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model.Names
{
    public abstract class Name
    {
        public readonly string value;
        protected int MinimumLength;
        protected int MaximumLength;
        protected string AllowedCharacters;

        public Name(string name)
        {
            CheckIfNameLengthIsInclusive(name);
            CheckIfStringContainsIllegalCharacters(name);
            value = name;
        }

        private void CheckIfNameLengthIsInclusive(string name)
        {
            if (name.Length < MinimumLength || name.Length > MaximumLength)
            { 
                throw new ArgumentException(this.GetType().Name + " is too long");
            };
        }

        private void CheckIfStringContainsIllegalCharacters(string name)
        {
            if (!Regex.IsMatch(name, AllowedCharacters))
            {
                throw new ArgumentException(this.GetType().Name + " is not a valid input");
            }
        }
    }
}