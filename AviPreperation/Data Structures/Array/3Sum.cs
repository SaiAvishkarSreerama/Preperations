using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

class ThreeSumClass
{
    /*********************Leetcode Solutions***********************/
    public static IList<IList<int>> ThreeSum1(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();

        var n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i]) continue;

            var left = i + 1;
            var right = n - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
    
    /*********************My Solutions***********************/
    //TimeComplexity - O(n^2)
    //Space Complexity - O(n)
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums); //Sorting takes O(n) Time complexity
        HashSet<List<int>> h = new HashSet<List<int>>();
        List<IList<int>> res = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
                continue;
            FindTwoSum(i, nums, h);
        }

        foreach (var d in h)
        {
            res.Add(d);
        };

        return res;
    }

    public void FindTwoSum(int i, int[] A, HashSet<List<int>> h)
    {
        int l = i + 1;
        int r = A.Length - 1;

        while (l < r)
        {
            int totalSum = A[i] + A[l] + A[r];
            if (totalSum == 0)
            {
                var list = new List<int> { A[i], A[l], A[r] };
                h.Add(list);
                while (l < r && A[l] == A[l + 1]) l++;
                while (l < r && A[r] == A[r - 1]) r--;

                l++; r--;
            }
            else if (totalSum < 0)
            {
                l++;
            }
            else
                r--;
        }
    }
    //static void Main()
    //{
    //    int[] a = new int[] { -2, 0, 1, 1, 2 };
    //    ThreeSum(a);
    //}
}

