using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.
* 
* '?' Matches any single character.
* '*' Matches any sequence of characters (including the empty sequence).
* The matching should cover the entire input string (not partial).
* 
* Note:
* 
* s could be empty and contains only lowercase letters a-z.
* p could be empty and contains only lowercase letters a-z, and characters like ? or *.
* Example 1:
* 
* Input:
* s = "aa"
* p = "a"
* Output: false
* Explanation: "a" does not match the entire string "aa".
* Example 2:
* 
* Input:
* s = "aa"
* p = "*"
* Output: true
* Explanation: '*' matches any sequence.
* Example 3:
* 
* Input:
* s = "cb"
* p = "?a"
* Output: false
* Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
* Example 4:
* 
* Input:
* s = "adceb"
* p = "*a*b"
* Output: true
* Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".
* Example 5:
* 
* Input:
* s = "acdcb"
* p = "a*c?b"
* Output: false
* */
namespace AviPreperation.Data_Structures.String
{
    //TC - O(m*n)
    //SC - O(m*n)
    public class WildCardMatchingSol
    {
        /*
        NOTE: 
                        T[i-1][j-1], if(s[i] == p[j] || p[j] == "?")  
            T[i][j] =   T[i][j-1] || T[i-1][j], if(p[j] == "*")
                        False
        */
        public bool IsMatch(string s, string p)
        {
            bool[,] T = new bool[s.Length + 1, p.Length + 1];
            if (p.Length > 0 && p[0] == '*')
                T[0, 1] = true;
            T[0, 0] = true;

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 1; j < p.Length; j++)
                {
                    if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        T[i, j] = T[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        T[i, j] = T[i, j - 1] || T[i - 1, j];
                    }
                }
            }

            return T[s.Length, p.Length];
        }
    }
}
