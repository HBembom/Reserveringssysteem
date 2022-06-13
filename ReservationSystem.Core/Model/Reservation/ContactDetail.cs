using ReservationSystem.Core.Model.Names;

namespace ReservationSystem.Core.Model
{
    public class GuestContactDetail
    {
        public Name FirstName;
        public Name LastName;
        public Name PrefixName;
        public Name StreetName;
        public LicensePlateName LicensePlate;

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