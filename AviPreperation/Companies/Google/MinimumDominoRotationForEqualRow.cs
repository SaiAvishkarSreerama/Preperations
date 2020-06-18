using System;
using System.Collections.Generic;
using System.Text;
/*
* In a row of dominoes, A[i] and B[i] represent the top and bottom halves of the i-th domino. 
* (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
* We may rotate the i-th domino, so that A[i] and B[i] swap values.
* Return the minimum number of rotations so that all the values in A are the same, or all the values in B are the same.
* If it cannot be done, return -1.
* 
* Example 1:
* Input: A = [2,1,2,4,2,2], B = [5,2,6,2,3,2]
* Output: 2
* Explanation: 
* The first figure represents the dominoes as given by A and B: before we do any rotations.
* If we rotate the second and fourth dominoes, we can make every value in the top row equal to 2, as indicated by the second figure.
*
* Example 2:
* Input: A = [3,5,1,2,3], B = [3,6,3,3,4]
* Output: -1
* Explanation: 
* In this case, it is not possible to rotate the dominoes to make one row of values equal.
* 
* Note:
* 1 <= A[i], B[i] <= 6
* 2 <= A.length == B.length <= 20000
* */
namespace AviPreperation.Companies.Google
{
    public class MinimumDominoRotationForEqualRowSolution
    {
        //TC - O(N)
        //SC - O(N)
        /*Algo:
            1. Start with A[0] check min rotations, if min rotations != -1 return it or even if is -1 but 
            both A[0] and B[0] are same, which means that is the min possible rotations.
            2. Else check with B[0] and can return it directly, as A[0] fails at  -1 and A[0]!=B[0]
        */
        public int MinDominoRotations(int[] A, int[] B)
        {
            int minRotations = Check(A, B, A[0]);

            if (minRotations != -1 || A[0] == B[0])
                return minRotations;
            else
                return Check(A, B, B[0]);
        }

        //check the rotations and return the min of a and b
        public int Check(int[] A, int[] B, int target)
        {
            int aCheck = 0;
            int bCheck = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != target && B[i] != target)
                    return -1;
                else if (A[i] != target)
                    aCheck++;
                else if (B[i] != target)
                    bCheck++;
            }

            return Math.Min(aCheck, bCheck);
        }
    }
}
