/*
 * Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses substring.
 * Example 1:
 * Input: s = "(()"
 * Output: 2
 * Explanation: The longest valid parentheses substring is "()".
 * 
 * Example 2:
 * Input: s = ")()())"
 * Output: 4
 * Explanation: The longest valid parentheses substring is "()()".
 * 
 * Example 3:
 * Input: s = ""
 * Output: 0
 *  
 * Constraints:
 * 0 <= s.length <= 3 * 104
 * s[i] is '(', or ')'.
*/

using System.Diagnostics.Metrics;

namespace PreperationsTest.LeetCode.Hard.Strings
{
    [TestClass]
    public class _32_LongestValidParanthesis
    {
        [TestMethod]
        public void Run()
        {
            string s = "())((())";
            int maxLength = LongestValidParentheses1(s);
        }

        /// <summary>
        /// Explanation:
        ///     1. We use stack to maintain the previous index of '(' open paranthesis
        ///     2. When '(' - push index i to stack
        ///     3. When ')' - means previous open paranthesis is at top and st.pop() gives that index.
        ///     4. so current index i-st.Peek() gives the max length with that closed paranthesis, check Math.Max with previous maxlength
        ///     5. During ')' , when stack is empty, add that index, since its not a valid one, when pop and check lenght gives 0
        ///     
        /// TC- O(N)
        /// SC -O(N)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            { // when ( encounter push the index
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    //when ) encounter pop the index, and calculate the length from i-peek(), if stack empty psuh(i)
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    maxLength = Math.Max(maxLength, i - stack.Peek());
                }
            }

            return maxLength;
        }

        /// <summary>
        ///  TWO PASS
        ///  Explanation:
        ///     1. In first pass traverse from i=0 to n, it ensures the sequence like (() but misses ())
        ///         i. when open encounters '(' - open++
        ///         ii. When close encounters ')' - close++
        ///         ii. When open==close, get the max lenght of 2*open or 2*close
        ///         iv. since coming from front, when close ')' are high means we set zeros and increment from that
        ///     2. Same but traverse from i=n to 0 this time, it ensures the sequence like ()) but misses (()
        ///         iv. since coming from back, when open '(' are high means they came first, which we need to discard, so set to zeros
        ///     
        /// Why Two passes?
        /// Left to Right Pass: This pass ensures that sequences where the number of close parentheses might exceed the number of open parentheses are considered. For example, 
        ///     in the sequence ()), the first pass will reset the counts after encountering the second close parenthesis.
        /// Right to Left Pass: This pass ensures that sequences where the number of open parentheses might exceed the number of close parentheses are considered.For example, 
        ///     in the sequence ((), the second pass will reset the counts after encountering the second open parenthesis.
        /// Ex: ( ) ( ( ( ) ) , 
        ///     first pass ( ), calculates maxLenght, but ( ( ( ) ), open-3,close-2 fails to calculate (()) in it.
        ///     seconf pass ( (()), close-2, open-2, calculates length
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses1(string s)
        {
            int open = 0;
            int close = 0;
            int maxLength = 0;

            // ====>
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;

                if (open == close)
                    maxLength = Math.Max(maxLength, 2 * open);
                else if (close > open)
                    open = close = 0;
            }
            open = close = 0;
            // <====
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                    open++;
                else
                    close++;

                if (open == close)
                    maxLength = Math.Max(maxLength, 2 * open);
                else if (open > close)
                    open = close = 0;
            }

            return maxLength;
        }
    }
}
