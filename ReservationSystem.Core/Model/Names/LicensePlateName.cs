using ReservationSystem.Core.Model.Names;
using System;
using System.Text.RegularExpressions;

namespace ReservationSystem.Core.Model
{
    public class LicensePlateName : Name
    {
        const int MINIMUM_lICENSEPLATE_LENGTH = 1;
        const int MAXIMUM_lICENSEPLATE_LENGTH = 20;
        const string ALLOWED_CHARACTERS = "[A-Za-z0-9.-]";

        public LicensePlateName(string licensePlateName) : base(licensePlateName)
        {
            MinimumLength = 1;
            MaximumLength = 20;
            AllowedCharacters = "[a - zA]";
        }
    }
}