using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    /**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */
    interface Robot
    {
        // returns true if next cell is open and robot moves into the cell.
        // returns false if next cell is obstacle and robot stays on the current cell.
        bool Move();

        // Robot will stay on the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        void TurnLeft();
        void TurnRight();

        // Clean the current cell.
        void Clean();
    }

    //USING DFS-BACK TRACKING
    class RobotRoomCleanSol
    {
        //https://www.youtube.com/watch?v=VQp7pfij7_Qxx
        // Time complexity : O(4 ^ (N−M)), where NN is a number of cells in the room and MM is a number of obstacles, because for each cell the algorithm checks 4 directions.
        // Space complexity : O(N−M), where NN is a number of cells in the room and MM is a number of obstacles, to track visited cells.
        public void CleanRoom(Robot robot)
        {
            //dfs(int x, int y, int directions, Robot robot, hashset)
            DFS1(0, 0, 0, robot, new HashSet<string>());
        }

        public void DFS1(int x, int y, int dir, Robot robot, HashSet<string> h)
        {
            string path = x + "_" + y;
            if (h.Contains(path))
                return;
            robot.Clean();
            h.Add(path);
            for (int i = 0; i < 4; i++)
            {
                if (robot.Move())
                {
                    //find the x, y path of next cell based on current direction
                    int nx = x;
                    int ny = y;
                    switch (dir)
                    {
                        case 0:
                            ny -= 1;
                            break;
                        case 90:
                            nx += 1;
                            break;
                        case 180:
                            ny += 1;
                            break;
                        case 270:
                            nx -= 1;
                            break;
                    }
                    DFS1(nx, ny, dir, robot, h);
                    robot.TurnLeft();
                    robot.TurnLeft();
                    robot.Move();
                    robot.TurnRight();
                    robot.TurnRight();

                }
                dir += 90;
                robot.TurnRight();
                dir %= 360;
            }
        }

        //BACK TRACKING USING DFS
        int[,] cardDir = {{ 0,1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        public void DFS2(int x, int y, int dir, Robot robot, HashSet<string> h)
        {
            string path = x + "_" + y;
            if (h.Contains(path))
                return;
            robot.Clean();
            h.Add(path);
            for (int i = 0; i < 4; i++)
            {
                if (robot.Move())
                {
                    //find the x, y path of next cell based on current direction
                    int nx = x + cardDir[dir, 0];
                    int ny = y + cardDir[dir, 0];
                   
                    DFS2(nx, ny, dir, robot, h);
                    robot.TurnLeft();
                    robot.TurnLeft();
                    robot.Move();
                    robot.TurnRight();
                    robot.TurnRight();

                }
                dir += 1;
                robot.TurnRight();
                dir %= 4;
            }
        }
    }
}
