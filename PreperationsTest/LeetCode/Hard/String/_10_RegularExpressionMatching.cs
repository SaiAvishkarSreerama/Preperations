/*
 * Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:
 *      '.' Matches any single character
 *      '*' Matches zero or more of the preceding element.
 *      
 * Example 1:
 * Input: s = "aa", p = "a"
 * Output: false
 * Explanation: "a" does not match the entire string "aa".
 * 
 * Example 2: * 
 * Input: s = "aa", p = "a*"
 * Output: true
 * Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
 *
 * Example 3:
 * Input: s = "ab", p = ".*"
 * Output: true
 * Explanation: ".*" means "zero or more (*) of any character (.)".
 * 
 * TC - O(mxn), m-text,n-pattern lengths
 * SC - O(mxn)
 */

namespace PreperationsTest.LeetCode.Hard.String
{
    [TestClass]
    public class _10_RegularExpressionMatching
    {
        [TestMethod]
        public void Run()
        {
            string text = "xaabyc";
            string pattern = "xa*b.c";

            bool matches = RegularExpressionMatching(text, pattern);
        }

        /// <summary>
        /// using dynamic programming Bottom-Up(Tabulation) solution with Iteration
        /// Explanation:
        ///     1. Create a dp table [text.Lenght as rows][pattern.Lenght as column]
        ///     2. Fill dp[0,0] = true, as empty text and pattern is matching
        ///     3. Fill 0th row and 0th column with default values
        ///         i. If the pattern is like a*, a*b*, a*b*c*, then some values become true by default
        ///     4. Two conditions
        ///         i. text[i] == pattern[j] || pattern[j] == '.'  ===> dp[i,j] = dp[i-1, j-1]check for previous elements matching, can found in diagonal
        ///         ii. text[i] == '*', again two conditions, letter before *, ex: a*, has
        ///             a. 0 occurances - dp[i,j] = dp[i, j-2], we need to take the value from before a*
        ///             b. more occurances - first check if the current ele matches with *-element(a*) text[i] == pattern[j-1] OR patter[j-1] is a '.', dp[i,j] = dp[i-1, j]
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public bool RegularExpressionMatching(string text, string pattern)
        {
            // Step 1
            bool[,] dp = new bool[text.Length + 1, pattern.Length + 1];

            // Step 2
            dp[0, 0] = true;

            // Step 3: starts from j=1, as dp[0,0] already set to true
            for (int j = 1; j <= pattern.Length; j++)
            {
                if (pattern[j - 1] == '*') // -1 gives us a start from 0th index
                {
                    dp[0, j] = dp[0, j - 2];
                }
            }

            // Step 4:
            for (int i = 1; i <= text.Length; i++)
            {
                for (int j = 1; j <= pattern.Length; j++)
                {
                    // condition 1, get the diagonal value
                    if (text[i - 1] == pattern[j - 1] || pattern[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    // condition 2
                    else if (pattern[j - 1] == '*')
                    {
                        // sub condition 1: zero occurances, get the a* before pattern value
                        dp[i, j] = dp[i, j - 2];

                        // sub condition 2: more occurances, when text==pattern and pattern is '.', get the top box * value or existing value(alredy filled from sub condition 1)
                        if (text[i - 1] == pattern[j - 2] || pattern[j - 2] == '.')
                        {
                            dp[i, j] |= dp[i - 1, j];
                        }
                    }
                }
            }

            return dp[text.Length, pattern.Length];
        }
    }
}
