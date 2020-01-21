using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class CutTreesForGolfEventSolution
    {
        //BFS -****************WRONG SOLUTION****************
        public static int CutOffTree(IList<IList<int>> forest)
        {
            int R = forest.Count;
            int C = forest[0].Count;
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { 0, 0 });

            int[][] dir = {
            new int[]{0, 1},
            new int[]{0,-1},
            new int[]{1, 0},
            new int[]{-1,0}
        };

            bool[,] seen = new bool[R, C];
            seen[0, 0] = true;
            int steps = 0;
            while (q.Count > 0)
            {
                int[] cur = q.Dequeue();
                if (cur[0] == R - 1 && cur[1] == C - 1)
                    return cur[2];
                foreach (int[] d in dir)
                {
                    int r = cur[0] + d[0];
                    int c = cur[1] + d[1];
                    Console.WriteLine(r + "_" + c);
                    if (r < 0 || r >= R || c < 0 || c >= C || seen[r, c] || forest[r][c] == 0)
                        continue;

                    seen[r, c] = true;
                    steps++;
                    q.Enqueue(new int[] { r, c});
                }
            }
            //return steps > 0 ? steps : - 1;
            return -1;
        }

        //public static void Main()
        //{
        //    List<IList<int>> forest = new List<IList<int>>() {
        //    new List<int>{ 1, 2, 3 },
        //    new List<int> { 0, 0, 4 },
        //    new List<int> { 7, 6, 5 }};
        //    CutOffTree(forest);
        //}
    }
}
