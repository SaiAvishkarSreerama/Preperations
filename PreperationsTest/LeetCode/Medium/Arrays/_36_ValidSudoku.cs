/*
 * Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
 * Each row must contain the digits 1-9 without repetition.
 * Each column must contain the digits 1-9 without repetition.
 * Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
 * Note:
 * A Sudoku board (partially filled) could be valid but is not necessarily solvable.
 * Only the filled cells need to be validated according to the mentioned rules.
 */

using System.Data.Common;
using System;

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _36_ValidSudoku
    {
        [TestMethod]
        public void Run()
        {
            char[][] board =
            {
                 ['5','3','.','.','7','.','.','.','.'],
                 ['6','.','.','1','9','5','.','.','.'],
                 ['.','9','8','.','.','.','.','6','.'],
                 ['8','.','.','.','6','.','.','.','3'],
                 ['4','.','.','8','.','3','.','.','1'],
                 ['7','.','.','.','2','.','.','.','6'],
                 ['.','6','.','.','.','.','2','8','.'],
                 ['.','.','.','4','1','9','.','.','5'],
                 ['.','.','.','.','8','.','.','7','9']
            };

            IsValidSudoku(board);
            IsValidSudoku_LC(board);
        }

        #region MySolution - Validation each box
        /// <summary>
        /// TC - O(1), FOR LOOPS Iterations are fixed to 9cells, which is constant
        /// SC - O(1)
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku(char[][] board)
        {
            if (board == null)
            {
                return true;
            }

            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board.Length; c++)
                {
                    if (board[r][c] == '.')
                    {
                        continue;
                    }
                    else if (!ValidateSudokuNum(board, r, c))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool ValidateSudokuNum(char[][] board, int r, int c)
        {
            // validate the num exists in row/column
            for (int i = 0; i < 9; i++)
            {
                if ((i != c && board[r][i] == board[r][c]) || (i != r && board[i][c] == board[r][c]))
                {
                    return false;
                }
            }

            // validate in the 3x3 box
            int startR_Index = r - (r % 3);
            int startC_Index = c - (c % 3);
            for (int i = startR_Index; i < startR_Index + 3; i++)
            {
                for (int j = startC_Index; j < startC_Index + 3; j++)
                {
                    if (i != r && j != c && board[i][j] != '.' && board[i][j] == board[r][c])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region LC solution
        /// <summary>
        /// Let's say r = 5 and c = 7:
        /// Row index calculation:
        /// r / 3 = 5 / 3 = 1 (integer division)
        /// This means the cell is in the second row of 3x3 boxes.
        /// Column index calculation:
        /// c / 3 = 7 / 3 = 2 (integer division)
        /// This means the cell is in the third column of 3x3 boxes.
        /// Combine row and column indices:
        /// boxIndex = (1 * 3) + 2 = 3 + 2 = 5
        /// The cell at (5, 7) is in the 3x3 box indexed at 5.
        /// 
        /// TC - O(1), ITerating till r=9 and c=9, means total 81 iterations at max, constant
        /// SC - O(1), fixed lenght of hashsets
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool IsValidSudoku_LC(char[][] board)
        {
            HashSet<char>[] row = new HashSet<char>[9];
            HashSet<char>[] col = new HashSet<char>[9];
            HashSet<char>[] box = new HashSet<char>[9];

            for (int i = 0; i < 9; i++)
            {
                row[i] = new HashSet<char>();
                col[i] = new HashSet<char>();
                box[i] = new HashSet<char>();
            }

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[r][c] == '.')
                    {
                        continue;
                    }
                    char value = board[r][c];
                    int boxIndex = (r / 3) * 3 + (c / 3);

                    if (row[r].Contains(value) || col[c].Contains(value) || box[boxIndex].Contains(value))
                    {
                        return false;
                    }

                    row[r].Add(value);
                    col[c].Add(value);
                    box[boxIndex].Add(value);
                }
            }

            return true;
        }
        #endregion
    }
}
