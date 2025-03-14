using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.DataStructures.Heap
{
    /*         45
            /      \
           20      32
          /  \    /  \
         13  14  7   11
        /  \
       12   7
    Create a priority queue shown in  example in a binary max heap form.
    Queue will be represented in the form of array as: 45 20 31 13 14 7 11 12 7 
    
    Operations:
        1. Create a Heap
        2. Extract Max value
        3. Change the Priaority of element at index-4 to 49
        4. Remove element at index 3
    */

    /*
      Explanation: Create a Map
         1. Initializing size = -1 and Heap an array
         2. Inserting the values in the heap
            i. When Inserting 45, it inserts at index 0
            ii. When Inserting 14, it inserts at index 1 (left child of 45) , and check for heapify_Shifup : if heap[1] > heap[0] and swap
            iii. When Inserting 31, it inserts at index 2 (right child of 45), and check for heapify_Shifup : if heap[2] > heap[0] and swap
            iv. When Inserting 13, it inserts at index 3 (get its parent from ParentIndex() => left child of 14), and check for heapify_Shifup : if heap[3] > heap[1] and swap
            v. When Inserting 20, it inserts at index 4 (get its parent from ParentIndex() => right child of 14), and check for heapify_Shifup : if heap[4] > heap[1]=> 20>14, then swap and until satisfy the heap property
            vi. and so on for all the elements.
        3. Printing the heap gives us 
           45 20 31 13 14 7 11 12 7
                                                                          45
                                                                       /      \
                                                                      20      32
                                                                     /  \    /  \
                                                                    13  14  7   11
                                                                   /  \
                                                                  12   7
      Explanation: Extract Max value
            1. Extract the max value from the heap
            2. Replace the first element with the last element
            3. Decrease the size of the heap
            4. Heapify the heap from top to bottom (ShiftDown)
            5. Return the max value
            6. Printing the heap gives us
                31 20 11 13 14 7 7 12 
                                                                            31
                                                                         /      \
                                                                        20      11
                                                                       /  \    /  \
                                                                      13  14  7   7
                                                                     /  
                                                                    12

      Explanation: Change the Priaority of element at index-4 to 49
            1. Get the before value (14)
            2. Replace the value (14 => 49)
            3. Check if the before value is less than the new value
                i. If yes, then Heapify the heap from bottom to top (ShiftUp) --> 49 > 14
                ii. If no, then Heapify the heap from top to bottom (ShiftDown)
            4. Printing the heap gives us
                49 31 11 13 20 7 7 12 
                                                                            49
                                                                         /      \
                                                                        31      11
                                                                       /  \    /  \
                                                                      13  20  7   7
                                                                     /  
                                                                    12

      Explanation: Remove element at index 3
            1. Replace the removing element with maxVal + 1 => heap[0] +1 => 49+1 => 50
            2. heapify shifup
            3. Extract max value, this will remove the temporary max value that we replaced with 
            4. Printing the heap gives us
                49 31 11 12 20 7 7
                                                                            49
                                                                         /      \
                                                                        31      11
                                                                       /  \    /  \
                                                                      12  20  7   7
     */

    [TestClass]
    public class BinaryHeapImplementation
    {
        public int size = -1;
        public int[] heap = new int[50];

        /// <summary>
        /// Get the parent element index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }

        /// <summary>
        /// Get the left child element index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int LeftChildIndex(int i)
        {
            return 2 * i + 1;
        }

        /// <summary>
        /// Get the right child element index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int RightChildIndex(int i)
        {
            return 2 * i + 2;
        }

        [TestMethod]
        public void BinaryHeapImplementationTest()
        {
            // 1. Create a Heap
            // Inserting the values in the heap
            Insert(45);
            Insert(14);
            Insert(31);
            Insert(13);
            Insert(20);
            Insert(7);
            Insert(11);
            Insert(12);
            Insert(7);
            PrintHeap(); // => 45 20 31 13 14 7 11 12 7

            // 2. Extract Max Value
            int maxValue = ExtractMax();
            PrintHeap(); // => 31 20 11 13 14 7 7 12

            // 3. Change the Priaority of element at index-4 to 49
            ChangePriority(4, 49);
            PrintHeap(); // => 49 31 11 13 20 7 7 12

            // 4. Remove element at index 3
            Remove(3);
            PrintHeap(); // => 49 31 11 12 20 7 7
        }

        public void PrintHeap()
        {
            for (int i = 0; i <= size; i++)
            {
                Console.Write(heap[i] + " ");
            }
        }

        public void Insert(int key)
        {
            //increase the size of heap by 1
            size++;

            //insert the element at end of the heap
            heap[size] = key;

            //heapify the heap from bottom to top
            Heapify_ShiftUp(size);
        }

        /// <summary>
        /// Heapify the heap from bottom to top
        /// </summary>
        /// <param name="size"></param>
        public void Heapify_ShiftUp(int size)
        {
            while (size > 0 && heap[size] > heap[ParentIndex(size)]){

                int parentIndex = ParentIndex(size);
                // swap the current element with the parent element
                // sending the current element and parent element indexes
                Swap(size, parentIndex);
                size = parentIndex;
            }
        }

        /// <summary>
        /// Swap the elements in the heap
        /// </summary>
        /// <param name="current"></param>
        /// <param name="parent"></param>
        public void Swap(int current,int parent)
        {
            int temp = heap[parent];
            heap[parent] = heap[current];
            heap[current] = temp;
        }

        /// <summary>
        /// Extract the max value from the heap
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            int maxVal = heap[0];

            heap[0] = heap[size];
            size = size - 1;

            // Since max value is replaced with the last node value, now the first node is a smaller value (let say 7)
            // We need to heapify to satisfy the heap property
            Heapify_ShiftDown(0);

            return maxVal;
        }

        /// <summary>
        /// Heapify the heap from top to bottom
        /// </summary>
        /// <param name="i"></param>
        public void Heapify_ShiftDown(int i)
        {
            // Let consider the current index as maxIndex
            int maxIndex = i;

            // check if the left child is greater than the current index value
            // if so, the our left child is the max
            int leftChildIndex = LeftChildIndex(i);
            if (i <= size && heap[leftChildIndex] > heap[maxIndex])
            {
                maxIndex = leftChildIndex;
            }

            // check if the right child is greater than the current index value
            // if so, the our right child is the max
            int rightChildIndex = RightChildIndex(i);
            if (i <= size && heap[rightChildIndex] > heap[maxIndex])
            {
                maxIndex = rightChildIndex;
            }

            // Check if the maxIndex is not equal to the current index, means we are at leaf node already
            // IF left then we need to swap the current index with the left child
            // If right then we need to swap the current index with the right child
            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                // Recursion utill we reach the leaf node
                Heapify_ShiftDown(maxIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name=""></param>
        public void ChangePriority(int index, int heapValue)
        {
            // get the before value
            int beforeVal = heap[index];

            // replace the value
            heap[index] = heapValue;

            if (beforeVal < heapValue)
            {
                Heapify_ShiftUp(index);
            }
            else
            {
                Heapify_ShiftDown(index);
            }
        }

        public void Remove(int index)
        {
            // get max value
            int maxValue = heap[0];

            // replace the removing index value with highest value
            heap[index] = maxValue + 1; // heap[3] = 49+1 = 50

            // now we have a high number at index-3, do heapify and get it at root
            // and then we can extract the value, which will heapify and set the heap
            Heapify_ShiftUp(index);
            ExtractMax();
        }
    }
}
