using System;
using System.Collections.Generic;
using System.Text;
/*
 ex1: "baaaaa" ==> "baabaa" ==> only one swap happened ==> 1
 ex2: "baaabbaabbba" ==> "bbaabbaabbaa" ==> 2 swaps
     */
namespace AviPreperation.Assessments.MicroSoft
{
    //Time Complexity : O(n) since we are iterating complete string
    //Space Complexity : O(1) since we are not using any additional spaces.
    class MinSwaps
    {
        //https://leetcode.com/discuss/interview-question/398026/
        // using System;
        // you can also use other imports, for example:
        // using System.Collections.Generic;
        // you can write to stdout for debugging purposes, e.g.
        // Console.WriteLine("this is a debug message");
        public static int MinSwapssolution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            int count = 0;
            //Iterating over string.
            for (int i = 0; i < S.Length; i++)
            {
                int repeatLen = 1; 
                //Checking for the repeated characters count.
                for (; i + 1 < S.Length && S[i] == S[i + 1]; i++)
                {
                    repeatLen++;
                }
                //Since for every 3rd occurance,we are increasing
                //the count.
                count = count + repeatLen / 3;
            }
            return count;
        }
        
        //public static void Main()
        //{
        //    Console.WriteLine(MinSwapssolution("baaaaa"));
        //}
}
}
