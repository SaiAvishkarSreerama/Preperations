/*
 * Given a string s which represents an expression, evaluate this expression and return its value. 
 * The integer division should truncate toward zero.
 * You may assume that the given expression is always valid. All intermediate results will be in the range of [-231, 231 - 1].
 * Note: You are not allowed to use any built-in function which evaluates strings as mathematical expressions, such as eval().
 * 
 * Example 1:
 * Input: s = "3+2*2"
 * Output: 7
 * 
 * Example 2:
 * Input: s = " 3/2 "
 * Output: 1
 * 
 * Example 3:
 * Input: s = " 3+5 / 2 "
 * Output: 5
 * 
 * Constraints:
 * 1 <= s.length <= 3 * 105
 * s consists of integers and operators ('+', '-', '*', '/') separated by some number of spaces.
 * s represents a valid expression.
 * All the integers in the expression are non-negative integers in the range [0, 231 - 1].
 * The answer is guaranteed to fit in a 32-bit integer.
 * */

//Companies: @Meta @Google @Apple @MSFT @Amazon
namespace PreperationsTest.LeetCode.Medium.Maths
{
    [TestClass]
    public class _227_BasicCalculator_II
    {
        [TestMethod]
        public void Run()
        {
            string s = "1+1+1";
            Calculate(s);
        }

        /// <summary>
        /// Using Stack to maintain the num
        /// TC - O(n), iterating through each char
        /// SC - O(m), total digits in the string, excluding signs and spaces
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int num = 0;
            char sign = '+';
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                // we have a number here
                if (char.IsDigit(c))
                {
                    num = num * 10 + (c - '0');
                }

                // case when the char is a sign
                if ((!char.IsDigit(c) && c != ' ') || i == s.Length - 1)
                {
                    if (sign == '+')
                        stack.Push(num);
                    else if (sign == '-')
                        stack.Push(-num);
                    else if (sign == '*')
                        stack.Push(stack.Pop() * num);
                    else if (sign == '/')
                        stack.Push(stack.Pop() / num);

                    // reset
                    num = 0;
                    sign = c;
                }
            }

            // now we have all + and - numbers in stack
            // add them and return
            int res = 0;
            while (stack.Count > 0)
            {
                res += stack.Pop();
            }

            return res;
        }
    }
}
