using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class KClosestPointsToOriginSolution
    {
        //TC - O(N logN), logN for sorted dictionary, ADD, contiansKey, Remove
        //SC - O(N)
        public int[][] KClosest(int[][] points, int k)
        {
            List<int[]> res = new List<int[]>();

            SortedDictionary<int, List<int[]>> d = new SortedDictionary<int, List<int[]>>();

            foreach (var p in points)
            {
                int dist = p[0] * p[0] + p[1] * p[1];
                if (!d.ContainsKey(dist))
                {
                    d.Add(dist, new List<int[]>());
                }
                d[dist].Add(p);
            }

            while (k > 0)
            {
                var key = d.First().Key;
                foreach (var p in d[key])
                {
                    if (k > 0)
                    {
                        res.Add(p);
                        k--;
                    }
                    if (k == 0)
                        break;
                }
                d.Remove(key);
            }

            return res.ToArray();
        }
        //public static void Main()
        //{
        //    int[][] points = new int[3][]
        //    {
        //       new int[]{3,3},
        //       new int[]{5,-1},
        //       new int[]{-2,4}
        //    };
        //    var obj = new KClosestPointsToOriginSolution();
        //    Console.WriteLine(obj.KClosest(points, 2));
        //}
    }
}
