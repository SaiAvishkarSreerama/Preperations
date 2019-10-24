using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class PascalTriangle2Solution
    {
        //TimeComplexity = O(numRows^2)
        //SpaceComplexity = O(numRows^2)
        public IList<int> GeneratePascalTriangle2(int rowIndex)
        {
            List<int> row = new List<int>();
            row.Add(1);

            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    row[j] = row[j - 1] + row[j];
                }

                row.Add(1);
            }
            return row;
        }
    }
    public class PASCALTriangle
    {
        //static void Main()
        //{
        //    var pIndex = new PascalTriangle2Solution();
        //    Console.WriteLine(pIndex.GeneratePascalTriangle2(3));
        //    Console.ReadLine();
        //}
    }
}
