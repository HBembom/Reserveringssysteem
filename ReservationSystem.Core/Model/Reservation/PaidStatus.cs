namespace ReservationSystem.Core.Model
{
    public class PaidStatus
    {
        private bool paid;
        public PaidStatus()
        {
            this.paid = false;
        }

        public void Paid()
        {
            if (!this.paid)
            {
                paid = true;
            }
        }

        public void NotPaid()
        {
            if (this.paid)
            {
                paid = false;
            }
        }

        public bool GetStatus()
        {
            return this.paid;
        }


    }
}