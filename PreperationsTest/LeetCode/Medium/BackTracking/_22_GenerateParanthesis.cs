/*
 * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
 * 
 * Example 1:
 * Input: n = 3
 * Output: ["((()))","(()())","(())()","()(())","()()()"]
 * 
 * Example 2:
 * Input: n = 1
 * Output: ["()"]
 * 
 * Constraints:
 * 1 <= n <= 8
 *  */
using System.Threading.Channels;

namespace PreperationsTest.LeetCode.Medium.BackTracking
{
    [TestClass]
    public class _22_GenerateParanthesis
    {
        [TestMethod]
        public void Run()
        {
            GenerateParenthesis(3);
        }

        private IList<string> result { get; set; }
        private int totalPairs { get; set; }


        /// <summary>
        /// We are generating all possible valid combinations of the parenthesis for a given count
        /// if n = 6 means, for total we have six pairs of parantheses '()', 6-open and 6-closed paranthesis
        /// Using Backtracking
        /// TC - O(4^n/ sq.root(n)), using Catalan number 
        /// SC - O(Cn) where Cn is the n-th Catalan number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            totalPairs = n;
            result = new List<string>();
            BackTracking(0, 0, "");

            return result;
        }

        public void BackTracking(int open, int close, string curr)
        {
            // Base case - when open-close parenthesis are equal and we reach parenthesis limit
            if (open == totalPairs && close == totalPairs)
            {
                result.Add(curr);
                return;
            }

            // when to add open parenthesis: when we have limit
            if (open < totalPairs)
            {
                BackTracking(open + 1, close, curr + "(");
            }

            // when to add closed parenthesis: when open is higher
            if (close < open)
            {
                BackTracking(open, close + 1, curr + ")");

            }

        }
    }
}
