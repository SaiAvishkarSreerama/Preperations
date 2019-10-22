using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array.Sort
{
    class QuickSortSol
    {
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);

                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        static int partition(int[] arr, int low, int high)
        {
            int pi = arr[high];
            int i = low - 1;

            for (int j = low; j <= high; j++)
            {
                if (arr[j] < pi)
                {
                    i++;
                    swap(arr, i, j);
                }
            }

            swap(arr, i + 1, high);
            return i + 1;

        }

        static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        //static void Main()
        //{
        //    int[] arr = new int[] { 10, 80, 30, 90, 40, 50, 70 };
        //    QuickSort(arr, 0, arr.Length-1);

        //    for(int i=0; i<arr.Length; i++)
        //    {
        //        Console.WriteLine(arr[i]);
        //    }
        //    Console.ReadLine();
        //}
    }
}
