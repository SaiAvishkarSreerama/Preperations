/*
 * Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.
 * A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
 * All the visited cells of the path are 0.
 * All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
 * The length of a clear path is the number of visited cells of this path.
 * Example 1:
 * Input: grid = [[0,1],[1,0]]
 * Output: 2
 * 
 * Example 2:
 * Input: grid = [[0,0,0],[1,1,0],[1,1,0]]
 * Output: 4
 * 
 * Example 3:
 * Input: grid = [[1,0,0],[1,1,0],[1,1,0]]
 * Output: -1
 */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _1091_ShortestPathInBinaryMatrix
    {
        // we need directions to traverse to get the neighbors
        public List<(int, int)> directions = new List<(int, int)> { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        /// <summary>
        /// Using BFS: Algo:
        ///     1. check if start and end cells are 0s only to continue
        ///     2. If grid lenght is 1, return 1
        ///     3. Add grid[0,0] to queue and update the cell value to 1, where we keep the cell distance in grid only
        ///     4. Check for each diorection of the cell and if the neighbor cell is with in the grid and has value 0, then add it to the queue and update the grid cell value to distance+1
        ///     5. for each neighbor we also check if that cell is our target cell, then return distnace 
        ///     
        /// TC - O(N), for nxn grid we have N cells, we travers all cells at once only
        /// SC - O(N), for queue that holds max of nxn cells in worst case
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            // base case: check if start and end cells are '0' or not
            int n = grid[0].Length;
            if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
            {
                return -1;
            }
            if (n == 1)
                return 1;

            //BFS with updating the grid cells with distance
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0)); // first cells
            grid[0][0] = 1; //add distance to first cells

            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                int distance = grid[row][col];

                // check if we are at target cells
                if (row == n - 1 && col == n - 1)
                {
                    return distance;
                }

                //find the neighbors and add them to queue
                foreach (var (r, c) in directions)
                {
                    int newRow = row + r;
                    int newCol = col + c;

                    if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && grid[newRow][newCol] == 0)
                    {
                        queue.Enqueue((newRow, newCol));
                        grid[newRow][newCol] = distance + 1;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Same as above but we are not updating the cells
        /// Alternate, we can maintain additional visited grid to flag the visited cells with true and skip them in our loop
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int ShortestPathBinaryMatrix1(int[][] grid)
        {
            // base case: check if start and end cells are '0' or not
            int n = grid[0].Length;
            if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
            {
                return -1;
            }
            if (n == 1)
                return 1;

            //BFS - without updating the grid but maintianing the distance variable
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0)); // first cells
            int distance = 1;

            while (queue.Count > 0)
            {
                int queueCount = queue.Count; 
                for (int i = 0; i < queueCount; i++) // additional for loop for traversing same distance cells from queue at single iteration code
                {
                    var (row, col) = queue.Dequeue();
                    // int distance = grid[row][col];

                    // check if we are at target cells
                    if (row == n - 1 && col == n - 1)
                    {
                        return distance;
                    }

                    //find the neighbors and add them to queue
                    foreach (var (r, c) in directions)
                    {
                        int newRow = row + r;
                        int newCol = col + c;

                        if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && grid[newRow][newCol] == 0)
                        {
                            queue.Enqueue((newRow, newCol));
                            grid[newRow][newCol] = distance + 1;
                        }
                    }
                }
                distance++; // the above for loop process all cells of same distance and enqueues next distance cells, increment the distnace
            }

            return -1;
        }
    }
}
