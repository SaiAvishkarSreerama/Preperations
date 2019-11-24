using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    class FirstUniqueCharacterInaString
    {

        //Case1****************Using 2 HASH SETS
        //Time-Complexity O(2n)
        //Space-complexity - O(2n)
        public static int FirstUniqChar1(string s) {
            HashSet<char> uniqueSet = new HashSet<char>();  
            HashSet<char> repSet = new HashSet<char>();

            for(int i = 0; i < s.Length; i++){
                if(uniqueSet.Contains(s[i])){
                    uniqueSet.Remove(s[i]);
                    repSet.Add(s[i]);
                }
                else if(!repSet.Contains(s[i])){
                    uniqueSet.Add(s[i]);
                }
            }

            if(uniqueSet.Count == 0)
                return -1;

            for(int i= 0; i <s.Length; i++){
                if(uniqueSet.Contains(s[i]))
                    return i; 
            }

            return -1;
        }

        //Case2*********************USing Array with ASCII codes
        //Time Complexity - O(n)
        //Space Complextiy - O(n)
        public static int FirstUniqChar2(string s)
        {
            int[] arr = new int[128];

            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i]]++;
            }

            for (int i = 0; i < s.Length; i++)
                if (arr[s[i]] == 1)
                    return i;
            return -1;
        }

        //Case3*******************USEING Dictionary/HashMap
        //Time Complexity - O(n)
        //Space Complexity - O(n)
        public int FirstUniqChar3(string s)
        {
            Dictionary<char, int> d = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (d.ContainsKey(s[i]))
                {
                    int v = d[s[i]];
                    d[s[i]] = v + 1;
                }
                else
                {
                    d.Add(s[i], 1);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (d[s[i]] == 1)
                    return i;
            }

            return -1;
        }

        //public static void Main()
        //{
        //    string s = "leetcode";
        //    Console.WriteLine(FirstUniqChar1(s));
        //    Console.WriteLine(FirstUniqChar2(s));
        //    Console.WriteLine(FirstUniqChar3(s));
        //}
    }
}
