using System;
using System.Collections.Generic;
using System.Text;

/*Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

Note: For the purpose of this problem, we define empty string as valid palindrome.

Example 1:

Input: "A man, a plan, a canal: Panama"
Output: true
Example 2:

Input: "race a car"
Output: false*/


namespace AviPreperation.Data_Structures.String
{
    public class Solution
    {

        //TimeComplexity - O(N)
        //Space Complexity - O(N)
        public bool IsPalindrome1(string s)
        {
            if (s.Length == 0)
                return true;

            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                int val = c - '0';
                if ((val >= 0 && val <= 9) || (val >= 17 && val <= 42) || (val >= 49 && val <= 74))
                    sb.Append(c);
            }

            int i = 0;
            int j = sb.Length - 1;
            Console.WriteLine(sb);
            while (i < j)
            {
                if (Char.ToLower(sb[i++]) != Char.ToLower(sb[j--]))
                    return false;
            }
            return true;
        }


        //USE IsLetterOrDigit(char) property to find alpha numeric
        //TimeComplexity - O(N)
        //Space Complexity - O(1)
        public bool IsPalindrome2(string s)
        {
            int i = 0; int j = s.Length - 1;
            while (i < j)
            {
                if (!Char.IsLetterOrDigit(s[i]))
                    i++;
                else if (!Char.IsLetterOrDigit(s[j]))
                    j--;
                else if (Char.ToLower(s[i++]) != Char.ToLower(s[j--]))
                    return false;
            }
            return true;
        }
    }
}
