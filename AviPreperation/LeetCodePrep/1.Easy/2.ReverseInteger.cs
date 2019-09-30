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
            // if x=0 just return 0
            if (x == 0)
                return 0;

            //checking for negive or positive integer
            bool isGivenIntPositive = x > 0;

            // making x always a positve integer 
            x = isGivenIntPositive ? x : -x;
            long result = 0;

            //untill x becomes 0
            while (x > 0)
            {
                //modulus 10 gives the last digit 
                result = result * 10 + x % 10;
                // by 10 gives removes the last digit
                x = x / 10;

                //as per the question result must lies between -2^31 and 2^31-1
                if (int.MinValue > result || result > int.MaxValue) return 0;
            }

            return (int)(isGivenIntPositive ? result : -result);
        }
    }
}

/* Notes:
 * Math.Pow(double x, double y) gives the value of power 2^31 etc
 * int.MaxValue and int.MinValue is same as
 * Math.Pow(-2, 31) and Math.Pow(2,31), 32 bit signed integer range
 * */
