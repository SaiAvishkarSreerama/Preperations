using System;
using System.Collections.Generic;
using System.Text;
/*Given an input string , reverse the string word by word. 
* 
* Example:
* 
* Input:  ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
* Output: ["b","l","u","e"," ","i","s"," ","s","k","y"," ","t","h","e"]
* Note: 
* 
* A word is defined as a sequence of non-space characters.
* The input string does not contain leading or trailing spaces.
* The words are always separated by a single space.
* Follow up: Could you do it in-place without allocating extra space?
* */
namespace AviPreperation.Data_Structures.String
{
    public class ReverseWordInStringIISolution
    {
        /*********************OWN SOLUTION Accepted 100%********************/
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public void ReverseWords(char[] s)
        {
            //Two pointer technique
            //Reverse the char array
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char temp = s[i];
                s[i++] = s[j];
                s[j--] = temp;
            }


            //Iterate the char array from the starting position
            i = 0; j = 0;
            while (i < s.Length)
            {
                //move j till the space appear
                if (j < s.Length && s[j] != ' ')
                {
                    j++;
                    continue;
                }

                //here j is at space, so move one step back to land on last char of the word, where i at first char
                j--;
                int t = j;
                while (i < j)
                {
                    // Console.WriteLine(s[i]+"--"+s[j]);
                    char temp = s[i];
                    s[i++] = s[j];
                    s[j--] = temp;
                }

                //t is the position of word end, since we moved a step back from space, adding 2 crosses the space 
                //and moves i to next word first char, start i and j from the start char of next word
                i = t + 2;
                j = i;
            }
        }
    }
}
