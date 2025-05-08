/*
 * Write a program to solve a Sudoku puzzle by filling the empty cells.
 * A sudoku solution must satisfy all of the following rules:
 * 
 * Each of the digits 1-9 must occur exactly once in each row.
 * Each of the digits 1-9 must occur exactly once in each column.
 * Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
 * The '.' character indicates empty cells.
 * 
 * TC O(9^(n×n)) => O(9^81),- Backtracking always takes exponential time
 * SC - O(nxn) => O(81)
 **/

namespace PreperationsTest.LeetCode.Hard.Arrays
{
    [TestClass]
    public class _37_SudokuSolver
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

            // Known solution
            SolveSudoku(board);

            //Co-pilot 
            SolveSudoku_CoPilot(board);
        }

        #region Known Solution
        public void SolveSudoku(char[][] board)
        {
            Backtrack(board, 0, 0);
        }

        public bool Backtrack(char[][] board, int r, int c)
        {
            //base case
            // when at last col, move to next row from col-0
            // if row is last, means we covered all and return the sol 
            if (c == board.Length)
            {
                c = 0;
                r++;
                if (r == board.Length)
                {
                    return true;
                }
            }

            // conditon: work on only empty cells '.', if num move to next cell 
            if (board[r][c] != '.')
            {
                return Backtrack(board, r, c + 1);
            }

            // Decision making
            // put 1-9 in cell and cehck if our decision is right, if not move back and chage our past decision
            for (int i = 1; i <= board.Length; i++)
            {
                // since cell are char type, convert the numb to char
                char decisionNum = (char)(i + '0');
                if (isDecisionValid(board, r, c, decisionNum))
                {
                    board[r][c] = decisionNum;
                    //if valid, move to next cell
                    if (Backtrack(board, r, c + 1))
                    {
                        return true;
                    }
                    ;
                    // if decision is valid but next cell fails with our curr decision, we get here with above if(backtrack) condition fails
                    // revert the cell value to '.' and move to next iteration
                    board[r][c] = '.';
                }
            }

            // if we cannot put 1-9 in the cell means the previous cell decision has to change
            // retruning false will go to the recusion where we are here and continue iteration with next number(1-9)
            return false;
        }

        public bool isDecisionValid(char[][] board, int r, int c, char decisionNum)
        {
            // check if the decisionNum in row and col
            for (int i = 0; i < board.Length; i++)
            {
                if (board[r][i] == decisionNum || board[i][c] == decisionNum)
                {
                    return false;
                }
            }

            // check in the box region (3x3, if given 9x9 board)
            int region = (int)Math.Sqrt(board.Length);
            int r1 = r / region;
            int c1 = c / region;
            // now we have box region number for r and c, let say it is region 4, we need to start from first cell of region4
            int firstRowcellofRegion4 = r1 * region;
            int firstColcellofRegion4 = c1 * region;
            for (int i = 0; i < region; i++)
            {
                for (int j = 0; j < region; j++)
                {
                    if (board[firstRowcellofRegion4 + i][firstColcellofRegion4 + j] == decisionNum)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region Copilot Solution

        public void SolveSudoku_CoPilot(char[][] board)
        {
            Solve(board);
        }

        // Recursive method to solve the Sudoku puzzle using backtracking
        private bool Solve(char[][] board)
        {
            // Iterate through each cell in the board
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    // If the cell is empty ('.'), try to place numbers '1' to '9'
                    if (board[row][col] == '.')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            // Check if placing the number is valid
                            if (IsValid(board, row, col, num))
                            {
                                // Place the number in the cell
                                board[row][col] = num;

                                // Recursively try to solve the rest of the board
                                if (Solve(board))
                                {
                                    return true;
                                }

                                // If placing the number doesn't lead to a solution, revert the cell to empty
                                board[row][col] = '.';
                            }
                        }

                        // If no number from '1' to '9' can be placed in the cell, return false
                        return false;
                    }
                }
            }

            // If all cells are filled correctly, return true
            return true;
        }

        // Method to check if placing a number in a specific cell is valid
        private bool IsValid(char[][] board, int row, int col, char num)
        {
            // Check if the number already exists in the current row or column
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == num || board[i][col] == num ||
                board[row / 3 * 3 + i / 3][col / 3 * 3 + i % 3] == num)
                {
                    return false;
                }
            }

            // If the number doesn't exist in the row, column, or 3x3 sub-grid, return true
            return true;
        }

        #endregion
    }
}
