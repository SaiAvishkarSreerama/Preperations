using System;
using System.Collections.Generic;
using System.Text;

/*
 Implement atoi which converts a string to an integer.

The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:

Only the space character ' ' is considered as whitespace character.
Assume we are dealing with an environment which could only store integers 
within the 32-bit signed integer range: [−2^31,  2^31 − 1]. If the numerical value is out of
the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.

Example 1:
Input: "42"
Output: 42

Example 2:
Input: "   -42"
Output: -42
Explanation: The first non-whitespace character is '-', which is the minus sign.
             Then take as many numerical digits as possible, which gets 42.
Example 3:
Input: "4193 with words"
Output: 4193
Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.

Example 4:
Input: "words and 987"
Output: 0
Explanation: The first non-whitespace character is 'w', which is not a numerical 
             digit or a +/- sign. Therefore no valid conversion could be performed.

Example 5:
Input: "-91283472332"
Output: -2147483648
Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
             Thefore INT_MIN (−231) is returned.
     */
namespace AviPreperation.Data_Structures.String
{
    public class StringToInteger_AtoI
    {
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public int MyAtoi(string s)
        {
            int sign = 1;
            int total = 0;
            int i = 0;
            bool isSign = false;

            if (i == s.Length)
                return 0;

            //pass whitespaces
            while (i < s.Length && s[i] == ' ')
                i++;

            if (i == s.Length)
                return 0;

            //get the sign of given string
            while (i < s.Length && (s[i] == '+' || s[i] == '-'))
            {
                if (isSign)
                    return 0;
                sign = s[i++] == '+' ? 1 : -1;
                isSign = true;
            }

            //get numbers from the string
            while (i < s.Length)
            {
                int digit = s[i] - '0';
                //if the char is not digit 
                if (digit < 0 || digit > 9)
                    break;

                //total > int.MaxValue / 10 : check if the total is higher than this, in hte next step we multiply with 10 which exeeds maxvalue 
                //total == int.MaxValue / 10 when equals and "s[i]-'0' > 7" or "s[i]-'0' > 7(==> means int.MaxValue%10)" again do the same case, so returning the max/min values depends on sign
                if (total > int.MaxValue / 10 || total == int.MaxValue / 10 && digit > 7)
                    return sign < 0 ? int.MinValue : int.MaxValue;

                total = total * 10 + digit;
                i++;

            }
            return sign * total;
        }
    }
}
