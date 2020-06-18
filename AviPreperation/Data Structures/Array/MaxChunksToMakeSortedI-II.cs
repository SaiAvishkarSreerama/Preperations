using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    /********************************MAXIMUM CHUNKS TO MAKE SORTED ARRAY I****************************************
     * 
     * Given an array arr that is a permutation of [0, 1, ..., arr.length - 1], we split the array into some number of "chunks" (partitions), and individually sort each chunk.  After concatenating them, the result equals the sorted array.
       What is the most number of chunks we could have made?
       
       Example 1:
       Input: arr = [4,3,2,1,0]
       Output: 1
       Explanation:
       Splitting into two or more chunks will not return the required result.
       For example, splitting into [4, 3], [2, 1, 0] will result in [3, 4, 0, 1, 2], which isn't sorted.
       
       Example 2:
       Input: arr = [1,0,2,3,4]
       Output: 4
       Explanation:
       We can split into two chunks, such as [1, 0], [2, 3, 4].
       However, splitting into [1, 0], [2], [3], [4] is the highest number of chunks possible.
       
       Note:
       arr will have length in range [1, 10].
       arr[i] will be a permutation of [0, 1, ..., arr.length - 1].
       
     **********************/
    public class MaxChunksToMakeSorted_I_Solution
    {
        //TC - O(N)
        //SC - O(1)
        public int MaxChunksToSorted(int[] arr)
        {
            int n = arr.Length;
            int max = int.MinValue;
            int res = 0;

            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, arr[i]);
                if (max == i)
                    res++;
            }

            return res;
        }
    }

    /**************************************MAXIMUM CHUNKS TO MAKE SORTED ARRAY II******************************
     * 
     * This question is the same as "Max Chunks to Make Sorted" except the integers of the given array are not necessarily distinct, the input array could be up to length 2000, and the elements could be up to 10**8.
       Given an array arr of integers (not necessarily distinct), we split the array into some number of "chunks" (partitions), and individually sort each chunk.  After concatenating them, the result equals the sorted array.
       What is the most number of chunks we could have made?
       
       Example 1:
       Input: arr = [5,4,3,2,1]
       Output: 1
       Explanation:
       Splitting into two or more chunks will not return the required result.
       For example, splitting into [5, 4], [3, 2, 1] will result in [4, 5, 1, 2, 3], which isn't sorted.
       
       Example 2:
       Input: arr = [2,1,3,4,4]
       Output: 4
       Explanation:
       We can split into two chunks, such as [2, 1], [3, 4, 4].
       However, splitting into [2, 1], [3], [4], [4] is the highest number of chunks possible.
       
       Note:
       arr will have length in range [1, 2000].
       arr[i] will be an integer in range [0, 10**8].
     **************************/
    public class MaxChunksToMakeSorted_II_Solution
    {
        //TC - O(N)
        //SC - O(N)
        public int MaxChunksToSortedII(int[] arr)
        {
            int n = arr.Length;

            //calculate max value from left side
            int[] maxLeft = new int[n];
            maxLeft[0] = arr[0];
            for (int i = 1; i < n; i++)
                maxLeft[i] = Math.Max(maxLeft[i - 1], arr[i]);

            //calculate min value from right side
            int[] minRight = new int[n];
            minRight[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                minRight[i] = Math.Min(minRight[i + 1], arr[i]);

            int res = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (maxLeft[i] <= minRight[i + 1])
                    res++;
            }
            return res + 1;
        }

        //TC - O(N)
        //SC - O(N)
        public int MaxChunksToSortedII_2(int[] arr)
        {
            int n = arr.Length;

            //calculate min value from right side
            int[] minRight = new int[n];
            minRight[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
                minRight[i] = Math.Min(minRight[i + 1], arr[i]);

            int res = 0;
            int max = int.MinValue; // instead of having a MaxLeft array, calculating at final loop
            for (int i = 0; i < n - 1; i++)
            {
                max = Math.Max(max, arr[i]);
                if (max <= minRight[i + 1])
                    res++;
            }
            return res + 1;
        }
    }
}
