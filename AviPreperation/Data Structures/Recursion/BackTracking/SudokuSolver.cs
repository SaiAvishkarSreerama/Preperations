
using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    //TimeComplexity - O(9!^9)
    //SpaceComplexity - O(81)

    /*Time complexity is constant here since the board size is fixed and there is no N-parameter to measure. 
     * Though let's discuss the number of operations needed : (9!)^9. Let's consider one row, i.e. not more 
     * than 99 cells to fill. There are not more than 99 possibilities for the first number to put, not more 
     * than 9 \times 89×8 for the second one, not more than 9 \times 8 \times 79×8×7 for the third one etc. 
     * In total that results in not more than 9!9! possibilities for a just one row, that means not more than (9!)^9
     * operations in total. 
     * 
     * Space complexity : the board size is fixed, and the space is used to store board, rows, columns and boxes structures, 
     * each contains 81 elements.*/
    public class SudokuSolverSolution
    {
        public void SolveSudoku(char[][] board)
        {
            CanSolveSudokuByCell(board, 0, 0);
        }

        public bool CanSolveSudokuByCell(char[][] board, int row, int col)
        {
            //If col is last box then goto next row, and start col from 0
            //Also, if row is lenght of board, means we are done with rows, return true;
            if (col == board[row].Length)
            {
                col = 0;
                row++;
                if (row == board.Length)
                    return true;
            }

            //skip the boxes with values
            if (board[row][col] != '.')
            {
                return CanSolveSudokuByCell(board, row, col + 1);
            }

            //for each number from 1-9(length of board 9x9), check each char is valid or not
            //we were given with char[][] of character type, so converting numer into char.
            for (int val = 1; val <= board.Length; val++)
            {
                char charToPlace = (char)(val + '0');

                if (charIsValid(board, row, col, charToPlace))
                {
                    board[row][col] = charToPlace;
                    if (CanSolveSudokuByCell(board, row, col + 1))
                    {
                        return true;
                    }
                    board[row][col] = '.';
                }
            }
            return false;
        }

        public bool charIsValid(char[][] board, int row, int col, char charToPlace)
        {
            //verify the row and column
            foreach (char[] t in board)
            {
                if (t[col] == charToPlace)
                    return false;
            }

            for (int i = 0; i < board[row].Length; i++)
            {
                if (board[row][i] == charToPlace)
                    return false;
            }

            //verify the boxRegion
            int region = (int)Math.Sqrt(board.Length);
            int verticalIndex = row / region;
            int horizontalIndex = col / region;

            int topLeftBoxRow = verticalIndex * region;
            int topLeftBoxCol = horizontalIndex * region;

            for (int i = 0; i < region; i++)
            {
                for (int j = 0; j < region; j++)
                {
                    if (charToPlace == board[topLeftBoxRow + i][topLeftBoxCol + j])
                        return false;
                }
            }

            return true;
        }
    }
}
