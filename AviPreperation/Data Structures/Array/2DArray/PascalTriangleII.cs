using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array._2DArray
{
    public class PascalTriangle2Solution
    {
        //Time Complexity - O(k^2)
        //Space Complexity - O(k), space used to handle k+1 elements(k=3, out put is 4elements)
        public IList<int> GetRow(int k)
        {
            List<int> row = new List<int>();
            row.Add(1);

            if (k == 0)
                return row;
            //Here, we are operating on singlr row
            //starting with row=[1]
            //i=1; j=0(no execution); add[1] ==> row=[1,1]
            //i=2; j=1(row[1]=row[i]+row[0]); add[1] ==> row = [1,2,1]
            //i=3; j=2(row2) and j=1(row1); add[1] ==> row = [1,3,3,1]
            //i=4; 4>k; breaks and return row
            for (int i = 1; i <= k; i++)
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
