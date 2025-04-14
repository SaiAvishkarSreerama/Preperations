/*
 * Given an integer x, return true if x is a palindrome, and false otherwise.
 * Example 1:
 * Input: x = 121
 * Output: true
 * Explanation: 121 reads as 121 from left to right and from right to left.
 * 
 * Example 2:
 * Input: x = -121
 * Output: false
 * Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
 * 
 * Example 3:
 * Input: x = 10
 * Output: false
 * Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 * 
 * TC - O(n), where n is no of digits in the int
 * SC - O(1)
 */

namespace PreperationsTest.LeetCode.Easy.Maths
{
    [TestClass]
    public class _9_PalindromeNumber
    {
        [TestMethod]
        public void Run()
        {
            bool result = IsPalindrome_NoString(121);
        }

        #region Using String
        /// <summary>
        /// Checking palindrome of given number using ToString()
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            string s = x.ToString();
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                if (s[i++] != s[j--])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Without converting to a string
        public bool IsPalindrome_NoString(int x)
        {
            if (x < 0)
            {
                return false;
            }

            int original = x;
            int reverseX = 0;
            
            while (x != 0)
            {
                reverseX = reverseX * 10 + x % 10;
                x /= 10;
            }
            return original == reverseX;
        }
        #endregion

        #region Using Math - But fails for 10021, as 0 are removed while caluclation and considers as 121, to avoid this still we need string dataype to hold the leading 0s
        /// <summary>
        /// Challenge: Could you solve it without converting the integer to a string?
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome_Math(int x)
        {
            // Without converting the int to a string
            if (x < 0)
                return false;

            if (x >= 0 && x <= 9)
                return true;

            while (x != 0)
            {
                int lastDigit = x % 10;
                int firstDigit = GetFirstDigit(x);
                x = RemoveFirstAndLast(firstDigit, x);
                if (firstDigit != lastDigit)
                {
                    return false;
                }
            }

            return true;
        }

        public int GetFirstDigit(int x)
        {
            int divisible = GetDivisible(x);
            int firstDigit = x / divisible;
            return firstDigit;
        }

        public int GetDivisible(int x)
        {
            // gives num of digits - 1
            double digitValue = Math.Log10(x);

            //  Add one to make it correct
            int floorValue = (int)(Math.Floor(digitValue)) + 1;

            return (int)Math.Pow(10, floorValue - 1);
        }

        public int RemoveFirstAndLast(int firstDigit, int x)
        {
            //remove first and last digits
            x = x - firstDigit * GetDivisible(x);
            x /= 10;

            return x;
        }
        #endregion
    }
}
