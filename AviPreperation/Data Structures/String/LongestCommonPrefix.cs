using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    public class LCP
    {
        //Time Complexity - O(n*m) -- n-length of input and m-length of first string
        //Space Complexity - O(1) -- we are not utilizing any extra space
        public static string LongestCommonPrefix(string[] strs)
        {
            //If the given input strs.Lenth is null or 0 return nul
            if (strs == null || strs.Length == 0)
                return "";

            //iterating each character of first string of array
            for (int i = 0; i < strs[0].Length; i++)
            {
                //consider each character
                char c = strs[0][i];
                //check the charcter c present in each other strings of array by iterating them
                //Since the first string is comparing with the others, start from the second string which is j=1
                for (int j = 1; j < strs.Length; j++)
                {
                    //if the string length becomes i, means we reach the end of that string 
                    //OR
                    //if the comparing character is not matching with jth character of the string 
                    //Return the substring of strs[0] up to i th iteration
                    if (strs[j].Length == i || strs[j][i] != c)
                        return strs[0].Substring(0, i);
                }
            }

            //if the termination while comparision does not happen in above looping,
            //which means the first string we took is matching as prefix in all strings
            return strs[0];
        }

        //public static void Main()
        //{
        //    string[] t = new string[] { "flower", "flow", "flight" };
        //    var x = LongestCommonPrefix(t);
        //    Console.WriteLine(x);
        //    Console.ReadLine();
        //}
    }
}