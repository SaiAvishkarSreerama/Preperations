using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
* The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
* Given an integer n, return all distinct solutions to the n-queens puzzle.
* Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both 
* indicate a queen and an empty space respectively.
* 
* Example:
* Input: 4
* Output: [
*  [".Q..",  // Solution 1
*   "...Q",
*   "Q...",
*   "..Q."],
* 
*  ["..Q.",  // Solution 2
*   "Q...",
*   "...Q",
*   ".Q.."]
* ]
* 
* Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above.
* * */
namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    //TimeComplexity = O(N!)
    //spaceComplexity - O(N)
    //https://www.youtube.com/watch?v=wGbuCyNpxIg
    public class NQueensSolution
    {
        //We are sending the n, row=0, new list for columpositions, result;
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> result = new List<IList<string>>();
            NewSolveNQueens(n, 0, new List<int>(), result);
            return result;
        }

        //For Col=0: Intially row=0; for n; col increments from 0 to n and check each position of column by considering 
        //as Queen placed and validating the position is under attack of any other queen or not, if under-attack
        //removes the col position and increment the col, again check untill it is not under attack position and
        //once the col position found, no need to check other columns of that row, increment the row and recurse the same
        //If no such position found, the for loop completes by removing the last inserted value and return to back recursive
        //and clears all values, and go for col=1
        public void NewSolveNQueens(int n, int row, List<int> colPlacements, List<IList<string>> result)
        {
            if (row == n)
            {
                //base case
                result.Add(GenerateQueensBoard(colPlacements, n));
            }
            //else
            for (int col = 0; col < n; col++)
            {
                colPlacements.Add(col);
                if (IsValid(colPlacements))
                {
                    NewSolveNQueens(n, row + 1, colPlacements, result);
                }
                colPlacements.RemoveAt(colPlacements.Count() - 1);
            }
        }

        //valid position is checked by 
        //distance between columns whcih have Q == 0 means in same column
        //distance between rows == distance between columns, means in a square matrix position, so diagonally meeting
        public bool IsValid(List<int> colPlacements)
        {
            int rowValidatingOn = colPlacements.Count() - 1;
            for (int oldRow = 0; oldRow < rowValidatingOn; oldRow++)
            {
                //absolute column distance
                int absColumnDistance = Math.Abs(colPlacements[rowValidatingOn] - colPlacements[oldRow]);
                //row distance
                int rowDistance = rowValidatingOn - oldRow;

                if (rowDistance == absColumnDistance || absColumnDistance == 0)
                    return false;
            }
            return true;
        }

        //finally our found result pattern is generated and return to the result.
        public List<string> GenerateQueensBoard(List<int> colPlacements, int n)
        {
            List<string> pattern = new List<string>();
            for (int i = 0; i < colPlacements.Count(); i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (j == colPlacements[i])
                    {
                        sb.Append('Q');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                pattern.Add(sb.ToString());
            }
            return pattern;
        }

    }
}
