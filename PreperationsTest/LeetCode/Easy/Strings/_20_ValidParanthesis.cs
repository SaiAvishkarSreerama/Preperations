/*
 * Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
 * An input string is valid if:
 * Open brackets must be closed by the same type of brackets.
 * Open brackets must be closed in the correct order.
 * Every close bracket has a corresponding open bracket of the same type.
 * 
 * Example 1:
 * Input: s = "()"
 * Output: true
 * 
 * Example 2:
 * Input: s = "()[]{}"
 * Output: true
 * 
 * Example 3:
 * Input: s = "(]"
 * Output: false
 * 
 * Example 4:
 * Input: s = "([])"
 * Output: true
 * 
 * Constraints:
 * 1 <= s.length <= 104
 * s consists of parentheses only '()[]{}'.
 */
namespace PreperationsTest.LeetCode.Easy.Strings
{
    [TestClass]
    public class _20_ValidParanthesis
    {
        [TestMethod]
        public void Run()
        {
            bool res = IsValid("{([]){}{}}");
        }

        #region My Solution
        /// <summary>
        /// TC: O(n)
        /// SC: O(2n) -> O(n), for stack & for dictionary
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (s.Length == 0)
                return true;
            if (s.Length == 1)
                return false;
            Dictionary<char, char> d = new Dictionary<char, char>{
                {')','('},
                {'}','{'},
                {']','['}
            };
            Stack<char> st = new Stack<char>();
            foreach (char c in s)
            {
                if (!d.ContainsKey(c))
                {
                    st.Push(c);
                }
                else
                {
                    if (st.Count == 0 || (st.Count != 0 && st.Pop() != d[c]))
                    {
                        return false;
                    }
                }
            }
            return st.Count == 0;
        }
        #endregion

        #region WithOut using Dictionary space
        /// <summary>
        /// TC - O(N)
        /// SC - O(N), for stack
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid_1(string s)
        {
            if (s.Length == 0)
                return true;
            if (s.Length == 1)
                return false;

            Stack<char> st = new Stack<char>();
            foreach (char c in s)
            {
                // If open brackets push to stack
                if (c == '{' || c == '[' || c == '(')
                {
                    st.Push(c);
                }
                else if (c == '}' || c == ']' || c == ')')
                {
                    // if closed brackets but stack is empty its invalid
                    if (st.Count == 0)
                    {
                        return false;
                    }

                    // if closed char is not matching with open char (from stack) is invalid
                    char closed = st.Pop();
                    if ((closed != '{' && c == '}') ||
                        (closed != '[' && c == ']') ||
                        (closed != '(' && c == ')'))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
