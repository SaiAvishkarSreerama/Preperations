/* Insertion Sort: Iteratively inserting each element of unsorted list into its correct position of sorted list
 * Time Complexity: 
 *      Best case - O(1), consider the array is already sorted
 *      Average - O(n2)
 *      Worst - O(n2)
 * Space complexity - O(1), since is in-place sorting
 * Explanation: for example  arr = { 23, 10, 5, 1, 2, 44, 30, 3 }
 *      1. let say we are at i=3, then j=i-1=>2, handValue = 1.
 *      2. check if 5 is greater than 1, yes, then put 5 at 1 place => {23, 10, __ ,5, 2, 44, 30, 3 }
 *      3. j--, repeat, check if 10 is greater than 1, yes, then move 10 one step forward=> {23, __, 10 ,5, 2, 44, 30, 3 }
 *      3. j--, repeat, check if 23 is greater than 1, yes, then move 23 one step forward=> {__ , 23, 10 ,5, 2, 44, 30, 3 }
 *      4. j--, repeat, but now j= -1, condition fails as j must be >= 0, then put handValue->1 at j+1 => -1+1 => arr[0] {1, 23, 10 ,5, 2, 44, 30, 3 }
 *      5. increment i++, now handValue is 2, repeat the process of j and untill we get 1>2 fails, then {1, 2, 23, 10 ,5, 44, 30, 3 }
 */

namespace PreperationsTest.Algorithms.Sorting
{
    [TestClass]
    public class InsertionSort
    {
        [TestMethod]
        public void InsertionSortExample()
        {
            int[] arr = { 23, 10, 5, 1, 2, 44, 30, 3 };

            InsertionSort_Ascending_impl(arr);

            InsertionSort_Descending_Forward_Impl(arr);

            arr = [23, 10, 5, 1, 2, 44, 30, 3];

            InsertionSort_Descending_Backward_Impl(arr);
        }

        /// <summary>
        /// Insertion sort ascending order
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertionSort_Ascending_impl(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++) // start from 1 index (10)
            {
                int handValue = arr[i]; // grab the 1 index value in the hand(10)
                int j = i - 1;

                while (j >= 0 && arr[j] > handValue) // now check if the value we hold(10) is smaller than the previous index values(23)
                {
                    arr[j + 1] = arr[j]; // then put 23 at 10 place, still hold the value(10)
                    j--;                 // decrement j, and repeat 
                }
                arr[j + 1] = handValue; // finally, at j=some index, our hand value is larger, then we know j+1 is the place for handValue
            }

            return arr;
        }

        /// <summary>
        /// Insertion sort descending order
        /// Leading from front
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertionSort_Descending_Forward_Impl(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++) // start from 1 index (10)
            {
                int handValue = arr[i]; // grab the 1 index value in the hand(10)
                int j = i - 1;

                while (j >= 0 && arr[j] < handValue) // now check if the value we hold(10) is greater than the previous index values(23)
                {
                    arr[j + 1] = arr[j]; 
                    j--;                 // decrement j, and repeat 
                }
                arr[j + 1] = handValue; // finally, at j=some index, our hand value is larger, then we know j+1 is the place for handValue
            }

            return arr;
        }

        /// <summary>
        /// Insertion sort descending order
        /// Leading from Back { 23, 10, 5, 1, 2, 44, 30, 3 }
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertionSort_Descending_Backward_Impl(int[] arr)
        {
            int n = arr.Length;
            for (int i = n-1-1; i >= 0; i--) // start from last but one index for n=8, index-7 (30)
            {
                int handValue = arr[i]; // grab the index value in the hand(30)
                int j = i + 1;  // j always higher than i here, i+1

                while (j < n && handValue < arr[j]) // while j always between i and n, now check if the value we hold(30) is less than the next index values(3)
                {
                    arr[j - 1] = arr[j]; // if so, move backward, place arr[j] in arr[j-1]
                    j++;                 // increment j, and repeat 
                }
                arr[j - 1] = handValue; // finally, at j=some index, our hand value is smaller, then we know j-1 is the place for handValue
            }

            return arr;
        }
    }
}
