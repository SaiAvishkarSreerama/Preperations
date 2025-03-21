/*
 * Best Case: (Ω(n log n)), Occurs when the pivot element divides the array into two equal halves.
 * Average Case (θ(n log n)), On average, the pivot divides the array into two parts, but not necessarily equal.
 * Worst Case: (O(n²)), Occurs when the smallest or largest element is always chosen as the pivot (e.g., sorted arrays).
 *
 */

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class QuickSort
    {

        [TestMethod]
        public void QuickSort_Test()
        {
            int[] arr = { 10, 7, 11, 9, 17, 5, 15, 1, 16, 12, 8 };
            int n = arr.Length;

            // When pivotal value is low
            //QuickSortImpl_low(arr, 0, n - 1);

            // When pivotal vlaue is mid
            //QuickSortImpl_mid(arr, 0, n - 1);

            // When pivotal value is high
            QuickSortImpl_high(arr, 0, n - 1);

        }

        #region Low value as pivot
        public void QuickSortImpl_low(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int pivotalIndex = Partition_low(arr, l, h);

                // Quick sort '0' to 'pivot-1'
                QuickSortImpl_low(arr, l, pivotalIndex - 1);

                // Quick sort ,pivot+1' to 'n'
                QuickSortImpl_low(arr, pivotalIndex + 1, h);
            }
        }

        /// <summary>
        /// Case 1: Pivotal value is takes as low
        /// Pivotal = arr[0]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public int Partition_low(int[] arr, int l, int h)
        {
            int i = l;
            int j = h;

            int pivotValue = arr[l]; //pivotal value is at index 0

            while (i < j)
            {
                while (i <= j && arr[i] <= pivotValue) // increment i till i value > pivot
                    i++;
                while (i <= j && arr[j] > pivotValue) // decrement j till j value < pivot
                    j--;
                if (i <= j)
                {
                    Swap(arr, i, j);
                }
            }
            Swap(arr, j, l);
            return j;
        }
        #endregion

        #region Mid value as pivot
        // Mid value works when the array is almost sorted

        public void QuickSortImpl_mid(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int pivotalIndex = Partition_mid(arr, l, h);

                // Quick sort '0' to 'pivot-1'
                QuickSortImpl_mid(arr, l, pivotalIndex - 1);

                // Quick sort ,pivot+1' to 'n'
                QuickSortImpl_mid(arr, pivotalIndex + 1, h);
            }
        }

        /// <summary>
        /// Case 1: Pivotal value is takes as Mid
        /// Pivotal = arr[mid]
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public int Partition_mid(int[] arr, int l, int h)
        {
            int i = l;
            int j = h;
            int mid = (i + h) / 2;
            int pivotValue = arr[mid];  //pivotal value is at index mid

            while (i <= j)
            {
                while (arr[i] < pivotValue) // increment i till i value > pivot
                    i++;
                while (arr[j] > pivotValue) // decrement j till j value < pivot
                    j--;
                if (i <= j)
                {
                    Swap(arr, i, j);
                }
            }
            return j;
        }
        #endregion

        #region High value as pivot
        /// <summary>
        /// Case 1: Pivotal value is takes as high
        /// Pivotal = arr[n-1]
        /// Here both i and j starts from low, where j = low, i = low -1
        /// for each j less than pivotValue, increment i and swap i with j, means we are moving less value to front
        /// at the end i+1 is the position that we want
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public int Partition_high(int[] arr, int l, int h)
        {
            // i starts from -1
            int i = l - 1;
            // pivotal value is high
            int pivotValue = arr[h];

            // iterate j from 0 to n-1
            for (int j = l; j < h; j++)
            {
                // increment i and swap i,j, for every j value less than pivot
                if (arr[j] < pivotValue)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            // finally swap i+1 and pivot value
            Swap(arr, i + 1, h);

            // our partition index is i+1 ( we have our pivot value there)
            return i + 1;
        }

        public void QuickSortImpl_high(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int pi = Partition_high(arr, l, h);

                // Quick sort '0' to 'pivot-1'
                QuickSortImpl_high(arr, l, pi - 1);

                // Quick sort ,pivot+1' to 'n'
                QuickSortImpl_high(arr, pi + 1, h);
            }
        }
        #endregion


        /// <summary>
        /// Swap elements of array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void Swap(int[] arr, int i, int j)
        {
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
