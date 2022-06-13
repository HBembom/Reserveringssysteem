using ReservationSystem.Core.Model.Names;
using System;

namespace ReservationSystem.Core.Model
{
    public class GuestContactDetail
    {
        public readonly Name FirstName;
        public readonly Name LastName;
        public readonly Name PrefixName;
        public readonly Name StreetName;
        public readonly LicensePlateName LicensePlate;

        public GuestContactDetail(FirstName firstName, LastName lastName, PrefixName prefixName, StreetName streetName, LicensePlateName licensePlate)
        {
            FirstName = firstName;
            LastName = lastName;
            PrefixName = prefixName;
            StreetName = streetName;
            LicensePlate = licensePlate;
        }
    }
}