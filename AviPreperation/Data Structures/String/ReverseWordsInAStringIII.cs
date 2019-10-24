using System;
using System.Collections.Generic;
using System.Text;

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
        public static void Main()
        {
            //Console.WriteLine(ReverseWordsInAStringIII("Let's take LeetCode contest"));
            Console.WriteLine(ReverseWordsInAStringIII("I Love U"));
            Console.ReadLine();
        }
    }
}
