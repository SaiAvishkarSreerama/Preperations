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

namespace PreperationsTest.LeetCode.Hard.Strings
{
    [TestClass]
    public class _32_LongestValidParanthesis
    {
        [TestMethod]
        public void Run()
        {
            string s = ")((((()()()()()))))))))";
            int maxLength = LongestValidParentheses(s);
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
    }
}
