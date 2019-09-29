using System.Collections.Generic;

//Given a 32-bit signed integer, reverse digits of an integer.

//Example 1:

//Input: 123
//Output: 321
//Example 2:

//Input: -123
//Output: -321
//Example 3:

//Input: 120
//Output: 21
//Note:
//Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1].
//For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.


/********My Solution********* Incomplete but Wrong *****/
namespace AviPreperation.LeetCodePrep._1.Easy
{
    public class ReverseSol
    {
        public int Reverse(int x)
        {
            int val = 0;
            int mul = 1;
            var reverseNum = new List<int>();

            while (x > 0)
            {
                reverseNum.Add(x % 10);
                x = x / 10;
            }

            reverseNum.Reverse();
            for (int i = 0; i < reverseNum.Count; i++)
            {
                val += reverseNum[i] * mul;
                mul = mul * 10;
            }
            return val;
        }


    /********Recommended Solution**************/
        public int Reverse1(int x)
        {

            if (x == 0)
                return 0;
            bool isGivenIntPositive = x > 0;
            long result = 0;
            while (x > 0)
            {
                result = result * 10 + x % 10;
                x = x / 10;

                if (result > int.MaxValue) return 0;
            }

            return (int)(isGivenIntPositive ? result : -result);
        }
    }
}