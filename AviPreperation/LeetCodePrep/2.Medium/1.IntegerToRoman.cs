using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.LeetCodePrep._2.Medium
{
   
    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            var IntToRoman = new Dictionary<int, string>(){
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000,"M"},{2,"II"},{3,"III"},{6,"VI"},{7,"VII"},{8,"VIII"},
            {4,"IV"},
            {9,"IX"},
            {40,"XL"},
            {90,"XC"},
            {400,"CD"},
            {900,"CM"}};

            int mul = 1;
            string result = "";
            Console.WriteLine(IntToRoman[1]);
            while (num > 0)
            {
                result = IntToRoman[num % 10 * mul] + result;
                num /= 10;
                mul *= 10;
            }

            return result;
        }

        public string IntToRoman1(int num)
        {
            var result = new StringBuilder();
            var IntToRoman = new Dictionary<int, string>(){
            {1000,"M"},
            {900,"CM"},
            {500, "D"},
            {400,"CD"},
            {100, "C"},
            {90,"XC"},
            {50, "L"},
            {40,"XL"},
            {10, "X"},
            {9,"IX"},
            {5, "V"},
            {4,"IV"},
            {1, "I"}};

            foreach (var i in IntToRoman)
            {
                while (num >= i.Key)
                {
                    num -= i.Key;
                    result.Append(i.Value);
                }
            }

            return result.ToString();
        }
    }
}
