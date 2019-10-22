using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    class MountainPeakpublic  
    {
        //If single peak exists Binary seach helps to find the value in O(logN)
        public int PeakIndexInMountainArray(int[] A)
        {

            //Binary search algorithm - O(logN)
            int low = 0;
            int high = A.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (A[mid] < A[mid + 1])
                    low = mid + 1;
                else
                    high = mid;
            }

            return low;
        }

        //If multiple peaks exists and to find heighest peak
        public int PeakIndexInMountainArrayPEAKS(int[] A)
        {
            if (A.Length == 0 || A.Length < 3)
                return 0;

            int num = 0;
            int index = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if (num < A[i])
                {
                    num = A[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
