namespace ReservationSystem.Core.Model
{
    public abstract class Guest
    {
        public Price Price;
        public AmmountOfNights AmmountOfNights;

        public Guest(Price price, AmmountOfNights ammountOfNights)
        {
            // Maybe Remove Price in Constructor and instead, make a call in the constructor to the database to retrieve prices (Abstract method necessary). 
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
