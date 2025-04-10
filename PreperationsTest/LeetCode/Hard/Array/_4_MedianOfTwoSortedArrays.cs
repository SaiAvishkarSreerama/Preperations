using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.LeetCode.Hard.Array
{
    [TestClass]
    public class _4_MedianOfTwoSortedArrays
    {
        [TestMethod]
        public void Run()
        {
            int[] nums1 = { 1, 3, 8 };
            int[] nums2 = { 7, 9, 10, 11 };
            double median = FindMedianSortedArrays(nums1, nums2);

            median = FindMedianSortedArrays_BinarySearch(nums1, nums2);
        }

        /// <summary>
        /// Naive approach
        /// TC - O(n+m)
        /// SC - O(n+m)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            List<int> arr = new List<int>();
            int i = 0;
            int j = 0;

            while (i < n1 && j < n2)
            {
                if (nums1[i] <= nums2[j])
                {
                    arr.Add(nums1[i++]);
                }
                else
                {
                    arr.Add(nums2[j++]);
                }
            }
            while (i < n1)
            {
                arr.Add(nums1[i++]);
            }
            while (j < n2)
            {
                arr.Add(nums2[j++]);
            }

            if (arr.Count % 2 == 0)
            {
                int medianIndex = arr.Count / 2;
                return (double)(arr[medianIndex] + arr[medianIndex - 1]) / 2;
            }
            else
            {
                double medianIndex = arr.Count / 2;
                return arr[(int)Math.Floor(medianIndex)];
            }
        }

        /// <summary>
        /// Using Binary search and no extra space
        /// TC - O(log(min(x,y)))
        /// SC - O(1)
        /// Yt: https://www.youtube.com/watch?v=LPFhl65R7ww&ab_channel=TusharRoy-CodingMadeSimple (Tushar Roy)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays_BinarySearch(int[] nums1, int[] nums2)
        {
            // Always perform binary search on smaller array
            if (nums1.Length < nums2.Length)
            {
                FindMedianSortedArrays(nums2, nums1);
            }

            // Initialize variable to keep track of lengths
            int x = nums1.Length;
            int y = nums2.Length;
            int low = 0;
            int high = x;

            while (low <= high)
            {
                // Partioning both X and Y such that left sides of both X and Y are lesser values than right sides of both x and y, Also having equal number of elements on both lefts and rights
                // x = [1 3 8] then  [1 | 3 8], partX = 1 initially
                // y = [7 9 10 11] then [7 9 10 | 11], partY=3
                // So we have 1 & 7 9 10 | 3 8 & 11
                int partitionX = (low + high) / 2;
                int partitionY = (x + y + 1) / 2 - partitionX;

                int maxLeftX = partitionX == 0 ? int.MinValue : nums1[partitionX - 1];
                int minRightX = partitionX == x ? int.MaxValue : nums1[partitionX];

                int maxLeftY = partitionY == 0 ? int.MinValue : nums2[partitionY - 1];
                int minRightY = partitionY == y ? int.MaxValue : nums2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    // combined: Even element array
                    if ((x + y) % 2 == 0)
                    {
                        return ((double)Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    // our partition is way on right side, move to left side
                    high = partitionX - 1;
                }
                else
                {
                    // we are way on left side, move to right
                    low = partitionX + 1;
                }
            }

            throw new InvalidOperationException("Input arrays are not sorted properly.");

        }
    }
}
