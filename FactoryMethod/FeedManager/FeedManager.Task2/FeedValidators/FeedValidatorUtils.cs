using System;

namespace FeedManager.Task2.FeedValidators
{
    public static class FeedValidatorUtils
    {
        public static int GetNumberOfDecimalPlaces(decimal value)
        {
            // https://stackoverflow.com/questions/13477689/find-number-of-decimal-places-in-decimal-value-regardless-of-culture
            return BitConverter.GetBytes(decimal.GetBits(value)[3])[2];
        }
    }
}