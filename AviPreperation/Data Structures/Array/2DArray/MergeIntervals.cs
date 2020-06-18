using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class MergeIntervalsSolution
    {
        //TC- O(n logn)- for sorting and linear tc for iterating intervals
        //SC - O(1), no extra space is using except the result
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length <= 1)
                return intervals;

            //need to sort to merge the inervals start comes before the previous interval end
            System.Array.Sort(intervals, (a, b) => a[0] - b[0]);

            //adding first interval to res, to compare with nect one
            List<int[]> res = new List<int[]>();
            res.Add(intervals[0]);

            //iterate remaining intervals
            for (int i = 1; i < intervals.Length; i++)
            {
                //get the cur interval and previous one from the res
                int[] prev = res.Last();
                int[] cur = intervals[i];

                //if end of prvious is higher than the start of cur, then change the previous end with max of that and cur end.
                if (prev[1] >= cur[0])
                    prev[1] = Math.Max(cur[1], prev[1]);
                else
                    res.Add(cur);
            }

            return res.ToArray();
        }
    }
}
