using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*In a given grid, each cell can have one of three values:
* 
* the value 0 representing an empty cell;
* the value 1 representing a fresh orange;
* the value 2 representing a rotten orange.
* Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.
* 
* Return the minimum number of minutes that must elapse until no cell has a fresh orange.  If this is impossible, return -1 instead.
* 
*  
* 
* Example 1:
* 
* 
* 
* Input: [[2,1,1],[1,1,0],[0,1,1]]
* Output: 4
* Example 2:
* 
* Input: [[2,1,1],[0,1,1],[1,0,1]]
* Output: -1
* Explanation:  The orange in the bottom left corner (row 2, column 0) is never rotten, because rotting only happens 4-directionally.
* Example 3:
* 
* Input: [[0,2]]
* Output: 0
* Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.
*  
* 
* Note:
* 
* 1 <= grid.length <= 10
* 1 <= grid[0].length <= 10
* grid[i][j] is only 0, 1, or 2.
*/
namespace AviPreperation.Data_Structures
{
    public class RottenOrangesSolution
    {
        //Using BFS
        //Time Complexity - O(m * n)
        //Space Complexity - O(m * n)
        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return -1;

            int R = grid.Length;
            int C = grid[0].Length;
            Queue<int[]> q = new Queue<int[]>();
            int freshOranges = 0;

            //Step1: interate the matrix and find fresh oranges count and push rotten oranges index[] in queue
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (grid[r][c] == 2)
                        q.Enqueue(new int[] { r, c });
                    else if (grid[r][c] == 1)
                        freshOranges++;
                }
            }

            //if fresh oranges are empty then return 0
            if (freshOranges == 0)
                return 0;

            //newd four directions of neighbors
            int[][] directions = {new int[]{1, 0}
                              ,new int[]{-1, 0}
                              ,new int[]{0, -1}
                              ,new int[]{0, 1}};
            int noOfMinutes = 0;

            //iterate till queue is empty
            //for each position of rotten orange in  queueu, iterate its 4 directions and make the 1s to 2s and push to queue again
            //after decrement fresh orange count 
            while (q.Count() > 0)
            {
                noOfMinutes++;
                int size = q.Count();
                for (int i = 0; i < size; i++)
                {
                    int[] orangeIndex = q.Dequeue();
                    foreach (int[] dir in directions)
                    {
                        int x = orangeIndex[0] + dir[0];
                        int y = orangeIndex[1] + dir[1];

                        if (x < 0 || y < 0 || x >= R || y >= C || grid[x][y] == 0 || grid[x][y] == 2)
                            continue;

                        grid[x][y] = 2;
                        q.Enqueue(new int[] { x, y });
                        freshOranges--;
                    }
                }
            }

            //no of minues -1 is we intially incrementing before traversing in while loop
            //after the whole search there should not be any fresh oranges left, if any still exists so, we cannot visit that place with BFS
            // so return -1
            return freshOranges == 0 ? noOfMinutes - 1 : -1;
        }
    }
}
