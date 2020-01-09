using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class SetMatrixZeroes
    {
        //Approach1: using extra space
        //Time Complexity - O(m*n)
        //SpaceComplexity - O(m+n)
        public void SetZeroes(int[][] matrix)
        {
            int R = matrix.Length;
            int C = matrix[0].Length;
            HashSet<int> row = new HashSet<int>();
            HashSet<int> col = new HashSet<int>();

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row.Add(i);
                        col.Add(j);
                    }
                }
            }

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (row.Contains(i) || col.Contains(j))
                        matrix[i][j] = 0;
                }
            }
        }


        //Approach2: BRUTE FORCE
        //Time Complexity - O((m*n) * (m+n))
        //SpaceComplexity - O(1)
        public void SetZeroes1(int[][] matrix)
        {
            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (matrix[r][c] == 0)
                    {

                        //iterate ans update the row
                        for (int k = 0; k < R; k++)
                        {
                            if (matrix[k][c] != 0)
                                matrix[k][c] = -1000000;
                        }


                        //iterate ans update the column
                        for (int k = 0; k < C; k++)
                        {
                            if (matrix[r][k] != 0)
                                matrix[r][k] = -1000000;
                        }
                    }
                }
            }

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (matrix[i][j] == -1000000)
                        matrix[i][j] = 0;
                }
            }
        }

        //Approach3: BRUTE FORCE
        //Time Complexity - O((m*n))
        //SpaceComplexity - O(1)
        public void SetZeroes2(int[][] matrix)
        {
            /*
               1. note if any cell on col0 is zero make a flag isCol=true
               2. iterate all and make row0 and col0 of that cell to 0s if cell is 0, start from r=c=1
               3. if matrix[0][0] ==0 make the first row 0
               4. if isCol=true then make first column 0
            */

            bool isCol = false;
            int R = matrix.Length;
            int C = matrix[0].Length;

            //step1: 
            for (int r = 0; r < R; r++)
            {
                if (matrix[r][0] == 0)
                    isCol = true;
                for (int c = 1; c < C; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        matrix[r][0] = 0;
                        matrix[0][c] = 0;
                    }
                }
            }

            //Step2:
            for (int r = 1; r < R; r++)
            {
                for (int c = 1; c < C; c++)
                {
                    if (matrix[r][0] == 0 || matrix[0][c] == 0)
                    {
                        matrix[r][c] = 0;
                    }
                }
            }

            //step3: first row
            if (matrix[0][0] == 0)
            {
                for (int c = 0; c < C; c++)
                    matrix[0][c] = 0;
            }

            if (isCol)
            {
                for (int r = 0; r < R; r++)
                    matrix[r][0] = 0;
            }

        }
    }
}
