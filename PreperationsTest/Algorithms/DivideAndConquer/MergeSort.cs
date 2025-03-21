/*
 * Merge Sort is sorting algorithm that follows the divide and conquer approach
 * It divides the array into two halves until the array has one element, and then merge each sub arrays by sorting them.
 * Time Complexity: O(nlogn)
 * Space Complexity: O(n) - as it creates subarrays for n elements
 * Explanation:
 *      1. we need low, mid and high of the array
 *      2. Recurse by calling merfeSort with first half (low to mid) and second half (mid+1 to high)
 *      3. Merge the two sub arrays left and right.
 *          i. first we determine the lengths of temp sub arrays
 *          ii. L - length would be mid - low + 1 (1 is for including the mid element)
 *          iii. R - lenght would be hig - mid
 *          iv. fill the sub arrays through iteration by getting the low values from arr, L will get arr[l + i], R will be arr[m + 1 +j]
 *          v. Compare the L and R each ele by incrementing their indexes i and j, and insert into arr[k], k will be low for that sub array, i.e, k=l
 *          vi. If any ele left in left and right sub arrays, iterate them and add into arr[k++]
 */

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class MergeSort
    {
        [TestMethod]
        public void MergeSort_test()
        {
            int[] arr = { 15, 2, 8, 9, 12, 5, 4, 17 };

            MergeSort_recursion(arr, 0, arr.Length - 1);
        }

        public void MergeSort_recursion(int[] arr, int l, int h)
        {
            if (l < h)
            {
                int m = (l + h) / 2;

                MergeSort_recursion(arr, l, m);
                MergeSort_recursion(arr, m + 1, h);

                Merge(arr, l, m, h);
            }
        }

        public void Merge(int[] arr, int l, int m, int h)
        {
            int i = 0, j = 0, k = 0;

            // find the lenghts of the two arrays
            int l1 = m - l + 1; // add 1 to includes the mid index, for mid=4, means we have 0-4=5 elements, if l1=m-l it gives 4only till m-1, so +1 would add m as well
            int r1 = h - m;

            // create two temp arrays for both arrays
            int[] L = new int[l1];
            int[] R = new int[r1];

            //insert data into temp arrays
            for (i = 0; i < l1; i++)
            {
                L[i] = arr[l + i];
            }
            for (j = 0; j < r1; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            i = 0;
            j = 0;
            k = l; // k should starts from low of that sub-array

            // merge two arrays
            while (i < l1 && j < r1)
            {
                if (L[i] <= R[j])
                {
                    arr[k++] = L[i++];
                }
                else
                {
                    arr[k++] = R[j++];
                }
            }

            // Add any remaining elements from L and R to array
            while (i < l1)
            {
                arr[k++] = L[i++];
            }

            while (j < r1)
            {
                arr[k++] = R[j++];
            }
        }
    }
}
