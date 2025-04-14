/*
 * Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
 * Assume the environment does not allow you to store 64-bit integers (signed or unsigned).
 * 
 * Example 1:
 * Input: x = 123
 * Output: 321
 * 
 * Example 2:
 * Input: x = -123
 * Output: -321
 * 
 * Example 3:
 * Input: x = 120
 * Output: 21
 * 
 * Constraints:-231 <= x <= 231 - 1
 */

using System.Text;

namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _7_ReverseInteger
    {
        [TestMethod]
        public void Run()
        {
            int x = -123;
            int ans = Reverse(x);
        }

        /// <summary>
        /// TC - O (1og 10(x)) - The while loop iterates over each digit of the integer x. Since the number of digits in an integer x is proportional to log 10(x), the loop runs log 10(x).
        /// SC = O(1)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            int reverseNum = 0;
            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;

                // Check if adding the digit crosses the limit
                // MaxValue = (2,147,483,647), revNum is already > 2,147,483,64 || == 2,147,483,64 + adding >7 cross the limit
                if (reverseNum > int.MaxValue / 10 || (reverseNum == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }
                // MinValue = (−2,147,483,648), same here
                if (reverseNum < int.MinValue / 10 || (reverseNum == int.MinValue / 10 && digit < -8))
                {
                    return 0;
                }

                reverseNum = (reverseNum * 10) + digit;
            }

            return reverseNum;
        }
    }
}
