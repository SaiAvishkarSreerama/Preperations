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
public  class MinSizeSubarraySumClass
{
    // Time complexity - O(n) -- Each element can be visited atmost twice, once by the right pointer(ii) and(atmost)once by the \text{left}left pointer.
    // Space Complexity - O(1) -- Only constant space required for \text{left}left, \text{sum}sum, \text{ans}ans and ii.

    /*
     Explanation: 
     1. Asked for min value then intially taking ans as int.MaxValue
     2. left pointer is intially at 0th index
     3. iterating through nums by incrementing i from 0 to <n, and adding each index position element to sum
     4. If sum >= s, then finding the no of elements from the array that from the sum
         For example for given array [2,3,1,2,4,3] and s=7, for left=0 and i=3, sum=2+3+1+2=8, since 8>7 then counting hte no of elements that formed the sum, which is 4
         4 elements that count from the formula ==> i index + 1 gves the elemtn number (i+1 ==> 4) and sub left from it (i+1 - left ==> 4-0 ==> 4) which will be our ans for up to i=3
     5. and then deleting the left index from the sum and then increment left++(now left=1), sum = sum - 2(where left=0) ==> 8-2 ==> 6, in this case while loop fails as 6<7
     6. Repeat the i increment i=4; left=1; sum=3+1+2+4=10; while(sum>=s) ==> ans=4elements, sum = sum - 3(where left=1) ==> 10-3 ==> 7 and left++==>left=2, 
                                                           still (sum>=s) ==> ans=3elements, sum = sum - 1(where left=2) ==> 7-2 ==>4 and left++==> left=3, while loop fails as 4<7
     7. Repeat iterating i till i<n and then we get the min value of ans each time.
     */

    //using two pointers
    public static int MinSubArrayLen(int[] nums, int s)
    {
        int ans = int.MaxValue;
        int n = nums.Length;
        int left = 0;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            while (sum >= s)
            {
                ans = Math.Min(ans, i + 1 - left);
                sum -= nums[left++];
            }
        }
        return ans != int.MaxValue ? ans : 0;
    }

    static void Main()
    {
        var pIndex = new DiagonalOrderClass();
        int[] A  = new int[] { 2,3,1,2,4,3 };
        Console.WriteLine(MinSubArrayLen(A, 7));
        Console.ReadLine();
    }
}
