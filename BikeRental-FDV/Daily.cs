using System;

namespace BikeRental_FDV
{
    public class Daily : Subscription
    {
        // Using class variables as it is the same for all the instances. Keep it simple
        public static int charge = 20;

        public override double CalculateRentalCost(DateTime initialTime, DateTime endTime)
        {
            var totalDays = GetTimeSpan(initialTime, endTime).TotalDays;
            return totalDays * charge;
        }
    }
}
