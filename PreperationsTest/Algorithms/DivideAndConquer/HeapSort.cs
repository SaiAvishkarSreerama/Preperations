/*
 * Heap Sort: Deleting a max/min value and placing it in the empty available place forms a sorted array 
 * 1. Delete the max value at '0' index
 * 2. Add it to the size+1 index for every delete.
 * 3. Array is sorted ascendigly for maxHeap, descendingly for minHeap
 * 
 * Time Complexity - O(n logn), n elements take log n time to form a tree
 * Space Complexity - O(1), In-place sorting
 */

using System.Runtime.InteropServices.Marshalling;

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class HeapSort
    {
        public int[] heap = new int[50];
        public int size = -1;
        public int finalHeapSize;

        [TestMethod]
        public void HeapSort_Test()
        {
            // Build a heap  { 30, 10, 15, 8, 20, 50 };
            Insert(30);
            Insert(10);
            Insert(15);
            Insert(8);
            Insert(20);
            Insert(50);
            Insert(500);
            Insert(200);

            // now we have the final size of the heap
            // when we sort the heap, we remove the max and put in the last available index
            finalHeapSize = size;

            // sort the heap
            HeapSort_heap();
            for(int i= finalHeapSize; i >= 0; i--)
            {
                Console.WriteLine(heap[i]);
            }
        }

        /// <summary>
        /// Insert value
        /// 1. Increment size
        /// 2. Insert value at the size
        /// 3. Heapify Shiftup the inserted value
        /// </summary>
        /// <param name="nodeVal"></param>
        public void Insert(int nodeVal)
        {
            size++;

            heap[size] = nodeVal;

            Heapify_ShiftUp(size);
        }

        /// <summary>
        /// Shift up
        /// 1. Get the parent index
        /// 2. If the parent index value is less than the current value, swap
        /// 3. Iteratively/recursively shiftup until satisfying heap property
        /// </summary>
        /// <param name="ci">current index</param>
        public void Heapify_ShiftUp(int ci)
        {
            while (ci > 0 && heap[ParentIndex(ci)] < heap[ci])
            {
                int pi = ParentIndex(ci); //parent index
                Swap(ci, pi);
                ci = pi;
            }
        }

        public void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        /// <summary>
        /// sort the heap/array
        /// 1. iteratively/recursively extract the min/max value at 0 position
        /// 2. insert the extracted value at size+1, availble position
        /// 3. array is sorted ascending, print the values
        /// </summary>
        public void HeapSort_heap()
        {
            while (size > -1)
            {
                int eMax = ExtractMax();

                heap[size + 1] = eMax;
            }
        }

        /// <summary>
        /// Exract max
        /// 1. Collect the max value at 0;
        /// 2. Replace the max value with leaf node availalbe at size
        /// 3. Decrement the size, heap is reduced
        /// 4. Heapify_shiftDown to re arrange the heap
        /// 5. Return the max value
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            int maxValue = heap[0];

            heap[0] = heap[size];
            size--;

            Heapify_shiftDown(0);

            return maxValue;
        }

        /// <summary>
        /// ShiftDown
        /// 1. Let current index is the maxIndex(mi)
        /// 2. Get left child index(li), compare with maxIndex values, if larger value then mi = li
        /// 3. Get right child index(ri), compare with maxIndex values, if larger value then mi = ri
        /// 4. if ci != mi, swap ci and mi
        /// 5. Repeat shiftDown till heap is satisfied
        /// </summary>
        public void Heapify_shiftDown(int ci)
        {
            int mi = ci;

            int li = LeftChildIndex(ci);
            if (li <=size && heap[li] > heap[mi])
            {
                mi = li;
            }

            int ri = RightChildIndex(ci);
            if (ri <= size && heap[ri] > heap[mi])
            {
                mi = ri;
            }

            if(ci != mi)
            {
                Swap(ci, mi);
                Heapify_shiftDown(mi);
            }
        }

        public int ParentIndex(int ci)
        {
            return (ci - 1) / 2;
        }
        public int LeftChildIndex(int ci)
        {
            return 2 * ci + 1;
        }
        public int RightChildIndex(int ci)
        {
            return 2 * ci + 2;
        }

    }
}
