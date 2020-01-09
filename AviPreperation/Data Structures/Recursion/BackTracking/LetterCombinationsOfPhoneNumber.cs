using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    //Time Complexity = O(3^N * 4^M), N is no of digits that has 3 characters and M has 4 character(7,9)
    //Space Complexity = O(3^N * 4^M) 
    public class LetterCombinationsOfPhoneNumber
    {
        Dictionary<string, string> d = new Dictionary<string, string>{
        {"2", "abc"},
        {"3", "def"},
        {"4", "ghi"},
        {"5", "jkl"},
        {"6", "mno"},
        {"7", "pqrs"},
        {"8", "tuv"},
        {"9", "wxyz"}};
        List<string> output = new List<string>();

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length != 0)
                backtrack("", digits);

            return output;
        }

        public void backtrack(string combination, string next_digit)
        {
            if (next_digit.Length == 0)
            {
                output.Add(combination);
            }
            else
            {
                string digit = next_digit.Substring(0, 1);
                string letters = d[digit];

                for (int i = 0; i < letters.Length; i++)
                {
                    string letter = d[digit].Substring(i, 1);
                    backtrack(combination + letter, next_digit.Substring(1));
                }
            }
        }
    }

    //public class MainClass {
    //    public static void Main()
    //    {
    //        var obj = new LetterCombinationsOfPhoneNumber();
    //        obj.LetterCombinations("23");
    //    }
    //}
}
