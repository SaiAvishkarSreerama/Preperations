using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class JewelsAndStonesSolution
    {
        //Time Complexity - O(m + n)
        //SpaceComplexity- O(m)
        //     public int NumJewelsInStones_HashSet(string J, string S) {
        //         int count = 0;
        //         if(S.Length == 0 || J.Length == 0)
        //             return count;
        //         HashSet<char> jh = new HashSet<char>();

        //         for(int i=0; i<J.Length; i++)
        //             if(!jh.Contains(J[i]))
        //                jh.Add(J[i]);

        //         for(int i = 0; i<S.Length; i++){
        //             if(jh.Contains(S[i])){
        //                 count++;
        //             }
        //         }
        //         return count;
        //     }

        //Time Complexity - O(m + n)
        //SpaceComplexity- O(1)
        public int NumJewelsInStones_ASCII(string J, string S)
        {
            int count = 0;
            if (S.Length == 0 || J.Length == 0)
                return count;
            int[] arr = new int[128];

            foreach (char cj in J)
                arr[cj] = 1;

            foreach (char cs in S)
            {
                if (arr[cs] > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
