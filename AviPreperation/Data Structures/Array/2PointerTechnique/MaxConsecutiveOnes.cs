using System;
using System.Collections.Generic;
using System.Linq;

//Given a binary array, find the maximum number of consecutive 1s in this array.

//Example 1:
//Input: [1,1,0,1,1,1]
//Output: 3
//Explanation: The first two digits or the last three digits are consecutive 1s.
//    The maximum number of consecutive 1s is 3.
//Note:

//The input array will only contain 0 and 1.
//The length of input array is a positive integer and will not exceed 10,000
public  class MaxConsecutiveOnesClass
{
    // Time complexity - O(n)
    // Space Complexity - O(1)

    /* Explanation:
       Let Consider an array A = [ 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 ] which has 6 consecutive 1s in it
       By using 2 pointer technique
       
        Declaring i and j and count for result

        i is the incremental index of Array A
        j will be increment accordingly depedns on condition

        if A[i] = 0 then cosidering the position for j as same as i, for [0,1,1,0] i,j at 0, i increments till next 0, like j-0index and i-2index
        count ==> i-j ==> 2-0 ==> 2 will be no of consecutive 1s, since 3rd index value is 0 then setting i=j

        For the next sequence after [0,1,1,i=j=>0,1,1,1,0]
        i increments from 3-6index but j stays at index3 till A[i] becomes '0'
        count ==> i-j ==> 6-3 ==> 3 and previoud count is 2 whcih is less than new count=3 then count becomes 3 else it stays old value.
     */

    //using two pointers
    public static int FindMaxConsecutiveOnes(int[] A)
    {
        int j = -1;
        int count = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == 0)
                j = i;
            else if (A[i] == 1 && count < (i - j))
                count = i - j;
        }

        return count;
    }

    // Using only one pointer(i) 
    public int FindMaxConsecutiveOnes1(int[] A)
    {
        int count = 0;
        int maxCount = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == 1)
            {
                count++;
            }
            else
            {
                maxCount = Math.Max(count, maxCount);
                count = 0;
            }

        }

        return Math.Max(count, maxCount);
    }
    //static void Main()
    //{
    //    var pIndex = new DiagonalOrderClass();
    //    int[] A  = new int[] { 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 };
    //    Console.WriteLine(FindMaxConsecutiveOnes(A));
    //    Console.ReadLine();
    //}
}
