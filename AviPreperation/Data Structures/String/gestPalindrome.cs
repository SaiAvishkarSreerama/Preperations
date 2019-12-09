using System;
using System.Collections.Generic;
using System.Text;

/*
*  Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.
* 
* This is case sensitive, for example "Aa" is not considered a palindrome here.
* 
* Note:
* Assume the length of given string will not exceed 1,010.
* 
* Example:
* 
* Input:
* "abccccdd"
* 
* Output:
* 7
* 
* Explanation:
* One longest palindrome that can be built is "dccaccd", whose length is 7.
     */
namespace AviPreperation.Data_Structures.String
{
    public class LongestPalindromeSolution
    {
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public int LongestPalindrome1(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (d.ContainsKey(c))
                    d[c]++;
                else
                    d.Add(c, 1);
            }
            int ans = 0;
            foreach (var k in d.Keys)
            {
                ans += d[k] / 2 * 2;
                if (d[k] % 2 == 1 && ans % 2 == 0)
                    ans++; // adding the middle unique character if exists
            }

            return ans;
        }

        //Using HashSet
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public int LongestPalindrome2(string s)
        {
            HashSet<char> h = new HashSet<char>();
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (!h.Contains(s[i]))
                {
                    h.Add(s[i]);
                }
                else
                {
                    //if exists in hashset means the value is second time we are seeing 
                    //so we add 2 count to ans and then remove the value from hashset, if another value comes, we can add again
                    ans += 2;
                    h.Remove(s[i]);
                }
            }

            //Till we have added characters with multiple appearance, if h.Count>0 means there are some unique values left
            //so we take one unique value to consider for a middle value
            return h.Count > 0 ? ans + 1 : ans;
        }
    }
}
