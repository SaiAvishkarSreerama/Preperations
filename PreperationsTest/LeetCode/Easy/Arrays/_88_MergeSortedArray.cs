/*
 * You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
 * Merge nums1 and nums2 into a single array sorted in non-decreasing order.
 * The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
 * 
 * Example 1:
 * Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
 * Output: [1,2,2,3,5,6]
 * Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
 * The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
 * 
 * Example 2:
 * Input: nums1 = [1], m = 1, nums2 = [], n = 0
 * Output: [1]
 * Explanation: The arrays we are merging are [1] and [].
 * The result of the merge is [1].
 * 
 * Example 3:
 * Input: nums1 = [0], m = 0, nums2 = [1], n = 1
 * Output: [1]
 * Explanation: The arrays we are merging are [] and [1].
 * The result of the merge is [1].
 * Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
 *  */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Easy.Arrays
{
    [TestClass]
    public class _88_MergeSortedArray
    {
        [TestMethod]
        public void Run()
        {
            int[] nums1 = [1, 2, 3, 0, 0, 0;
            int m = 3;
            int[] nums2 = [2, 5, 6];
            int n = 3;
            Merge(nums1, m ,nums2, n);
        }

        /// <summary>
        /// TC - O(m+n)
        /// SC - O(m), used new array to get out nums1[m] values
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = 0, j = 0, k = 0;
            int[] newNum1 = new int[m];
            for (i = 0; i < m; i++)
            {
                newNum1[i] = nums1[i];
            }

            i = 0;
            while (i < m && j < n)
            {
                if (newNum1[i] < nums2[j])
                {
                    nums1[k++] = newNum1[i++];
                }
                else
                {
                    nums1[k++] = nums2[j++];
                }
            }

            while (i < m)
            {
                nums1[k++] = newNum1[i++];
            }
            while (j < n)
            {
                nums1[k++] = nums2[j++];
            }
        }

        /// <summary>
        /// TC - O(m+n)
        /// SC - O(1)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge_InPlace(int[] nums1, int m, int[] nums2, int n)
        {
            // In-place replace of nums1
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k--] = nums1[i--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }

            while (j >= 0)
            {
                nums1[k--] = nums2[j--];
            }
        }

    }
}
