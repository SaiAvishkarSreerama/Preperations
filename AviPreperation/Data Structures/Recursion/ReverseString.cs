using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    public class ReverseStringSol
    {
        //USING RECURSION
        //Time Complexity- O(n)
        //Space Complexity - O(n), to keep the recursion stack
        public void ReverseString2(char[] s)
        {
            Recursive(0, s);
        }

        public void Recursive(int index, char[] s)
        {
            if (index <= s.Length - 1 - index)
            {
                char temp = s[index];
                s[index] = s[s.Length - 1 - index];
                s[s.Length - 1 - index] = temp;
                Recursive(index + 1, s);
            }
        }


        //USING TWO POINTERS - ITERATIVE
        //Time Complexity - O(N) for N/2 swaps
        //Space Complexity - O(1) 
        public void ReverseString(char[] s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char temp = s[i];
                s[i++] = s[j];
                s[j--] = temp;
            }
        }
    }
}
