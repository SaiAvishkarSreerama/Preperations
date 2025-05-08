/*
 * The count-and-say sequence is a sequence of digit strings defined by the recursive formula:
 * countAndSay(1) = "1"
 * countAndSay(n) is the run-length encoding of countAndSay(n - 1).
 * Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical characters (repeated 2 or more times) with the concatenation of the character and the number marking the count of the characters (length of the run). For example, to compress the string "3322251" we replace "33" with "23", replace "222" with "32", replace "5" with "15" and replace "1" with "11". Thus the compressed string becomes "23321511".
 * Given a positive integer n, return the nth element of the count-and-say sequence.
 * 
 * Example 1:
 * Input: n = 4
 * Output: "1211"
 * Explanation:
 * countAndSay(1) = "1"
 * countAndSay(2) = RLE of "1" = "11"
 * countAndSay(3) = RLE of "11" = "21"
 * countAndSay(4) = RLE of "21" = "1211"
 * 
 * Example 2:
 * Input: n = 1
 * Output: "1"
 * Explanation:
 * This is the base case.
 * 
 * Constraints:
 * 1 <= n <= 30
 * Follow up: Could you solve it iteratively?
 * 
 * TC - O(2^n), each term grows exponentially for the next recursion
 * SC - O(2^n), only string builder is used in iteration, for recursion, stack memory is also being added 
 */

using System.Text;
namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _38_CountAndSay
    {
        [TestMethod]
        public void Run()
        {
            CountAndSay_recursion(4);
            CountAndSay_Iteration(30);
        }

        #region MyCode - Recursion/Iteration
        /// <summary>
        /// Both takes exponential time and space
        /// TC - O(2^n), each term grows exponentially for the next recursion
        /// SC - O(2^n), only string builder is used in iteration, for recursion, stack memory is also being added 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay_recursion(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            if (n == 2)
            {
                return "11";
            }

            return CountAndSayRecursion(n, 2, "11");
        }

        public string CountAndSayRecursion(int n, int curr, string s)
        {
            if (n == curr)
            {
                return s;
            }

            int count = 1;
            char currChar = s[0];
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < s.Length; i++)
            {
                if (currChar == s[i])
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(currChar);
                    currChar = s[i];
                    count = 1;
                }

                if (i == s.Length - 1)
                {
                    sb.Append(count);
                    sb.Append(currChar);
                }
            }
            return CountAndSayRecursion(n, curr + 1, sb.ToString());
        }


        /// <summary>
        /// Explanation:
        ///     For each string for n, iterate the string and count the num of the s[i] repeats, when other num comes, sb.append(count & currNum), repeat it till curr num=n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay_Iteration(int n)
        {
            if (n <= 0)
            {
                return "";
            }

            string s = "1";
            int curr = 1;

            // iterate untill curr becomes 'n'
            while (n > curr)
            {
                int count = 1;
                char currChar = s[0];
                StringBuilder sb = new StringBuilder();
                // iterate the string
                for (int i = 1; i < s.Length; i++)
                {
                    // when the curr char is same, increment count
                    if (currChar == s[i])
                    {
                        count++;
                    }
                    else
                    {
                        // if not, we are on diff num
                        // save the result to sb
                        sb.Append(count);
                        sb.Append(currChar);

                        // now move to next char
                        currChar = s[i];
                        count = 1;
                    }
                }

                // add any rem resultto sb
                sb.Append(count);
                sb.Append(currChar);
                s = sb.ToString();

                // do for n times
                curr++;
            }

            return s;
        }
        #endregion
    }
}
