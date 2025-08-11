/*
 * Given a string s of '(' , ')' and lowercase English characters.
 * 
 * Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.
 * 
 * Formally, a parentheses string is valid if and only if:
 * 
 * It is the empty string, contains only lowercase characters, or
 * It can be written as AB (A concatenated with B), where A and B are valid strings, or
 * It can be written as (A), where A is a valid string.
 *  
 * 
 * Example 1: * 
 * Input: s = "lee(t(c)o)de)"
 * Output: "lee(t(c)o)de"
 * Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
 * 
 * Example 2:
 * Input: s = "a)b(c)d"
 * Output: "ab(c)d"
 * 
 * Example 3:
 * Input: s = "))(("
 * Output: ""
 * Explanation: An empty string is also valid.
 *  
 * Constraints:
 * 1 <= s.length <= 105
 * s[i] is either '(' , ')', or lowercase English letter.
 */

using System.Text;

namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _1249_MinimumRemoveToMakeValidParanthesis
    {
        [TestMethod]
        public void Run()
        {
            // o/p -> "lee(t(c)o)de"
            string res = MinRemoveToMakeValid("lee(t(c)o)de)");
        }

        /// <summary>
        /// TC - O(n)
        /// SC - O(n)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MinRemoveToMakeValid(string s)
        {
            /* ALGO:
            * 1. First pass - remove extra closedBrackets, while counting openBrackets and balance
            * 2. Second pass - remove the extra openBrackets (countopenBrackets - balanceBrackets), we remove the right most openbrackets
            */

            int balance = 0;
            int openBrackets = 0;
            StringBuilder sb = new StringBuilder();


            // First Pass
            foreach (char c in s)
            {
                if (c == '(')
                {
                    balance++;
                    openBrackets++;
                }
                if (c == ')')
                {
                    if (balance == 0)
                    {
                        continue;
                    }
                    balance--;
                }
                sb.Append(c);
            }

            // Second Pass
            int openBracketsToKeep = openBrackets - balance;
            StringBuilder res = new StringBuilder();
            foreach (char c in sb.ToString())
            {
                if (c == '(')
                {
                    openBracketsToKeep--;
                    if (openBracketsToKeep < 0)
                        continue;
                }
                res.Append(c);
            }

            return res.ToString();

        }
    }
}
