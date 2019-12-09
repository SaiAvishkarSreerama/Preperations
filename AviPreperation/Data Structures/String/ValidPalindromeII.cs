using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
* 
* Example 1:
* Input: "aba"
* Output: True
* 
* Example 2:
* Input: "abca"
* Output: True
* 
*             |         |
*             v         v
* Input:"ebcbbececabbacecbbcbe""
* Output: True
* 
* Explanation: You could delete the character 'c'.
* 
* Note:
* The string will only contain lowercase characters a-z. The maximum length of the string is 50000.
* */
namespace AviPreperation.Data_Structures.String
{
    public class ValidPalindromeIISolution
    {
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public bool ValidPalindromeII(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return isValid(s, i + 1, j) || isValid(s, i, j - 1);
                }
                j--;
                i++;
            }
            return true;
        }

        public bool isValid(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                    return false;
                i++; j--;
            }
            return true;
        }
    }
}
