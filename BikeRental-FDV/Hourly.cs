using System;

namespace BikeRental_FDV
{
    public class Hourly : Subscription
    {
        // Using class variables as it is the same for all the instances. Keep it simple
        public static int charge = 5;

        public override double CalculateRentalCost(DateTime initialTime, DateTime endTime)
        {
            var totalHours = GetTimeSpan(initialTime, endTime).TotalHours;
            return totalHours * charge;
        }
    }
}
