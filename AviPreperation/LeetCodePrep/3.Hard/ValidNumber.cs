using System;
using System.Collections.Generic;
using System.Text;

/*
*  Validate if a given string can be interpreted as a decimal number.
* 
* Some examples:
* "0" => true
* " 0.1 " => true
* "abc" => false
* "1 a" => false
* "2e10" => true
* " -90e3   " => true
* " 1e" => false
* "e3" => false
* " 6e-1" => true
* " 99e2.5 " => false
* "53.5e93" => true
* " --6 " => false
* "-+3" => false
* "95a54e53" => false
* 
* Note: It is intended for the problem statement to be ambiguous.
*   You should gather all requirements up front before implementing one. 
*   However, here is a list of characters that can be in a valid decimal number:
* 
* Numbers 0-9
* Exponent - "e"
* Positive/negative sign - "+"/"-"
* Decimal point - "."
* Of course, the context of these characters also matters in the input.
*/

namespace AviPreperation.LeetCodePrep._3.Hard
{
    public  class ValidNumberSolution
    {
        //Time Complexity - O(n),  where n is length of characters
        //Space Complextiy - O(1)
        public static bool IsNumber(string s)
        {
            s = s.Trim();
            bool numSeen = false;
            bool eSeen = false;
            bool dotSeen = false;

            //if e - should be once and should already seen a number and no '.' after it
            //if . - should already seen a num
            //if +/- - shuold be at 0th position or after an 'e'
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                    numSeen = true;
                else if (c == 'e')
                {
                    if (eSeen || !numSeen) return false;
                    numSeen = false;
                    eSeen = true;
                }
                else if (c == '+' || c == '-')
                {
                    if (i != 0 && s[i - 1] != 'e') return false;
                }
                else if (c == '.')
                {
                    if (dotSeen || eSeen) return false;
                    dotSeen = true;
                }
                else return false;
            }
            return numSeen;
        }

        //public static void Main()
        //{
        //    string num = " -123.5e-2     ";
        //    //string num = " -123.5e-22-1     ";
        //    //string num = " -1123.5e-2     ";
        //    Console.WriteLine(IsNumber(num));
        //    Console.ReadLine();
        //}
    }
}
