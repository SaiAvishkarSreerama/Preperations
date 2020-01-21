using System;
using System.Collections.Generic;
using System.Text;
/*Given a 2D board and a word, find if the word exists in the grid.
* 
* The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.
* 
* Example:
* board =
* [
*   ['A','B','C','E'],
*   ['S','F','C','S'],
*   ['A','D','E','E']
* ]
* 
* Given word = "ABCCED", return true.
* Given word = "SEE", return true.
* Given word = "ABCB", return false.
*/
namespace AviPreperation.Data_Structures.Array._2DArray
{
    
    public class WordSearchSolution
    {
       
        //Using DFS backtracking
        //TC - O(m*n*l), m*n board, l-length of word
        //SC - O(m*n*l), m*n board, l-length of word
        public bool Exist(char[][] board, string word)
        {
            int R = board.Length;
            int C = board[0].Length;
            bool[,] visited = new bool[R, C];

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (board[r][c] == word[0])
                    {
                        if (Dfs(board, word, visited, r, c, 0))
                            return true;
                    }
                }
            }
            return false;
        }

        public bool Dfs(char[][] board, string word, bool[,] visited, int r, int c, int i)
        {
            if (i == word.Length)
                return true;

            if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] != word[i] || visited[r, c])
                return false;

            visited[r, c] = true;

            if (Dfs(board, word, visited, r + 1, c, i + 1) ||
               Dfs(board, word, visited, r - 1, c, i + 1) ||
               Dfs(board, word, visited, r, c + 1, i + 1) ||
               Dfs(board, word, visited, r, c - 1, i + 1))
                return true;

            visited[r, c] = false;
            return false;


        }
    }
}
