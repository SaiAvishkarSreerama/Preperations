using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    public class ReverseWordsInStringClass
    {
        public static string ReverseWordsInString(string s)
        {
            /*With out using Split, Extra space - O(1)*/
            char[] a = new char[s.Length];
            int sl = s.Length;
            int i = 0;
            //REVERSE THE GIVEN STRING
            for (i = 0; i < sl ; i++)
            {
                a[i] = s[sl - 1 - i];
                //Console.WriteLine(a[i]);
            }

            //REVERSE EACH WORD OF THE RESULT
            i = 0; int j = 0;
            while (i < sl || j < sl)
            {
                //increment j, till we get a[j] == ' '
                if (a[j] != ' '&& j < sl-1)
                    j++;
                //once j is at ' '
                if (a[j] == ' ' || j == sl-1)
                {
                    //if j already exceeds the max length then reverse chars from i to j
                    if (j == sl - 1) Swap(a, i, j);
                    //reverse the chars before the j, means from i to j-1
                    else Swap(a, i, j - 1);
                    //after reverse the word, then start again by making i and j from the next position of j.
                    i = j + 1;
                    j++;
                }
            }

            //CLEAR THE MULTI SPACES WITH SINGLE SPACE
            i = 0; j = 0;
            while (j < sl)
            {
                //if first character is space then i stays but j increments till a[j] != ' ', let be i=0 and j=2(2 spaces at starting)
                while (j < sl && a[j] == ' ')
                    j++;
                //since i=0 & j=2, copy the non spaces at j=2 to i=0 position till a[j] == ' ', and stop there
                while (j < sl && a[j] != ' ')
                    a[i++] = a[j++];
                //since j is again at spaces, increment j alone till get a[j] != ' ', but i stays there only after copying the j values.
                while (j < sl && a[j] == ' ')
                    j++;
                //since j crosses all spaces and waits at a[j] != ' ', i copies last value of a[j](which is non space), put a space and i++
                if (j < sl)
                    a[i++] = ' ';

            }

            string res = new string(a);
            return res.Substring(0, i);
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
        //    Console.WriteLine(ReverseWordsInString("the  sky   is  blue"));
        //    Console.ReadLine();
        //}
    }
}
