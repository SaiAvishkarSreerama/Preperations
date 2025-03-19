/*
    * 1. Bubble sort is done in in-place sorting, where it utilise the same array to sort the items
    * 2. Time Complexity:
    *       Best: O(n2)
    *       Average: O(n2)
    *       Worst: O(n2)
    * 3. Space Complexity - O(1)
    * Explanation: In Bubble sort, sorting is done by comparing and swapping two consecutive numbers till the array is sorted.
    * Note: 
    *      1. n is the length of an array arr: 7
    *      2. i lies between [0 to n-1)
    *      3. j lies between [0 to n-(i+1)), as for last i, j still need to perform sorting on last two numbers.
    * 
    */
namespace PreperationsTest.Algorithms.Sorting
{
    [TestClass]
    public class BubbleSort
    {
        /// <summary>
        /// Sorting in Ascending order
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort_Ascending_Impl(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - (i + 1); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Sorting in Descending order
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort_Descending_Impl(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - (i + 1); j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        [TestMethod]
        public void BubbleSortExample()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

            // Sort the array in ascending order
            BubbleSort_Ascending_Impl(arr);
            foreach (int n in arr)
            {
                Console.WriteLine(n);
            }

            // Sort the array in descending order
            BubbleSort_Descending_Impl(arr);
            foreach (int n in arr)
            {
                Console.WriteLine(n);
            }
        }
    }
}
