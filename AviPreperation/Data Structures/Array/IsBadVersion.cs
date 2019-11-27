using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

    public class IsBadVersionSolution
    {
        //Time Complexity - O(logn)
        //Space Complexity - O(1)
        public int FirstBadVersion(int n)
        {
            //Binary search
            int low = 1;
            int high = n;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (true) //isBadVersion(mid)
                { //isBadVersion(mid) is not working, given 4 in the test case
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
