using System;
using System.Collections.Generic;
using System.Linq;

public class DominantIndexClass
{
    // All Test cases passed 
    // Below code used Sort()- O(nlogn) ang beats 83.06% C# submissions
    public int DominantIndex1(int[] nums)
    {
        //If only one element present, then it is the largaest one and returns it
        if (nums.Length == 1)
            return 0;

        //declare a new array temp
        var temp = new int[nums.Length];
        nums.CopyTo(temp, 0);
        Array.Sort(temp);

        if (temp[temp.Length - 1] >= 2 * temp[temp.Length - 2])
        {
            return Array.IndexOf(nums, temp[temp.Length - 1]);
        }

        return -1;
    }

    //Recommended as this gives the TimeComplexity O(n)
    public int DominanaIndex(int[] nums)
    {
        int HighestNum = 0;
        int HighestNumIndex = 0;
        int SecondHighestNum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > HighestNum)
            {
                SecondHighestNum = HighestNum;
                HighestNum = nums[i];
                HighestNumIndex = i;
            }
            else if (nums[i] > SecondHighestNum)
            {
                SecondHighestNum = nums[i];
            }
        }

        return HighestNum >= 2 * SecondHighestNum ? HighestNumIndex : -1;
    }
}
public class DominantIndexMainClass
{
    //static void Main()
    //{
    //    var pIndex = new DominantIndexClass();
    //    int[] Array = new int[] { 1, 7, 3, 6, 5, 6 };
    //    //int[] Array = new int[] { -1, -1, -1, 0, 1, 1 };
    //    Console.WriteLine(pIndex.DominantIndex(Array));
    //    Console.ReadLine();
    //}
}
    