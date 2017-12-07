using System;
using System.Runtime.Serialization;

namespace BikeRental_FDV
{
    [Serializable]
    public class FamilyDiscountTypeOverflowException : Exception
    {
        public FamilyDiscountTypeOverflowException(string message) : base(message)
        {
        }

    }
}