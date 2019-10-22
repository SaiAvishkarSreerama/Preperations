using System;
using System.Collections.Generic;
using System.Text;

// Selection Sort
// Bubble Sort
// Insertion Sort
// Merge Sort
// Heap Sort
// QuickSort
// Radix Sort
// Counting Sort
// Bucket Sort
// ShellSort

//Time Complexities of all Sorting Algorithms

//                  Best            Average             Worst
//Selection Sort    Ω(n^2)          θ(n^2)              O(n^2)
//Bubble Sort       Ω(n)            θ(n^2)              O(n^2)
//Insertion Sort    Ω(n)            θ(n^2)              O(n^2)
//Heap Sort         Ω(n log(n))     θ(n log(n))         O(n log(n))
//Quick Sort        Ω(n log(n))     θ(n log(n))         O(n^2)
//Merge Sort        Ω(n log(n))     θ(n log(n))         O(n log(n))
//Bucket Sort       Ω(n+k)          θ(n+k)              O(n^2)
//Radix Sort        Ω(nk)           θ(nk)               O(nk)
namespace AviPreperation.Data_Structures.Array.Sort
{
    // Time Complextiy O(n^2)
    // Space Complexity O(1)
    // Explanation: Looping array and finding out smallest element of the array for each iteration, once the smallest(j) array found swapping the ele
    // with the i index position and continuing till the last element
    public class SelectionSortSolution
    {
        static int[] SelectionSort(int[] a)
        {
            for(int i = 0; i <= a.Length-1; i++)
            {
                int small = i;
                for(int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[small])
                        small = j;
                }
                //swapping the i index element with the smallest "index"
                int temp = a[i];
                a[i] = a[small];
                a[small] = temp;
                Console.WriteLine(a[i]);
            }
            return a;
        }

        //static void Main()
        //{
        //    Console.WriteLine(SelectionSort(new int[] { 1, 4, 7, 2, 5, 3, 8 }));
        //    Console.ReadLine();
        //}
    }

}
