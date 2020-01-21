using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Assessments.VolkesWagon
{
    class MAthHomeWork
    {
        public int minNum(int threshold, List<int> points)
        {
            int count = 1;
            bool thresholdreached = false;
            for (int i = 0; i < points.Count; i++)
            {
                count++;
                if (i + 2 < points.Count)
                {
                    if (threshold <= points[i + 2] - points[0])
                    {
                        thresholdreached = true;
                        break;
                    }
                    i++;
                }
                else if (i + 1 < points.Count)
                {
                    if (threshold <= points[i + 1] - points[0])
                    {
                        thresholdreached = true;
                        break;
                    }
                }
            }
            return thresholdreached ? count : points.Count;
        }
        public static int minNum1(int threshold, int[] points)
        {
            int result = 0;
            helper(threshold, points, result);
            return result;
        }

        public static void helper(int t, int[] points, int result)
        {
            if (result == t)
                return;

            //helper(t, points, );

        }

        //public static void Main()
        //{
        //    //min num of steps to reach from 1st index we can go either i+1 or i+2
        //    int threshold = 4;
        //    int[] points = { 1, 2, 3, 5, 8 };

        //    //minNum(threshold, points);
        //}
    }
}
