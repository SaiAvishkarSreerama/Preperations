using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array.Sorting
{
    // Time complexity - 0(n^2)
    // Space Complexity - O(1)
    class InsertionSortClas
    {
        static int[] InsertionSort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i];
                int j = i - 1;

                while (j >= 0 && a[j] > temp)
                {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = temp;
            }

            return a;
        }

        //static void Main()
        //{
        //    var result = InsertionSort(new int[] { 11, 4, 7, 2, 5, 3, 8 });
        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        Console.WriteLine(result[i]);
        //    }
        //    Console.ReadLine();
        //}
    }
}
