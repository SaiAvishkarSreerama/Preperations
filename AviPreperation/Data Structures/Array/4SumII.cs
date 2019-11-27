using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that A[i] + B[j] + C[k] + D[l] is zero.
* 
* To make problem a bit easier, all A, B, C, D have same length of N where 0 ≤ N ≤ 500. All integers are in the range of -228 to 228 - 1 and the result is guaranteed to be at most 231 - 1.
* 
* Example:
* 
* Input:
* A = [ 1, 2]
* B = [-2,-1]
* C = [-1, 2]
* D = [ 0, 2]
* 
* Output:
* 2
* 
* Explanation:
* The two tuples are:
* 1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
* 2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
*/
namespace AviPreperation.Data_Structures.Array
{
    class _4SumII
    {
        //To find A+ B+ C+ D = 0
        //Here we are splitting 4 in to 2,2 and finding A+B=-(C+D) in two loops
        //Time complexity - O(n^2)
        //Space Complexity - O(n)
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            if (A.Length == 0)
                return 0;

            int result = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int a in A)
            {
                foreach (int b in B)
                {
                    int k = a + b;
                    if (dict.ContainsKey(k))
                        dict[k]++;
                    else
                        dict.Add(k, 1);
                }
            }

            foreach (int c in C)
            {
                foreach (int d in D)
                {
                    int k = -(c + d);
                    if (dict.ContainsKey(k))
                        result += dict[k];
                }
            }

            return result;
        }

        static void Main()
        {
            int[] A = new int[] { 1, 2 };
            int[] B = new int[] { -1,-2 };
            int[] C = new int[] { -1, 2 };
            int[] D = new int[] { 0, 2 };
            var FourSum = new _4SumII();

            var result = FourSum.FourSumCount(A, B, C, D);

            Console.WriteLine(result);
            Console.ReadLine();           
        }
    }
}
