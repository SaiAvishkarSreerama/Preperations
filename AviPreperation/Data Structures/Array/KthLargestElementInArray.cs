using System;
using System.Collections.Generic;
using System.Text;
/*
*  Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.
* 
* Example 1:
* 
* Input: [3,2,1,5,6,4] and k = 2
* Output: 5
* Example 2:
* 
* Input: [3,2,3,1,2,4,5,5,6] and k = 4
* Output: 4
* Note:
* You may assume k is always valid, 1 ≤ k ≤ array's length.
*/

//Companies: @Meta @Google @Apple @MSFT @Amazon
namespace AviPreperation.Data_Structures.Array
{
    public class KthLargestElementInArraySolution
    {
        //TC - O(NlogN)
        //SC - O(1)
        public int FindKthLargest1(int[] nums, int k)
        {
            System.Array.Sort(nums);
            return nums[nums.Length - k];
        }

        //TC- Hence the array is now split into two parts. If that would be a quicksort algorithm, one would proceed recursively to use quicksort for the both parts that would result in O(NlogN) time complexity. Here there is no need to deal with both parts since now one knows in which part to search for N - kth smallest element, and that reduces average time complexity to O(N).
        //SC - O(1)
        //USING QUICK SELECT, in quick sort, we care of both sides of the partition, here we just need a n-k side, either pivot+1 or pivot-1, reduces NlogN to Linear TC N.
        public int FindKthLargest(int[] nums, int k)
        {
            int n = nums.Length;
            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                int pivot = Partition(nums, left, right);
                Console.WriteLine(pivot);
                if (pivot == n - k)
                    return nums[n - k];
                else if (pivot < n - k)
                    left = pivot + 1;
                else
                    right = pivot - 1;
            }

            return -1;
        }

        public int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (nums[j] < pivot)
                {
                    Swap(nums, i, j);
                    i++;
                }
            }

            Swap(nums, i, right);
            return i;
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
        }
    }
}
