using System;
using System.Collections.Generic;

namespace BikeRental_FDV
{
    public class Family : Subscription
    {
        // Using class variables as it is the same for all the instances. Keep it simple.
        // This is for the Family discount.
        public static int charge = 30;

        IList<Subscription> Discounts = null;
        public Family(Subscription dt1, Subscription dt2, Subscription dt3)
        {
            Discounts = new List<Subscription>();
            Discounts.Add(dt1);
            Discounts.Add(dt2);
            Discounts.Add(dt3);
        }

        public int TotalDiscount()
        {
            return Discounts.Count;
        }

        public void AddDiscountType(Subscription dt)
        {
            if (Discounts.Count >= 5)
                throw new FamilyDiscountTypeOverflowException("A Family discount cannot have more than 5 discounts");

            this.Discounts.Add(dt);
        }

        public override double CalculateRentalCost(DateTime initialtime, DateTime endTime)
        {
            double totalRate = 0;

            foreach(Subscription sub in Discounts)
            {
                totalRate += sub.CalculateRentalCost(initialtime, endTime);
            }

            return totalRate * charge / 100;
        }

    }


}
