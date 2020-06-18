using System;
using System.Collections.Generic;
using System.Text;

/*Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), determine if a person could attend all meetings.
* 
* Example 1:
* 
* Input: [[0,30],[5,10],[15,20]]
* Output: false
* Example 2:
* 
* Input: [[7,10],[2,4]]
* Output: true
* NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
**/
namespace AviPreperation.Data_Structures.Array
{
    /*************************************************ONE-determine if a person could attend all meetings********************************************************/
    public class MeetingRoomISolution
    {
        //TC - O(NlogN)
        //SC - O(1)
        //NOTE: Similar to Merge Intervals
        public bool CanAttendMeetings(int[][] intervals)
        {
            System.Array.Sort(intervals, (a, b) => a[0] - b[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                //previous end(1) < current start(0), means ovelapping
                if (intervals[i - 1][1] > intervals[i][0])
                    return false;
            }

            return true;
        }
    }

    /************************************************TWO-find the minimum number of conference rooms required.*********************************************************/
    public class MinMeetingRoomsIISolution
    {
        //USING TWO ARRAYS
        //TC - O(NlogN)
        //SC - O(N)
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            //Sort the start and end arrays
            System.Array.Sort(start);
            System.Array.Sort(end);

            int rooms = 0;
            int endIter = 0;
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i] < end[endIter])
                    rooms++;
                else
                    endIter++;
            }
            return rooms;
        }
    }
}
