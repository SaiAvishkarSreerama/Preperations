using System;
using System.Collections.Generic;
using System.Text;

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
