using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
    public class IslandPerimeterSol
    {
        public int IslandPerimeter(int[][] grid)
        {
            int p = 0;
            int rl = grid.Length;
            int cl = grid[0].Length;
            for (int r = 0; r < rl; r++)
            {
                for (int c = 0; c < cl; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        if (c - 1 < 0 || grid[r][c - 1] == 0) p++;
                        if (c + 1 >= cl || grid[r][c + 1] == 0) p++;
                        if (r - 1 < 0 || grid[r - 1][c] == 0) p++;
                        if (r + 1 >= rl || grid[r + 1][c] == 0) p++;
                    }
                }
            }

            return p;
        }
    }
}
