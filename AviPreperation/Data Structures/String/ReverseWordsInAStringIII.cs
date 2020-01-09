using System;
using System.Collections.Generic;
using System.Text;
/*Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.
* 
* Example 1:
* Input: "Let's take LeetCode contest"
* Output: "s'teL ekat edoCteeL tsetnoc"
* Note: In the string, each word is separated by single space and there will not be any extra space in the string.
* */
namespace AviPreperation.Data_Structures.String
{
    class ReverseWordsInAStringIIIClass
    {
        public static string ReverseWordsInAStringIII(string s)
        {
            int n = s.Length;
            char[] a = new char[n];

            int i = 0;
            while (i < n)
            {
                a[i] = s[i];
                i++;
            }
            i = 0; int j = 0;
            while (j < n)
            {
                if (a[j] != ' ' && j < n - 1)
                {
                    j++;
                }
                if (a[j] == ' ' || j == n - 1)
                {
                    Swap(a, i, j == n - 1 ? j : j - 1);
                    i = j + 1;
                    j++;
                }
            }

            string str = new string(a);
            return str;
        }
        public static void Swap(char[] a, int i, int j)
        {
            while (i < j)
            {
                char temp = a[i];
                a[i++] = a[j];
                a[j--] = temp;
            }
        }
        //public static void Main()
        //{
        //    //Console.WriteLine(ReverseWordsInAStringIII("Let's take LeetCode contest"));
        //    Console.WriteLine(ReverseWordsInAStringIII("I Love U"));
        //    Console.ReadLine();
        //}
    }
}
