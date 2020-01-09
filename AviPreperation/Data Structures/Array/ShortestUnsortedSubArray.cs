using System;
using System.Collections.Generic;
using System.Text;
/*Given an integer array, you need to find one continuous subarray that if you only sort this subarray in ascending order, then the whole array will be sorted in ascending order, too.

You need to find the shortest such subarray and output its length.

Example 1:
Input: [2, 6, 4, 8, 10, 9, 15]
Output: 5
Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.
Note:
Then length of the input array is in range [1, 10,000].
The input array may contain duplicates, so ascending order here means <=.*/
namespace AviPreperation.Data_Structures.Array
{
    public class ShortestUnsortedSubArray
    {

        //     //Not working for all test vases
        //     public int FindUnsortedSubarray(int[] nums) {
        //         int i = 0;
        //         int j = nums.Length -1;

        //         int start = 0;
        //         int end = 0;

        //         while(i < j){
        //             if(start == 0 &&  nums[i] > nums[i+1]){
        //                 start = i;
        //             }
        //             if(end ==0 && nums[j-1] > nums[j]){
        //                 end = j-1;
        //             }

        //             i++; j--;
        //         }
        //         Console.WriteLine(start + "---" + end);
        //         return end==0 && start==0 ? 0 : end - start + 1;
        //     }

        //USING STACK
        //TimeComplexity - O(n)
        //Space complexity - O(n)
        public int FindUnsortedSubarray(int[] nums)
        {
            Stack<int> s = new Stack<int>();
            int l = int.MaxValue;
            int r = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                while (s.Count > 0 && nums[s.Peek()] > nums[i])
                    l = Math.Min(l, s.Pop());
                s.Push(i);
            }
            s.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (s.Count > 0 && nums[s.Peek()] < nums[i])
                    r = Math.Max(r, s.Pop());
                s.Push(i);
            }

            return r - l < 0 ? 0 : r - l + 1;

        }
        //USING STACK
        //TimeComplexity - O(n)
        //Space complexity - O(1)
        public int FindUnsortedSubarray1(int[] A)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int l = -1;
            int r = -2;
            int n = A.Length;
            for (int i = 0; i <= n - 1; i++)
            {
                max = Math.Max(max, A[i]); // from forward
                min = Math.Min(min, A[n - 1 - i]); //from backward

                if (A[i] < max) //which means suddenly the sorting decreased
                    r = i;
                if (A[n - 1 - i] > min) // which is value is increased from back, should decrese
                    l = n - 1 - i;
            }
            return r - l + 1;
        }

    }
}
