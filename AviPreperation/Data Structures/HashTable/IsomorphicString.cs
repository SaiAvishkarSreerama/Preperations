using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class IsIsomorphicSolution
    {
        //Time Complexity - O(n)
        //Space Complextiy - O(n)
        public static bool IsIsomorphicUsingHashMap(string s, string t)
        {
            Dictionary<char, char> d = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (d.ContainsKey(s[i]))
                {
                    if (d[s[i]] != t[i]) return false;
                }
                else
                {
                    if (d.ContainsValue(t[i])) return false;
                    d.Add(s[i], t[i]);
                }
            }

            return true;
        }

        //Using ASCII codes
        //Time Complexity = O(n)
        //space Complexity = O(2n)
        //Note1: incrementing the position of the ASCII value after each appearance in the string, we can also count the no of time a char comes in string using ths final count.
        public static bool IsIsomorphicUsingASCII(string s, string t)
        {
            int[] a1 = new int[128]; //[0,0,0,0,0,0,.......]
            int[] a2 = new int[128]; //[0,0,0,0,0,0,.......]

            for (int i = 0; i < s.Length; i++)
            {
                if (a1[s[i]] != a2[t[i]]) // a char is converted into its ASCII code, a-97,b-98...
                    return false;
                a1[s[i]] += 1; //Note1
                a2[t[i]] += 1;
            }

            return true;
        }

        //public static void Main()
        //{
        //    string s = "egg";
        //    string t = "add";
        //    Console.WriteLine(IsIsomorphicUsingHashMap(s,t));
        //    Console.WriteLine(IsIsomorphicUsingASCII(s,t));
        //}
    }

}
