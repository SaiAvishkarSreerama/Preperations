using System;
using System.Collections.Generic;
using System.Text;

//TimeComplexity - O(N^2), n is numRows, for each row it iterates n times hence 1+2+3+4+....ntime which is sum of natural numbers, n(n+1)/2 ==> (n^2+n)/2 ==> O(n^2)
//Space Complexity - O(n^2),n is numRows, Because we need to store each number that we update in triangle, the space requirement is the same as the time complexity.

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class Solution
    {
        //TimeComplexity = O(numRows^2)
        //SpaceComplexity = O(numRows^2)
        public IList<IList<int>> GeneratePascalTriangle(int numRows)
        {
            //Declaring output list
            List<IList<int>> triangle = new List<IList<int>>();

            //if numRows is 0
            if (numRows == 0)
                return triangle;

            //First row of Pascal triangle is always 0
            triangle.Add(new List<int>() { 1 });

            //For remaining rows
            for (int r = 1; r < numRows; r++)
            {
                var row = new List<int>();
                var prevRow = triangle[r - 1];

                //first element always 1
                row.Add(1);

                //for middle elements
                for (int j = 1; j < r; j++)
                {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                }
                //Last element alwasy 1
                row.Add(1);

                triangle.Add(row);
            }
            return triangle;
        }

        //using while loop
        public IList<IList<int>> Generate(int numRows)
        {
            //Declaring output list
            List<IList<int>> triangle = new List<IList<int>>();

            //if numRows is 0
            if (numRows == 0)
                return triangle;

            //First row of Pascal triangle is always 0
            triangle.Add(new List<int>() { 1 });

            numRows--;
            while (numRows > 0)
            {
                List<int> row = new List<int>();
                IList<int> prev = triangle[triangle.Count - 1];

                row.Add(1);

                for (int j = 1; j < prev.Count; j++)
                {
                    row.Add(prev[j - 1] + prev[j]);
                }

                row.Add(1);

                numRows--;

                triangle.Add(row);
            }
            return triangle;
        }
    }
}
    public class PASCAL
    {
        //static void Main()
        //{
        //    var pIndex = new Solution();
        //    Console.WriteLine(pIndex.GeneratePascalTriangle(5));
        //    Console.ReadLine();
        //}
    }
//}
