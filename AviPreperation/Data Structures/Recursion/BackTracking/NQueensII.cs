using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    public class NQueensIISolution
    {
        int result = 0;
        public int TotalNQueens(int n)
        {
            NewSolveNQueens(n, 0, new List<int>());
            return result;
        }

        public void NewSolveNQueens(int n, int row, List<int> colPlacements)
        {
            if (row == n)
            {
                //base case
                result++;
            }
            //else
            for (int col = 0; col < n; col++)
            {
                colPlacements.Add(col);
                if (IsValid(colPlacements))
                {
                    NewSolveNQueens(n, row + 1, colPlacements);
                }
                colPlacements.RemoveAt(colPlacements.Count() - 1);// way to remove a last value from the List
            }
        }


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
    }
}
