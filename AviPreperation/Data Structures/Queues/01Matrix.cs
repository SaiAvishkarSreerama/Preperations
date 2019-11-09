using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
    class _01Matrix
    {
        public static int[][] UpdateMatrix(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            if (m == 0)
                return matrix;

            Queue<int[]> q = new Queue<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                        q.Enqueue(new int[] { i, j });
                    else
                        matrix[i][j] = int.MaxValue;
                }
            }

            int[][] dir = new int[4][];
            dir[0] = new int[] { -1, 0};
            dir[1] = new int[] { 1, 0};
            dir[2] = new int[] { 0, -1};
            dir[3] = new int[] { 0, 1};

            while(q.Count > 0)
            {
                int[] cell = q.Dequeue();
                foreach (int[] d in dir)
                {
                    int r = cell[0] + d[0];
                    int c = cell[1] + d[1];

                    if (r < 0 || r >= m || c < 0 || c >= n || matrix[r][c] <= matrix[cell[0]][cell[1]] + 1)
                        continue;
                    q.Enqueue(new int[] {r,c});
                    matrix[r][c] = matrix[cell[0]][cell[1]] + 1;
                }
            }

            return matrix;
        }

        //static void Main()
        //{
        //    int[][] grid = new int[3][];
        //    //    //Ex-1
        //    grid[0] = new int[] { 0, 0, 0};
        //    grid[1] = new int[] { 0, 1, 0};
        //    grid[2] = new int[] { 0, 0, 0};

        //    UpdateMatrix(grid);

        //}
    }
}
