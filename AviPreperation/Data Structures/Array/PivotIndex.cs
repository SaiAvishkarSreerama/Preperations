using System;
using System.Collections.Generic;
using System.Linq;

public class PivotIndexClass
{
    // All Test cases passed but O(n^2)
    public int PivotIndex2(int[] nums)
    {
        int index = -1;
        if (nums.Length == 0)
            return index;
        for (int i = 0; i < nums.Length; i++)
        {
            int lSum = 0;
            int rSum = 0;
            //Left
            for(int j =i- 1 ; j >= 0; j--)
            {
                lSum += nums[j];
            }
            //Right
            for (int k = i + 1; k < nums.Length; k++)
            {
                rSum += nums[k];
            }

            if (lSum == rSum)
            {
                return i;
            }
        }
        return index;
    }

    //Reccommended
    public int PivotIndex(int[] nums)
    {
        Array.Sort(nums);
        if (nums.Length == 0 || nums == null)
            return -1;

        int sum = nums.Sum();
        int leftSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if ((sum = sum - nums[i]) == leftSum)
                return i;
            else
                leftSum += nums[i];
        }

        return -1;
    }
}
public class PivotIndexMainClass
{
    //static void Main()
    //{
    //    var pIndex = new PivotIndexClass();
    //    int[] Array = new int[] { 1, 7, 3, 6, 5, 6 };
    //    //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
    //    Console.WriteLine(pIndex.PivotIndex(Array));
    //    Console.ReadLine();
    //}
}
    