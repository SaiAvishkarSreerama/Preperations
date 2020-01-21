using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class CherryPickSolution
    {
        //using DFS
        //TC - O(N3)
        //SC - O(N2)
        public int CherryPickup(int[][] grid)
        {
            int N = grid.Length;
            int M = 2 * N - 1;//(N << 1) - 1; // == 2 * (N - 1)
            int[,] dp = new int[N, N];

            dp[0, 0] = grid[0][0];

            //n = i+j = p+q ==> j=n-1 and q=n-p
            for (int n = 1; n < M; n++)
            {
                for (int i = N - 1; i >= 0; i--)
                {
                    for (int p = N - 1; p >= 0; p--)
                    {
                        int j = n - i;
                        int q = n - p;

                        if (j < 0 || j >= N || q < 0 || q >= N || grid[i][j] < 0 || grid[p][q] < 0)
                        {
                            dp[i, p] = -1;
                            continue;
                        }

                        if (i > 0)
                            dp[i, p] = Math.Max(dp[i, p], dp[i - 1, p]);
                        if (p > 0)
                            dp[i, p] = Math.Max(dp[i, p], dp[i, p - 1]);
                        if (i > 0 && p > 0)
                            dp[i, p] = Math.Max(dp[i, p], dp[i - 1, p - 1]);
                        if (dp[i, p] >= 0)
                            dp[i, p] += grid[i][j] + (i != p ? grid[p][q] : 0);

                    }
                }
            }

            return Math.Max(dp[N - 1, N - 1], 0);
        }

        //public static void Main()
        //{
        //    int[][] grid = new int[3][];
        //    grid[0] = new int[3] { 0, 1, -1 };
        //    grid[1] = new int[3] { 1, 0, -1 };
        //    grid[2] = new int[3] { 1, 1, 1 };
        //    var obj = new CherryPickSolution();
        //    obj.CherryPickup(grid);
        //}
    }
}
