using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array.Sorting
{
    //Time Complexity - O(n logn)
    //Space Complexity - O(n) - uses L and R of n/2 size temp arrays
    public class MergeSortClass
    {
        public static void MergeSort(int[] arr, int l, int h)
        {
            if(l < h)
            {
                int m = l + (h - l)/2;
                //Left half
                MergeSort(arr, l, m);
                //Right half
                MergeSort(arr, m + 1, h);
                //Merge two halves
                Merge(arr, l, m, h);
            }
        }

        public static void Merge(int[] arr, int l, int m, int h)
        {
            //new arrays lengths
            int n1 = m - l + 1;
            int n2 = h - m;
            int k, j, i;
            //new arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            //Loading arrays
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1 + j];

            //Merging
            k = l;
            i = 0;
            j = 0;
            while(i < n1 && j < n2)
            {
                if (L[i] < R[j])
                    arr[k++] = L[i++];
                else
                    arr[k++] = R[j++];
            }

            while (i < n1)
                arr[k++] = L[i++];
            while (j < n2)
                arr[k++] = R[j++];
        }

        //static void Main()
        //{
        //    int[] array = new int[] { 5, 2, 3, 1, 4, 6, 7, 8, 9, 10, 12, 13, 48, 16, 77, 23, 99, 78};
        //    MergeSort(array, 0, array.Length-1);
        //    for(int i = 0; i<array.Length; i++)
        //    {
        //        Console.WriteLine(array[i]);
        //    }
        //    Console.ReadLine();
        //}
    }
}
