using System;
using System.Collections.Generic;
using System.Text;

/*A Tic-Tac-Toe board is given as a string array board. Return True if and only if it is possible to reach this board position during the course of a valid tic-tac-toe game.
* The board is a 3 x 3 array, and consists of characters " ", "X", and "O".  The " " character represents an empty square.
* Here are the rules of Tic-Tac-Toe:
* 
* Players take turns placing characters into empty squares (" ").
* The first player always places "X" characters, while the second player always places "O" characters.
* "X" and "O" characters are always placed into empty squares, never filled ones.
* The game ends when there are 3 of the same (non-empty) character filling any row, column, or diagonal.
* The game also ends if all squares are non-empty.
* No more moves can be played if the game is over.
* 
* Example 1:
* Input: board = ["O  ", "   ", "   "]
* Output: false
* Explanation: The first player always plays "X".
* 
* Example 2:
* Input: board = ["XOX", " X ", "   "]
* Output: false
* Explanation: Players take turns making moves.
* 
* Example 3:
* Input: board = ["XXX", "   ", "OOO"]
* Output: false
* 
* Example 4:
* Input: board = ["XOX", "O O", "XOX"]
* Output: true
* Note:
* 
* board is a length-3 array of strings, where each string board[i] has length 3.
* Each board[i][j] is a character in the set {" ", "X", "O"}.
* */
namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class ValidTicTacToeMovesSolution
    {
        //since the tic tac toe grid is 3*3 which is constant
        //Time complexity - O(1)
        //Space Complexity - O(1)
        public bool ValidTicTacToe(string[] board)
        {
            int xCount = 0;
            int oCount = 0;
            int n = board.Length;

            //count X and O
            foreach (string row in board)
            {
                foreach (char c in row)
                {
                    if (c == 'X')
                        xCount++;
                    else if (c == 'O')
                        oCount++;
                }
            }

            //case 1: if x!=o in this case x should be higher than o by 1, as x is player 1
            if (oCount != xCount && xCount - 1 != oCount)
                return false;

            //check if player wins and the other player condition

            //if x won, then o should be less by 1
            if (Win(board, 'X') && xCount - 1 != oCount)
                return false;

            //if o won, then x should be equal moves
            if (Win(board, 'O') && xCount != oCount)
                return false;

            return true;
        }

        public bool Win(string[] b, char p)
        {
            for (int i = 0; i < b.Length; i++)
            {
                //check row
                if (b[i][0] == p && b[i][1] == p && b[i][2] == p) return true;
                //check column
                if (b[0][i] == p && b[1][i] == p && b[2][i] == p) return true;
            }

            //check digonal
            if (b[0][0] == p && b[1][1] == p && b[2][2] == p) return true;
            //check anti-diagonal
            if (b[0][2] == p && b[1][1] == p && b[2][0] == p) return true;

            return false;
        }
    }
}
