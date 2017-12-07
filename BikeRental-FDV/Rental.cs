using System;

namespace BikeRental_FDV
{
    public class Rental
    {
        public DateTime InitialTime { get; set; }

        public DateTime EndTime { get; set; }

        public Subscription RentalType { get; set; }

        public Rental(Subscription rentalType, DateTime initialTime, DateTime endTime)
        {
            this.RentalType = rentalType;
            this.InitialTime = initialTime;
            this.EndTime = endTime;

        }

        public double Cost()
        {
            return this.RentalType.CalculateRentalCost(this.InitialTime, this.EndTime);
        }
    }
}
