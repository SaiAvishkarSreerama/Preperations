
/*
* Given a collection of intervals, merge all overlapping intervals.
* 
* Example 1:
* 
* Input: [[1,3],[2,6],[8,10],[15,18]]
* Output: [[1,6],[8,10],[15,18]]
* Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
* Example 2:
* 
* Input: [[1,4],[4,5]]
* Output: [[1,5]]
* Explanation: Intervals [1,4] and [4,5] are considered overlapping.
* NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature. 
* */

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _56_MergeIntervals
    {
        [TestMethod]
        public void Run()
        {
            int[][] input = [[1, 3], [2, 6], [8, 10], [15, 18]];
            int[][] output = Merge(input);
        }

        // TC - O(nlogn), sorting
        // SC - O(n)
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            // Sort the arrays based on their start value
            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> result = new List<int[]>();
            result.Add(intervals[0]);

            //Iterate all other intervals and merge with the prev intervals
            foreach (var curr in intervals)
            {
                int[] prev = result.Last();
                if (prev[1] >= curr[0])
                {
                    prev[1] = Math.Max(prev[1], curr[1]);
                }
                else
                {
                    result.Add(curr);
                }
            }

            return result.ToArray();
        }
    }
}
