using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given two strings s and t , write a function to determine if t is an anagram of s.
* 
* Example 1:
* 
* Input: s = "anagram", t = "nagaram"
* Output: true
* Example 2:
* 
* Input: s = "rat", t = "car"
* Output: false
* Note:
* You may assume the string contains only lowercase alphabets.
* 
* Follow up:
* What if the inputs contain unicode characters? How would you adapt your solution to such case?
*/
namespace AviPreperation.Data_Structures.String
{
    class ValidAnagram
    {
        //Time Complexity - O(n)
        //Space Complexity - O(1); we used constant array of size 26
        public bool IsAnagram(string s, string t)
        {
            if (hash(s) == hash(t))
                return true;
            return false;
        }

        public string hash(string str)
        {
            int[] a = new int[26];
            foreach (char c in str)
            {
                a[c - 'a']++;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                sb.Append(a[i]);
                sb.Append('#');
            }


            //3#0#0#0#0#0#1#0#0#0#0#0#1#1#0#0#0#1#0#0#0#0#0#0#0#0#
            //3#0#0#0#0#0#1#0#0#0#0#0#1#1#0#0#0#1#0#0#0#0#0#0#0#0#
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
