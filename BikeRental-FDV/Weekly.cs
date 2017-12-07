using System;

namespace BikeRental_FDV
{
    public class Weekly : Subscription
    {
        // Using class variables as it is the same for all the instances. Keep it simple
        public static int charge = 60;

        public override double CalculateRentalCost(DateTime initialTime, DateTime endTime)
        {
            var totalWeeks = GetTimeSpan(initialTime, endTime).TotalDays / 7;
            return totalWeeks * charge;
        }
    }
}
