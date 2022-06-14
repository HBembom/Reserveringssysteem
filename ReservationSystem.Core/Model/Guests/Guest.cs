namespace ReservationSystem.Core.Model
{
    public abstract class Guest
    {
        public Price Price;
        public AmmountOfNights AmmountOfNights;

        public Guest(Price price, AmmountOfNights ammountOfNights)
        {
            Price = price;
            AmmountOfNights = ammountOfNights;
        }

        public double GetPrice()
        {
            return Price.Value;
        }

        public int GetAmmountOfNights()
        {
            return AmmountOfNights.Value;
        }

        public double GetPriceMultipliedByNights()
        {
            return Price.Value * AmmountOfNights.Value;
        }
    }
}
