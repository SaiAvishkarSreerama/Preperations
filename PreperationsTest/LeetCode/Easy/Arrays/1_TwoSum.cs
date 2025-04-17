/*
* TimeComplexity - O(N)
* SpaceComplexity - O(N)
* 
* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
* You may assume that each input would have exactly one solution, and you may not use the same element twice.
* You can return the answer in any order.
* 
* Example 1:
* 
* Input: nums = [2,7,11,15], target = 9
* Output: [0,1]
* Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
* 
* Example 2:
* 
* Input: nums = [3,2,4], target = 6
* Output: [1,2]
* 
* Example 3:
* 
* Input: nums = [3,3], target = 6
* Output: [0,1]
*/
namespace PreperationsTest.LeetCode.Easy.Arrays
{
    [TestClass]
    public class _1_TwoSum
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            TwoSum(nums, 9);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new int[] { };

            Dictionary<int, int> dict = new Dictionary<int, int>();
            // Iterate the input array 
            for (int i = 0; i < nums.Length; i++)
            {

                // To avoid duplicate number consideration, skip when we see the same num in the dict
                // But here we can use duplicate num, as in quest mentioned we cannot use the same num, but 
                // simiilar num comes we can use it
                // if(dict.ContainsKey(nums[i])){
                //     continue;
                // }

                // check for the result value in dict
                int secondNum = target - nums[i];
                if (dict.ContainsKey(secondNum))
                {
                    // if found here, we can return current index and the index in dict
                    return new int[] { dict[secondNum], i };
                }

                // add the num as key and index as value in tothe dictionary
                dict[nums[i]] = i;
            }

            return new int[] { };
        }
    }
}
