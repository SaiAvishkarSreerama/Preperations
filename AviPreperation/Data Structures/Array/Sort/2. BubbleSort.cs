using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array.Sort
{
    // Best Case - Array is already Sorted - Time Complexity O(n)
    // Avg Case - Array is not Sorted - Time Complexity O(n^2) 
    // Worst Case- Array is reverse Sorted Time Complexity O(n^2)
    // Space Complexity - O(1) 

    // Bubble Sorted is repetedly swapping od elements if the order is not ascending

    class BubbleSortSolution
    {
        static int[] BubbleSort(int[] a)
        {
            for(int i=0; i < a.Length; i++)
            {
                for(int j=0; j < a.Length-i-1; j++)
                {
                    if(a[j+1] < a[j])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            return a;
        }

        //static void Main()
        //{
        //    var result = BubbleSort(new int[] { 11, 4, 7, 2, 5, 3, 8 });
        //    for(int i =0; i< result.Length; i++)
        //    {
        //        Console.WriteLine(result[i]);
        //    }
        //    Console.ReadLine();
        //}
    }
}
