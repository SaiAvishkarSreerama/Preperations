using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation
{
    class _4Sum
    {
        //Time Complexity - O(n^3)
        //Space Complexity - O(n)
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            //Edge case before sorting
            if (nums.Length < 4)
                return result;

            //sort the array for unique list output
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                //if nums[i], 4 times gives more than target, then break
                if (nums[i] * 4 > target)
                    break;
                if (i != 0 && nums[i] == nums[i - 1])
                    continue;

                //Three sum 
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    //if nums[j], 3 times gives more than target-nums[i], then break
                    if (nums[j] * 3 > target - nums[i])
                        break;
                    if (j != i + 1 && nums[j] == nums[j - 1])
                        continue;

                    //Two Sum
                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                            //avoid duplicates
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum > target)
                        {
                            right--;
                        }
                        else
                        {
                            left++;
                        }
                    }
                }
            }
            return result;
        }

        //static void Main()
        //{
        //    int[] a = new int[] { -2, 0, 1, 1, 2 };
        //    ThreeSum(a);
        //}
    }
}
