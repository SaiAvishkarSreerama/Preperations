using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.LeetCodePrep._3.Hard
{
    //There are two sorted arrays nums1 and nums2 of size m and n respectively.

    //Find the median of the two sorted arrays./********The overall run time complexity should be O(log (m+n))*****/.

    //You may assume nums1 and nums2 cannot be both empty.

    //Example 1:

    //nums1 = [1, 3]
    //nums2 = [2]

    //The median is 2.0
    //Example 2:

    //nums1 = [1, 2]
    //nums2 = [3, 4]

    //The median is (2 + 3)/2 = 2.5
    class SortedArraysMedian
    {
        //Time Complexity O(m+n)
        //Space Complexity O(m+n)
        public static double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {

            int i = 0, j = 0, k = 0;
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            int[] arr = new int[n1 + n2];

            while (i < n1 && j < n2)
            {
                if (nums1[i] < nums2[j])
                    arr[k++] = nums1[i++];
                else
                    arr[k++] = nums2[j++];
            }
            while (i < n1)
                arr[k++] = nums1[i++];

            while (j < n2)
                arr[k++] = nums2[j++];

            int arrLength = arr.Length - 1;
            if (arr.Length % 2 == 0)
            {
                return ((double)(arr[(arrLength - 1) / 2] + arr[(arrLength + 1) / 2]) / 2);
            }
            else
            {
                return arr[(arr.Length) / 2];
            }
        }

        //TimeComplexity O(log(min(x,y)))
        //Space Complexity O(1)
        //https://www.youtube.com/watch?time_continue=906&v=LPFhl65R7ww
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //We are doing operation by considering nums1 as smallest
            // If nums1 is bigger then recurse the function to swap the arrays
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            };

            //length of the arrays x will be smaller after the swapping
            int x = nums1.Length;
            int y = nums2.Length;
            // low and high index of array x
            int low = 0;
            int high = x;

            //As the partition on the array moves from start to end then the high and low values alter accordingly
            //iterating only when low is lesser than high
            while (low <= high)
            {
                //Partion x would divide the arry1 and parY for arr2
                int parX = (low + high) / 2;
                int parY = (x + y + 1) / 2 - parX;//here +1 is for handling both odd/even array count

                //if parX == 0 then we cannot go behind then considering it as -Infinity or int.min value and > x then Infinity or intmax
                int maxLeftX = parX == 0 ? int.MinValue : nums1[parX - 1];
                int minRightX = parX == x ? int.MaxValue : nums1[parX];

                //if parY == 0 and > y; same like x
                int maxLeftY = parY == 0 ? int.MinValue : nums2[parY - 1];
                int minRightY = parY == y ? int.MaxValue : nums2[parY];

                //Our goal is x array left ele should be less than Y array right elem and same for y array with x element 
                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    //even ele array
                    if ((x + y) % 2 == 0)
                    {
                        //median is the average of middle 2 elements of even array
                        //such that, maximum value of left side and minimum value of right side gives the average 
                        return (double)(Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    //odd array
                    else
                    {
                        //It is an odd, so middle value is enough, so max of left sides are middle value values
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                //if left is greater than right side then need to move the left to right side
                else if (maxLeftX > minRightY)
                {
                    high = parX - 1;
                }
                else
                {
                    low = parX + 1;
                }
            }

            //throw new ArgumentException(); 
            return 0.0;
        }

        //static void Main()
        //{
        //    int[] array1 = new int[] { 5, 2, 3};
        //    int[] array2 = new int[] { 1, 4, 6 };

        //    double val = FindMedianSortedArrays(array1, array2);

        //    Console.WriteLine(val);
        //    Console.ReadLine();
        //}
    }
}
