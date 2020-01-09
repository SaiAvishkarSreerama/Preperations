using System;
using System.Collections.Generic;
using System.Text;

/*Given an input string, reverse the string word by word.
* Example 1:
* Input: "the sky is blue"
* Output: "blue is sky the"
* 
* Example 2:
* Input: "  hello world!  "
* Output: "world! hello"
* Explanation: Your reversed string should not contain leading or trailing spaces.
* 
* Example 3:
* Input: "a good   example"
* Output: "example good a"
* Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.
* 
* Note:
* A word is defined as a sequence of non-space characters.
* Input string may contain leading or trailing spaces. However, your reversed string should not contain leading or trailing spaces.
* You need to reduce multiple spaces between two words to a single space in the reversed string.
*/


namespace AviPreperation.Data_Structures.String
{
    /***********************************Good Solution******************************/
    public class ReverseWordsInStringClass1
    {
        //Time Complexity - O(N)
        //Doubt: Spce Complexity - O(N), used a String Builder which increases linearly with the length of input 
        //Space complexity - O(1)
        public string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();

            //Iterating From back
            int i = s.Length - 1;

            // finding each word from the end and appending that to stringbuilder
            while (i >= 0)
            {
                //skip the spaces with index i 
                if (s[i] == ' ')
                {
                    i--;
                    continue;
                }

                //start the second pointer(j) before (i) and move front till reaches a space
                int j = i - 1;
                while (j >= 0 && s[j] != ' ')
                    j--;

                //Now, j is at space and i is at end of the word
                //so, Append the space and the word from j+1 to i-j
                sb.Append(" ");
                sb.Append(s.Substring(j + 1, i - j));

                //repeat the loop by i from the j front
                i = j - 1;
            }

            //If the sb length >0 means we have a string characters init, so the given string has atleast one character init. so removing the extra space we are appending at the front of the sb
            if (sb.Length > 0)
                sb.Remove(0, 1);

            return sb.ToString();

        }
    }

    //Approach:
    // Reverse whole string
    // Find each word with two pointers
    // Reverse each word
    // remove the spaces by moving two pointers and return the substring with the length of the pointer position
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
