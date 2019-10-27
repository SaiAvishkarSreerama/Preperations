using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
    class NumberOfIslands_BFS_DFS
    {
        static int NumberOfIslands_DFS(char[][] grid)
        {
            //Edge case scenario
            if (grid.Length == 0 || grid == null)
                return 0;
            //no of islands is intially 0
            int numIslands = 0;
            int rowLength = grid.Length;
            int columnLength = grid[0].Length;
            //iterating through the rows
            for (int i = 0; i < rowLength; i++)
            {
                //iterating through column of each row
                for (int j = 0; j < columnLength; j++)
                {
                    //if the value found at is 1 then considering it as island, and traversing its neighbor values
                    if (grid[i][j] == '1')
                    {
                        numIslands++;
                        DFS(grid, i, j);
                    }
                }
            }

            //returning the no of islands
            return numIslands;
        }

        static void DFS(char[][] grid, int i, int j)
        {
            //if iand j are below 0's or above the lenghts of row,column return back
            //if value found is '0' then we are end of '1's then return back too
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0')
                return;

            //once the value is visited we are marking it as '0', so that it would not be visited seconf time
            grid[i][j] = '0';

            DFS(grid, i + 1, j);//checking the below row 
            DFS(grid, i - 1, j);//checking the above row 
            DFS(grid, i, j + 1);//checking the right column 
            DFS(grid, i, j - 1);//checking the left column
            return;
        }

        //static void Main()
        //{
        //    char[][] grid = new char[4][];
        //    //Ex-1
        //    grid[0] = new char[] { '1', '1', '1', '1', '0' };
        //    grid[1] = new char[] { '1', '1', '0', '1', '0' };
        //    grid[2] = new char[] { '1', '1', '0', '0', '0' };
        //    grid[3] = new char[] { '0', '0', '0', '0', '0' };

        //    //Ex-2
        //    //grid[0] = new char[] { '1', '1', '0', '0', '0' };
        //    //grid[1] = new char[] { '1', '1', '0', '0', '0' };
        //    //grid[2] = new char[] { '0', '0', '1', '0', '0' };
        //    //grid[3] = new char[] { '0', '0', '0', '1', '1' };
        //    int numOfIslands = 0;
        //    //Using DepthFirstSearch
        //    numOfIslands = NumberOfIslands_DFS(grid);

        //    Console.WriteLine(numOfIslands);

        //}
    }
}
