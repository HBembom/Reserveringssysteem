using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class LicensePlate
    {
        const int MINIMUM_lICENSEPLATE_LENGTH = 1;
        const int MAXIMUM_lICENSEPLATE_LENGTH = 20;
        const string ALLOWED_CHARACTERS = "[A-Za-z0-9.-]";
        public readonly string Value;

        public LicensePlate(string LicensePlate)
        {
            CheckIfNameLengthIsInclusive(LicensePlate);
            CheckIfStringContainsIllegalCharacters(LicensePlate);
            Value = LicensePlate.ToUpper();
        }
        private void CheckIfNameLengthIsInclusive(string name)
        {
            if (name.Length < MINIMUM_lICENSEPLATE_LENGTH || MAXIMUM_lICENSEPLATE_LENGTH > 20)
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