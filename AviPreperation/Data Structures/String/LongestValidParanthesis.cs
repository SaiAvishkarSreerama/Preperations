using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
* 
* Example 1:
* Input: "(()"
* Output: 2
* Explanation: The longest valid parentheses substring is "()"
* 
* Example 2:
* Input: ")()())"
* Output: 4
* Explanation: The longest valid parentheses substring is "()()"
* */
namespace AviPreperation.Data_Structures.String
{
    public class LongestValidParanthesisSolution
    {
        //USING STACK : APPROACH - 1
        //TC - O(N), N-length of string
        //SC - O(N), N-length of string
        public int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            Stack<int> st = new Stack<int>();
            st.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                // when ( encounter push the index
                if (s[i] == '(')
                    st.Push(i);
                //when ) encounter pop the index, and calculate the length from i-peek(), if stack empty psuh(i)
                else
                {
                    st.Pop();
                    if (st.Count == 0)
                        st.Push(i);
                    maxLength = Math.Max(maxLength, i - st.Peek());
                }
            }

            return maxLength;
        }


        //TWO PASS
        //TC - O(N)
        //SC - O(1)
        public int LongestValidParentheses1(string s)
        {
            int left = 0;
            int right = 0;
            int maxLength = 0;

            // ====>
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    left++;
                else
                    right++;

                if (left == right)
                    maxLength = Math.Max(maxLength, 2 * right);
                else if (right >= left)
                    left = right = 0;
            }
            left = right = 0;
            // <====
            for (int i = s.Lemght - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                    left++;
                else
                    right++;

                if (left == right)
                    maxLength = Math.Max(maxLength, 2 * left);
                else if (left >= right)
                    left = right = 0;
            }

            return maxLength;
        }
    }


}
