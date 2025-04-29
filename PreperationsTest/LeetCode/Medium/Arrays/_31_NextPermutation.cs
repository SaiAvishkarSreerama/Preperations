/*
 * Lexicographical order of 1,2,3 => 1,3,2 (for each number the remaining nums start from lower to higher and end as higher to lower) 
 * for 2: 2,1,3 => 2,3,1
 * for 3: 3,1,2 => 3,2,1
 * if have 4: 1,2,3,4=> 1,2,4,3=>1,3,2,4=>1,3,4,2 => 1,4,2,3 => 1,4,3,2 ===> [1, (2,3,4)] to [1,(4,3,2)]
 * 
 * A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
 * 
 * For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
 * The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).
 * 
 * For example, the next permutation of arr = [1,2,3] is [1,3,2].
 * Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
 * While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
 * Given an array of integers nums, find the next permutation of nums.
 * The replacement must be in place and use only constant extra memory.
 * 
 * Example 1:
 * Input: nums = [1,2,3]
 * Output: [1,3,2]
 * 
 * Example 2:
 * Input: nums = [3,2,1]
 * Output: [1,2,3]
 * 
 * Example 3:
 * Input: nums = [1,1,5]
 * Output: [1,5,1]
 * 
 * Constraints:
 * 1 <= nums.length <= 100
 * 0 <= nums[i] <= 100
 */

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _31_NextPermutation
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            NextPermutation(nums);

            // Print nums[];
        }

        /// <summary>
        /// Lexicographical means the numbers/alphabets arranged in a dictionary order
        /// numbers must be in order, if not we can form the next possible permutation with that number and remaining nums will be in asc order
        /// 
        /// TC - O(N), as we traverse atmost n values to get the i and j to swap. and reverse the remaining numbers - O(n), total will be O(n)
        /// SC - O(1), inplace updation only
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {

            // Iterate from last

            // 1 > 5 > 8 > 4 !> 7 > 6 > 5 > 3 > 1 - stops at 4
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            // to find the closest number to the i from i to end of the array 
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }

                // found nums[j] >= nums[i] then Swap i and j
                Swap(nums, i, j);
            }

            // To get the next permutation, we need to arrange the i-next values in order
            Reverse(nums, i + 1);
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[j];
            nums[j] = nums[i];
            nums[i] = temp;
        }

        // Reversing the remaining numbers after the swap
        // after swap: 1 5 8 5 7 6 4 3 1
        // next perm : 1 5 8 5 1 3 4 6 7 (after 5 we start from low to high) to get this we need to reverse the numbers after 5
        // nums after 5 exists in the ascending order only
        public void Reverse(int[] nums, int start)
        {
            int i = start;
            int j = nums.Length - 1;
            while (i <= j)
            {
                Swap(nums, i++, j--);
            }
        }
    }
}
