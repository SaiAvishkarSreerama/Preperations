using System;
using System.Collections.Generic;
using System.Text;
/*
* Design a Tic-tac-toe game that is played between two players on a n x n grid.
* 
* You may assume the following rules:
* 
* A move is guaranteed to be valid and is placed on an empty block.
* Once a winning condition is reached, no more moves is allowed.
* A player who succeeds in placing n of their marks in a horizontal, vertical, or diagonal row wins the game.
* Example:
* Given n = 3, assume that player 1 is "X" and player 2 is "O" in the board.
* 
* TicTacToe toe = new TicTacToe(3);
* 
* toe.move(0, 0, 1); -> Returns 0 (no one wins)
* |X| | |
* | | | |    // Player 1 makes a move at (0, 0).
* | | | |
* 
* toe.move(0, 2, 2); -> Returns 0 (no one wins)
* |X| |O|
* | | | |    // Player 2 makes a move at (0, 2).
* | | | |
* 
* toe.move(2, 2, 1); -> Returns 0 (no one wins)
* |X| |O|
* | | | |    // Player 1 makes a move at (2, 2).
* | | |X|
* 
* toe.move(1, 1, 2); -> Returns 0 (no one wins)
* |X| |O|
* | |O| |    // Player 2 makes a move at (1, 1).
* | | |X|
* 
* toe.move(2, 0, 1); -> Returns 0 (no one wins)
* |X| |O|
* | |O| |    // Player 1 makes a move at (2, 0).
* |X| |X|
* 
* toe.move(1, 0, 2); -> Returns 0 (no one wins)
* |X| |O|
* |O|O| |    // Player 2 makes a move at (1, 0).
* |X| |X|
* 
* toe.move(2, 1, 1); -> Returns 1 (player 1 wins)
* |X| |O|
* |O|O| |    // Player 1 makes a move at (2, 1).
* |X|X|X|
* Follow up:
* Could you do better than O(n2) per move() operation? 
* */
namespace AviPreperation.Data_Structures.Array._2DArray
{
    //Time Complexity - O(n)
    //Space Complexity - O(n^2)
    public class TicTacToe
    {
        int[,] grid;
        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            grid = new int[n, n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int Move(int row, int col, int player)
        {
            if (row >= grid.GetLength(0) && col >= grid.GetLength(0))
                return 0;
            if (grid[row, col] != 0)
                return 0;
            grid[row, col] = player;

            //vertical
            if (ValidateVertical(col, player))
                return player;

            //horizontal
            if (ValidateHorizontal(row, player))
                return player;

            //diagonal and anti-diagonal
            if (ValidateDiagonals(row, col, player))
                return player;

            return 0;
        }

        public bool ValidateVertical(int col, int player)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                if (grid[i, col] != player)
                    return false;
            return true;
        }

        public bool ValidateHorizontal(int row, int player)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                if (grid[row, i] != player)
                    return false;
            return true;
        }

        public bool ValidateDiagonals(int row, int col, int player)
        {
            //check if is Diagonal or anti-Diagonal
            if (row != col && row + col != grid.GetLength(0) - 1)
                return false;
            bool diagonal = true;
            bool antiDiagonal = true;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, i] != player)
                    diagonal = false;
                if (grid[i, grid.GetLength(0) - 1 - i] != player)
                    antiDiagonal = false;
            }

            return diagonal || antiDiagonal;
        }
    }



    //Time Complexity - O(1)
    //Space Complexity - O(n)
    public class TicTacToe_OrderOfONE
    {
        int[] rows;
        int[] cols;
        int diagonal = 0;
        int antiDiagonal = 0;
        public TicTacToe_OrderOfONE(int n)
        {
            rows = new int[n];
            cols = new int[n];
        }

        public int Move(int row, int col, int player)
        {
            if (row >= rows.Length || col >= cols.Length)
                return 0;
            int toAdd = player == 1 ? 1 : -1;

            rows[row] += toAdd;
            cols[col] += toAdd;
            if (row == col)
                diagonal += toAdd;
            if (row == rows.Length - 1 - col)
                antiDiagonal += toAdd;

            int size = rows.Length;
            if (Math.Abs(rows[row]) == size ||
                Math.Abs(cols[col]) == size ||
                Math.Abs(diagonal) == size ||
                Math.Abs(antiDiagonal) == size)
            {
                return player;
            }

            return 0;
        }
    }
}
