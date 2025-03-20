
/*
 * Time Complexity - O(logn)
 */

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class BinarySearch
    {
        [TestMethod]
        public void BinarySearchMethodTest()
        {
            int[] arr = { 3, 6, 8, 12, 14, 17, 25, 29, 31, 36, 42, 47, 53, 55, 62 };

            // searched key in the sorted array through iteration
            int searchKeyIndex = BinarySearch_IterativeMethod(arr, arr.Length, 36);

            // Search key in the sorted array through recursion
            searchKeyIndex = BinarySearch_RecursionMethod(arr, arr.Length, 36);
            Assert.AreNotEqual(searchKeyIndex, -1);

            searchKeyIndex = BinarySearch_RecursionMethod(arr, arr.Length, 30);
            Assert.AreEqual(searchKeyIndex, -1);
        }

        public int BinarySearch_IterativeMethod(int[] arr, int n, int key)
        {
            if (arr.Length == 0)
            {
                return -1;
            }

            int low = 1;
            int high = n;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key == arr[mid])
                {
                    return mid;
                }

                if (key < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            };

            return -1;
        }


        public int BinarySearch_RecursionMethod(int[] arr, int n, int key)
        {
            if(arr.Length == 0)
            {
                return -1;
            }

            int low = 1;
            int high = n;
            int mid = (low + high) / 2;
            return BinarySearchRecursion(arr, low, high, mid, key);
        }

        public int BinarySearchRecursion(int[] arr, int low, int high, int mid, int key)
        {
            if( low == high)
            {
                return  key == arr[low] ? low : -1;
            }

            if (arr[mid] == key)
            {
                return mid;
            }

            if (key < arr[mid])
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }

            mid = (low + high) / 2;

            return BinarySearchRecursion(arr, low, high, mid, key);
        }
    }
}
