using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BikeRental_FDV;

namespace BikeRentalTests_FDV
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SubscriptionByHourCharges5Dollars()
        {
            Assert.IsTrue(Hourly.charge == (Int32)charges.Hourly);            
        }

        [TestMethod]
        public void SubscriptionByDayCharges20Dollars()
        {
            Assert.IsTrue(Daily.charge == (Int32)charges.Daily);
        }

        [TestMethod]
        public void SubscriptionByWeeklyCharges60Dollars()
        {
            Assert.IsTrue(Weekly.charge == (Int32)charges.Weekly);
        }

        [TestMethod]
        public void TwoHoursHourlyRentalCosts10Dollars()
        {
            Rental r = new RentalFactory().rentalHourlyTwoHours;
            Assert.IsTrue(r.Cost() == 10);
        }

        [TestMethod]
        public void FourDaysDailyRentalCosts80Dollars()
        {
            Rental r = new RentalFactory().rentalDailyFourDays;
            Assert.IsTrue(r.Cost() == 80);
        }

        [TestMethod]
        public void TwoWeeksWeeklyRentalCosts120Dollars()
        {
            Rental r = new RentalFactory().rentalWeeklyTwoWeeks;
            Assert.IsTrue(r.Cost() == 120);
        }

        [TestMethod]
        public void AddDiscountToFamilyIncrementsInOne()
        {
            Family family = new SubscriptionFactory().familyThreeDiscounts;
            Assert.IsTrue(family.TotalDiscount() == 3);
            family.AddDiscountType(new SubscriptionFactory().weekly);
            Assert.IsTrue(family.TotalDiscount() == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(FamilyDiscountTypeOverflowException))]
        public void AddingMoreThanFiveDiscountsToFamilyThrowsException()
        {
            Family family = new SubscriptionFactory().familyFiveDiscounts;
            Assert.IsTrue(family.TotalDiscount() == 5);
            family.AddDiscountType(new SubscriptionFactory().hourly);
        }

        [TestMethod]
        public void FamilyWithHourlyHourlyHourlyCharges9Dollars()
        {
            // 3 hourly subscription for 2 hours each: 30 dollars - 30% discount = 9 dollars
            SubscriptionFactory sbf = new SubscriptionFactory();
            Family family = new Family(sbf.hourly, sbf.hourly, sbf.hourly);
            Assert.IsTrue(family.CalculateRentalCost(DateTimeFactory.dt1, DateTimeFactory.dt2) == 9);
        }

        public void FamilyWithHourlyDailyWeeklyCharges()
        {
            // 1 weekly subscription for 1 week: 60
            // 1 daily subscription for 1 week: 7*20 = 140
            // 1 hourly subscription for 1 week: 5*24*7 = 840
            // 30% Discount = 728 total
            SubscriptionFactory sbf = new SubscriptionFactory();
            Family family = new Family(sbf.hourly, sbf.weekly, sbf.daily);
            Assert.IsTrue(family.CalculateRentalCost(DateTimeFactory.dt1, DateTimeFactory.dt5) == 728);
        }

    }

    public class RentalFactory
    {
        public Rental rentalHourlyTwoHours;
        public Rental rentalDailyFourDays;
        public Rental rentalWeeklyTwoWeeks;
        public RentalFactory()
        {
            SubscriptionFactory sbf = new SubscriptionFactory();
            rentalHourlyTwoHours = new Rental(sbf.hourly, DateTimeFactory.dt1, DateTimeFactory.dt2);

            rentalDailyFourDays = new Rental(sbf.daily, DateTimeFactory.dt1, DateTimeFactory.dt3);

            rentalWeeklyTwoWeeks = new Rental(sbf.weekly, DateTimeFactory.dt1, DateTimeFactory.dt4);
        }
    }

    public class SubscriptionFactory
    {
        public Hourly hourly;
        public Daily daily;
        public Weekly weekly;
        public Family familyThreeDiscounts;
        public Family familyFiveDiscounts;

        public SubscriptionFactory()
        {
            hourly = CreateHourly();
            daily = CreateDaily();
            weekly = CreateWeekly();
            familyThreeDiscounts = CreateFamilyThreeDiscounts();
            familyFiveDiscounts = CreateFamilyFiveDiscounts();
        }

        private Hourly CreateHourly()
        {
            return new Hourly();
        }
        private Daily CreateDaily()
        {
            return new Daily();
        }
        private Weekly CreateWeekly()
        {
            return new Weekly();
        }

        private Family CreateFamilyThreeDiscounts()
        {
            return new Family(CreateHourly(), CreateHourly(), CreateHourly());
        }

        private Family CreateFamilyFiveDiscounts()
        {
            Family family = CreateFamilyThreeDiscounts();
            family.AddDiscountType(CreateDaily());
            family.AddDiscountType(CreateWeekly());

            return family;
        }
    }
     
    public class DateTimeFactory
    {
        public static DateTime dt1 = new DateTime(2017, 1, 1, 0, 0, 0);
        public static DateTime dt2 = new DateTime(2017, 1, 1, 2, 0, 0);
        public static DateTime dt3 = new DateTime(2017, 1, 5, 0, 0, 0);
        public static DateTime dt4 = new DateTime(2017, 1, 15, 0, 0, 0);
        public static DateTime dt5 = new DateTime(2017, 1, 8, 0, 0, 0);
    }

    enum charges
    {
        Hourly = 5, Daily = 20, Weekly = 60
    }
}
