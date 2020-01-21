using System;
using System.Collections.Generic;
using System.Text;
/*
 * Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
* 
* Example:
* 
* Input: S = "ADOBECODEBANC", T = "ABC"
* Output: "BANC"
* Note:
* 
* If there is no such window in S that covers all characters in T, return the empty string "".
* If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
*/
namespace AviPreperation.Data_Structures.String
{
    public class MinWindowSubStringSolution
    {
        //Time Complexity - O(s + t)
        //Space Complexity - O(1), constant space used for arr is 128
        public string MinWindow(string s, string t)
        {
            //two pointers
            int L = 0;
            int R = 0;

            //return substring start index and length 
            int minStart = 0;
            int minLength = int.MaxValue;

            //array to check the t string characters and t length to indicate all char are formed in substring
            int[] tArray = new int[128];
            int formed = t.Length;

            foreach (char c in t)
            {
                tArray[c]++;
            }

            while (R < s.Length)
            {
                //moving R pointer
                char c = s[R];
                if (tArray[c] > 0)
                    formed--;
                tArray[c]--;
                R++;

                //if formed is 0 means all chars in t appear in sliding window
                while (formed == 0)
                {
                    //note the min start and min lenght 
                    if (minLength > R - L)
                    {
                        minLength = R - L;
                        minStart = L;
                    }

                    //moving L pointer
                    c = s[L];
                    tArray[c]++;
                    if (tArray[c] > 0)
                        formed++;
                    L++;
                }
            }
            return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
        }
    }
}
