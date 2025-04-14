/*
 * Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
 * The algorithm for myAtoi(string s) is as follows:
 * Whitespace: Ignore any leading whitespace (" ").
 * Signedness: Determine the sign by checking if the next character is '-' or '+', assuming positivity if neither present.
 * Conversion: Read the integer by skipping leading zeros until a non-digit character is encountered or the end of the string is reached. If no digits were read, then the result is 0.
 * Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231, and integers greater than 231 - 1 should be rounded to 231 - 1.
 * Return the integer as the final result.
 * 
 * Example 1:
 * Input s = "42" Output: 42
 * 
 * Example 2:
 * Input: s = " -042" Output: -42
 * 
 * Example 3:
 * Input: s = "1337c0d3" Output: 1337
 * 
 * Example 4:
 * Input: s = "0-1"  Output: 0
 * 
 * Example 5:
 * s = "2147483648" OOutput: 2147483647
 */

namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _8_StringToInteger_atoi_
    {
        [TestMethod]
        public void Run()
        {
            string s ="   -042";
            int result = MyAtoi(s);
        }


        #region Beats 100% with 0ms as per today's submissions
        /// <summary>
        /// Complexity
        /// Time Complexity: O(n), where n is the length of the string. The function processes each character of the string once.
        /// Space Complexity: O(1). The function uses a constant amount of extra space.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            int res = 0;
            int i = 0;
            // Alternate to trim
            while (i < s.Length) {
                if (s[i] == ' ')
                {
                    i++;
                    continue;
                }
                break;
            }

            // base case
            if (i == s.Length)
                return 0;

            // check if the num is signed
            bool isSigned = false;
            if (s[i] == '-' || s[i] == '+')
            {
                isSigned = s[i++] == '-';
            }

            // Start from the ith position
            for (; i < s.Length; i++)
            {
                int num = s[i] - '0';
                if (num >= 0 && num <= 9)
                {
                    // If res is crossing or reaching max value, return the max or min value based on sign
                    if (res > int.MaxValue / 10 || res == int.MaxValue / 10 && num > 7)
                    {
                        return  isSigned ? int.MinValue : int.MaxValue;
                    }
                        res = res * 10 + num;
                }
                else
                {
                    break;
                }
            }

            return isSigned ?  -1 * res: res;
        }
        #endregion
    }
}
