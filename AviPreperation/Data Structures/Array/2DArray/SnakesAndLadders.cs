using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class SnakesAndLaddersSolution
    {
        //tc- o(n^2)
        //Sc- o(n^2)
        public int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;

            //Doing BFS for each step
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);

            //mark the visited rows for snakes and ladders to avoid the multiple times getting eaten and climbing latteds in a loop
            bool[] visited = new bool[n * n + 1]; // 36 + 1
            visited[1] = true;

            //min step to start
            int steps = 1;

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int k = 0; k < size; k++)
                {
                    int cur = q.Dequeue();
                    //6 is for the dice numbers
                    for (int i = 1; i <= 6; i++)
                    {
                        int next = cur + i;
                        int[] pos = numToPosition(n, next);
                        //which means either ladder or a snake
                        if (board[pos[0]][pos[1]] > 0)
                            next = board[pos[0]][pos[1]];
                        if (next == n * n)
                            return steps;
                        if (!visited[next])
                        {
                            visited[next] = true;
                            q.Enqueue(next);
                        }
                    }
                }
                steps++;
            }
            return -1;
        }

        public int[] numToPosition(int n, int target)
        {
            int oldRow = (target - 1) / n;
            int oldCol = (target - 1) % n;
            int newRow = (n - 1 - oldRow);
            int newCol = (oldRow % 2) == 0 ? oldCol : (n - 1 - oldCol);
            return new int[] { newRow, newCol };
        }
    }
}
