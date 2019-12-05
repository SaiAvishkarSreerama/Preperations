using System.Collections.Generic;
//Determine whether an integer is a palindrome.An integer is a palindrome when it reads the same backward as forward.
//Example 1:
//Input: 121
//Output: true

//Example 2:
//Input: -121
//Output: false
//Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

//Example 3:
//Input: 10
//Output: false

//Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
//Follow up: Coud you solve it without converting the integer to a string?

namespace AviPreperation.LeetCodePrep._1.Easy
{

    /********My Solution********* Incomplete but Wrong *****/
    //TimeComplexity - O(n)
    //SpaceComplexity - O(n)
    public class PalindromSol
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x == 0) return true;
            var result = new List<int>();
            while (x > 0)
            {
                result.Add(x % 10);
                x = x / 10;

            }
            var length = result.Count;

            for (int i = 0; i <= (length) / 2; i++)
            {
                if (result[i] != result[length - 1 - i])
                {
                    return false;
                    break;
                }
            }
            return true;
        }


        /********Still Not a Recommended Solution**************/
        //TimeComplexity - O(n)
        //SpaceComplexity - O(1)
        public bool IsPalindrome1(int x)
        {
            if (x < 0) return false;
            //taking input into temporary variable
            int temp = x;
            int result = 0;
            //untill false
            while (temp != 0)
            {
                //adding the last value to the result by multiplying 10 each time gives reverse num
                // Ex: 123 => 321
                result = result * 10 + temp % 10;
                temp /= 10;
            }

            //if result is eauls to given number then returns true
            return result == x;
        }



        /********Recommended Solution**************/
        //TimeComplexity - O(logn), we are travelling only half of the lenght of given number
        //SpaceComplexity - O(1), no extra space is used.
        public bool IsPalindrome2(int x)
        {
            //negative numbers non palindromic
            //x%10 gives 0 means, the num ended with 0 like 100,200,300, are non palindromic.
            if (x < 0 || (x != 0 && x % 10 == 0))
                return false;

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            return revertedNumber == x || revertedNumber / 10 == x;//if x is odd num
        }
    }
}
