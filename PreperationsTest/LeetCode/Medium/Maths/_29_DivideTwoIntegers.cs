/*
* Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
* The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.
* Return the quotient after dividing dividend by divisor.
* Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than 231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.
* 
* Example 1:
* Input: dividend = 10, divisor = 3
* Output: 3
* Explanation: 10/3 = 3.33333.. which is truncated to 3.
* 
* Example 2:
* Input: dividend = 7, divisor = -3
* Output: -2
* Explanation: 7/-3 = -2.33333.. which is truncated to -2.
* 
* TC - O(LogN), for loop iterates 32 time takes O(1), but bitwise operation takes logarithmic times to find the largest multiple of divisor.
* SC - O(1)
* */

namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _29_DivideTwoIntegers
    {
        [TestMethod]
        public void Run()
        {
            int dividend = 2147483647, divisor = 3;
            int result = Divide(dividend, divisor);
        }

        #region First Logic came into my mind - Passing but Time Limit exceedes for some tests
        /*
         * Explanation:
         *      1. If divident < 0, we need to check if is int.MinValue, so dividendMinValue captures it
         *      2. If divisor < 0
         *      3. In both cases, we collect the sign, if both negative, means signed becomes +
         *      4. dividend = divident - divisor, untill divident >= divisor, do quotent++ all the time
         *      5. Special condition is int.MaxValue and int.MinValue has 1 num diff (neglect the sign), here we are converting numbers to +ve numbers, in such case minValue cannot convert to maxValue 
         *          so, we are removing 1 from the divident, later adding it for one subtraction in the while loop.
         */
        public int Divide(int dividend, int divisor)
        {
            int quotient = 0;
            int signed = 1;

            bool dividendMinValue = false;
            bool dividentRemoved = false;
            if (dividend < 0)
            {
                if (dividend == int.MinValue)
                {
                    dividendMinValue = true;
                    dividentRemoved = true;
                    dividend += 1;
                }
                signed = -1;
                dividend *= -1;
            }

            if (divisor < 0)
            {
                signed *= -1;
                divisor *= -1;
            }

            while (dividend >= divisor)
            {
                dividend -= divisor;
                quotient++;

                if (dividentRemoved)
                {
                    dividend += 1;
                    dividentRemoved = false;
                }
                if (quotient == int.MaxValue && dividend >= divisor)
                {
                    if (dividendMinValue && signed == -1)
                    {
                        return int.MinValue;
                    }
                    return int.MaxValue;
                }
            }

            return signed * quotient;
        }
        #endregion

        #region Same as above but with little better approach - Still time limit exceeded
        public int Divide_1(int dividend, int divisor)
        {
            // Edge cases
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            // if minvalue divided by -1. becomes positve and int overflow, so returning max
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            // Get the sign if is negative or not
            // either dividend or divisor is negative then its negative result, otherwise positive
            bool negative = (dividend < 0) != (divisor < 0);
            int quotient = 0;

            // Edge case for int.MinValue over flow
            // so remove one time of divisor, that gives less than the max value, so we can convert to ABS values
            if (dividend == int.MinValue)
            {
                if (divisor == 1)
                {
                    return int.MinValue;
                }
                else
                {
                    quotient++;
                    dividend -= divisor;
                }
            }

            // We have negative bool sign, so deal with postive numbers
            int dividend_abs = Math.Abs(dividend);
            int divisor_abs = Math.Abs(divisor);

            // iterate untill the divident becomes divisor or less
            // inside we find max multiple of divisor and subtracts at ones
            // any left dividend will do agian the same max multiple concept inside untill the divident is <divisor
            while (dividend_abs >= divisor_abs)
            {
                // Now instead of subtracting divisor for n times
                // we try to get the max multiples of divisor that can subtract at once
                // ex: if dividend=100 and divosor=2, we need to subtract 50 times, instead subract 50, 2 times or 100 1 time
                int temp_divisor = divisor;
                int multiple = 1;

                // Doing left shift gives the multiple of the number
                // 2<<1 = 4, 4<<1 = 8, 8<<1 = 16
                while (dividend_abs >= (temp_divisor << 1) && (temp_divisor << 1) > 0)
                {
                    multiple <<= 1;
                    temp_divisor <<= 1;
                }

                // Now we have a maximum divisor that can subtract single time
                dividend_abs -= divisor_abs;
                quotient += multiple;
            }

            return negative ? -1 * quotient : quotient;
        }
        #endregion

        #region Using BitWise operations
        /// <summary>
        /// Two Special cases:
        ///         if dividend is int.MinValue, return int.Max when divisor=-1, else int.min if divisor=+1
        ///         if divisor is int.MinValue, return 0, as anynumb divided by minValue is 0
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
        public int Divide_2(int dividend, int divisor)
        {
            // Edge cases
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            // if minvalue divided by -1. becomes positve and int overflow, so returning max
            if (dividend == int.MinValue)
            {
                if (divisor == -1)
                    return int.MaxValue;
                if (divisor == 1)
                    return int.MinValue;
                if (divisor == int.MinValue)
                    return 1; // INT_MIN divided by INT_MIN is 1
            }

            // Any number divided by INT_MIN (except INT_MIN itself) is 0
            if (divisor == int.MinValue)
            {
                return 0;
            }

            // Get the sign if is negative or not
            // either dividend or divisor is negative then its negative result, otherwise positive
            bool negative = (dividend < 0) != (divisor < 0);
            int quotient = 0;

            // Edge case for int.MinValue over flow
            // so remove one time of divisor, that gives less than the max value, so we can convert to ABS values
            if (dividend == int.MinValue)
            {
                quotient++;
                dividend -= divisor;
            }

            // We have negative bool sign, so deal with postive numbers
            int dividend_abs = Math.Abs(dividend);
            int divisor_abs = Math.Abs(divisor);

            // Since we are dealing with 32-bit signed integers, we can go from 31 to 0 ( 2^31 is the max value to 0)
            // if any number <<(leftShifts) 1, we get multiple of that number, we are multiplying with 2^n
            // if any number >>(rightShifts) 1, we get divided by that number, we are dividing by 2^n for signed, for unsigned its -ve value
            for (int i = 31; i >= 0; i--)
            {
                // righshifts dividend by i still greater than divisor, then subtract itimes left shift of divisor from it and increment quotient by multiple of i times
                if ((dividend_abs >> i) >= divisor_abs)
                {
                    dividend_abs -= divisor_abs << i;
                    quotient += 1 << i;
                }
                // Now we have a maximum divisor that can subtract single time

            }

            return negative ? -1 * quotient : quotient;
        }
        #endregion
    }
}
