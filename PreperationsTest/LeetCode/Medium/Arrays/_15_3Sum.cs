/*
 * Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
 * Notice that the solution set must not contain duplicate triplets.
 * 
 * Example 1:
 * Input: nums = [-1,0,1,2,-1,-4]
 * Output: [[-1,-1,2],[-1,0,1]]
 * Explanation: 
 * nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
 * nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
 * nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
 * The distinct triplets are [-1,0,1] and [-1,-1,2].
 * Notice that the order of the output and the order of the triplets does not matter.
 * 
 * Example 2:
 * Input: nums = [0,1,1]
 * Output: []
 * Explanation: The only possible triplet does not sum up to 0.
 * 
 * Example 3:
 * Input: nums = [0,0,0]
 * Output: [[0,0,0]]
 * Explanation: The only possible triplet sums up to 0.
*/

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _15_3Sum
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> ans =  ThreeSum(nums);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3)
            {
                return null;
            }

            //Sort the array
            Array.Sort(nums);

            List<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                // if the current number is same as prvious one, skip it,as it gives us the same result
                if (i > 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }

                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        List<int> triplets = new List<int> { nums[i], nums[l], nums[r] };
                        result.Add(triplets);
                        // skip the duplicate numbers here
                        while (l < r && nums[l] == nums[l + 1])
                        {
                            l++;
                        }
                        while (l < r && nums[r] == nums[r - 1])
                        {
                            r--;
                        }
                        // move to next numbers
                        l++; r--;
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
            return result;
        }
    }
}
