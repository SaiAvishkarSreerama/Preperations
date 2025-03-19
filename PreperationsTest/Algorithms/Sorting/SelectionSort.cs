/*
    * 1. Selection sort is done in in-place sorting, where it utilise the same array to sort the items
    * 2. Time Complexity:
    *       Best: O(n2)
    *       Average: O(n2)
    *       Worst: O(n2)
    * 3. Space Complexity - O(1)
    * Explanation: In Selection sort, sorting is done by finding the largest or smallest number and replacing it with the first dedicated spot, recursively do the same for second spot ect 
    *              until the array is sorted.
    * Note: 
    *      1. n is the length of an array arr: 7
    *      2. i lies between [0 to n-1)
    *      3. j lies between [0 to n), as for last i, j still need to perform finding the large or small number till the array ends
    * 
    */
namespace PreperationsTest.Algorithms.Sorting
{
    [TestClass]
    public class SelectionSort
    {
        [TestMethod]
        public void SelectionSortExample()
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90, 120, 1, 223, 4, 6, 89};

            SelectionSort_Ascending_Impl(arr);

            SelectionSort_Descending_Impl(arr);

        }

        /// <summary>
        /// Selection sort in ascending order
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SelectionSort_Ascending_Impl(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_index = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[min_index])
                    {
                        min_index = j;
                    }
                }

                //swap 
                // I Added this condiditon, as when current i becomes the min_index, swapping doesn't makes sense.
                if (i != min_index)
                {
                    int temp = arr[i];
                    arr[i] = arr[min_index];
                    arr[min_index] = temp;
                }
            }

            return arr;
        }

        /// <summary>
        /// Selection sort in descending order
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SelectionSort_Descending_Impl(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int max_index = i; //finding a max number
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] > arr[max_index])
                    {
                        max_index = j;
                    }
                }

                //swap 
                // I Added this condiditon, as when current i becomes the max_index, swapping doesn't makes sense.
                if (i != max_index)
                {
                    int temp = arr[i];
                    arr[i] = arr[max_index];
                    arr[max_index] = temp;
                }
            }

            return arr;
        }
    }
}
