using System;

namespace BikeRental_FDV
{
    public abstract class Subscription
    {
        // Just to avoid code repetition. Used in concrete classes.
        public TimeSpan GetTimeSpan(DateTime initial, DateTime end)
        {
            return end - initial;
        }
       
        /// This method could be written in a separate interface. I choose this approach because it is just one method.
        /// Keeping it simple.
        public abstract double CalculateRentalCost(DateTime initialTime, DateTime endTime);   
        
      
    }
}
