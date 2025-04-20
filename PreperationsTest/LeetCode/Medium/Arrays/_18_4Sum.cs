/*
 * Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
 * 0 <= a, b, c, d < n
 * a, b, c, and d are distinct.
 * nums[a] + nums[b] + nums[c] + nums[d] == target
 * You may return the answer in any order.
 * 
 * Example 1:
 * Input: nums = [1,0,-1,0,-2,2], target = 0
 * Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
 * 
 * Example 2:
 * Input: nums = [2,2,2,2,2], target = 8
 * Output: [[2,2,2,2]]
 * 
 * Constraints:
 * 1 <= nums.length <= 200
 * -109 <= nums[i] <= 109
 * -109 <= target <= 109
 * 
 * TC - O(n^3)
 * SC - O(k), k is not of quadruplets
 *  */

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _18_4Sum
    {
        [TestMethod]
        public void Run()
        {
            //int[] arr = { 1, 0, 0, -1, -2, 2 }; int target = 0 // -2 -1 0 0 1 2
            //int[] arr = { 2, 2, 2, 2, 2 }; int target = 8
            int[] arr = { 0, 0, 0, -1000000000, -1000000000, -1000000000, -1000000000 }; int target = -1000000000;
            IList<IList<int>> result = FourSum(arr, target);
        }

        /// <summary>
        /// TC - O(n^3)
        /// SC - O(k), k is not of quadruplets
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (nums.Length < 4)
            {
                return res;
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1])
                        continue;
                    int l = j + 1;
                    int r = nums.Length - 1;
                    while (l < r)
                    {
                        long sum = (long)nums[i] + nums[j] + nums[l] + nums[r];
                        if (sum == target)
                        {
                            res.Add(new List<int> { nums[i], nums[j], nums[l], nums[r] });
                            while (l < r && nums[l] == nums[l + 1])
                            {
                                l++;
                            }
                            while (l < r && nums[r] == nums[r - 1])
                            {
                                r--;
                            }
                            l++; r--;
                        }
                        else if (sum < target)
                        {
                            l++;
                        }
                        else
                        {
                            r--;
                        }
                    }
                }
            }
            return res;
        }
    }

    /**
     if(nums==null || nums.Length<4){
            return li;
        }
        Array.Sort(nums);
        for(int i=0;i<nums.Length-3;i++){
            if(i>0&&nums[i]==nums[i-1]){
                continue;
            }
            for(int j=i+1;j<nums.Length-2;j++){
                if(j>i+1&&nums[j]==nums[j-1]){
                    continue;
                }
                int left=j+1; int right=nums.Length-1;
                while(left<right){
                    long sum=(long)nums[i]+nums[j]+nums[left]+nums[right];
                    if(sum==target){
                        li.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                        while(left<right&&nums[left]==nums[left+1]){
                            left++;
                        }
                        while(left<right&&nums[right]==nums[right+-1]){
                            right--;
                        }
                        left++;
                        right--;
                    }else if(sum<target){
                        left++;
                    }else{
                        right--;
                    }
                }
            }
        }
        return li;
     
     */
}
