using System;
using System.Collections.Generic;
using System.Text;

//Given a string, find the length of the longest substring without repeating characters.

//Example 1:
//Input: "abcabcbb"
//Output: 3 
//Explanation: The answer is "abc", with the length of 3. 

//Example 2:
//Input: "bbbbb"
//Output: 1
//Explanation: The answer is "b", with the length of 1.

//Example 3:
//Input: "pwwkew"
//Output: 3
//Explanation: The answer is "wke", with the length of 3. 
//Note that the answer must be a substring, "pwke" is a subsequence and not a substring.

namespace AviPreperation.Data_Structures.String
{
    public class LengthOfLongestSubstringSolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int i = 0;
            int j = 0;
            int max = 0;
            //HAshset holds a single unique value
            HashSet<char> h = new HashSet<char>();

            //using sliding window technique, staring i,j from s[0]
            //moving pointer j and if that char is new put in hashset, if it already there then
            //remove it and move pointer i. while calculating the max length bet j and i. 
            while (i < s.Length && j < s.Length)
            {
                if (!h.Contains(s[j]))
                {
                    h.Add(s[j++]);
                    max = Math.Max(max, j - i);
                }
                else
                {
                    h.Remove(s[i++]);
                }
            }
            return max;
        }
    }
}
