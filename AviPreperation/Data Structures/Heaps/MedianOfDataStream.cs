using System;
using System.Collections.Generic;
using System.Text;
/*
* Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value. So the median is the mean of the two middle value.
* 
* For example,
* [2,3,4], the median is 3
* 
* [2,3], the median is (2 + 3) / 2 = 2.5
* 
* Design a data structure that supports the following two operations:
* 
* void addNum(int num) - Add a integer number from the data stream to the data structure.
* double findMedian() - Return the median of all elements so far.
*  
* 
* Example:
* 
* addNum(1)
* addNum(2)
* findMedian() -> 1.5
* addNum(3) 
* findMedian() -> 2 
*/
namespace AviPreperation.Data_Structures.Heaps
{
    //USING LIST BRUTE FORCE, FINDING MEDIAN BY LENGTHS
    //TIME LIMIT EXCEEDS FOR LARGER INPUTS
    public class MedianFinder
    {
        List<int> list;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            list = new List<int>();
        }

        public void AddNum(int num)
        {
            list.Add(num);
        }

        public double FindMedian()
        {
            list.Sort();
            int n = list.Count;
            if (n % 2 == 0)
                return (list[n / 2] + list[n / 2 - 1]) * 0.5;
            else
                return list[n / 2];
        }
    }


    //USING MIN-HEAP AND MAX-HEAP
    public class MedianOfDataStreamMedianFinder
    {
        private int counter = 0;
        //MinHeap
        private SortedSet<int[]> minHeap =
            new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]));
        //MaxHeap
        private SortedSet<int[]> maxHeap =
            new SortedSet<int[]>(Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]));

        /** initialize your data structure here. */
        public MedianOfDataStreamMedianFinder()
        {
        }

        public void AddNum(int num)
        {
            //generate new number array
            int[] newNum = new int[] { num, counter++ };

            //case:1 if counts of minheap == maxheap
            if (minHeap.Count == maxHeap.Count)
            {
                if (minHeap.Count == 0 || num <= minHeap.Max[0])
                {
                    minHeap.Add(newNum);
                }
                else
                {
                    maxHeap.Add(newNum);
                    //to make minheap count greater than max heap, 
                    minHeap.Add(maxHeap.Min);
                    maxHeap.Remove(maxHeap.Min);
                }
            }
            //case2: if num <= maxValue(minHeap) : put in minHeap
            else if (num <= minHeap.Max[0])
            {
                minHeap.Add(newNum);
                maxHeap.Add(minHeap.Max);
                minHeap.Remove(minHeap.Max);
            }
            //case3: if num > maxValue(minHeap) : put in maxHeap
            else
            {
                maxHeap.Add(newNum);
            }
        }

        public double FindMedian()
        {
            //since we are maintaining minHeap count > maxHeap by 1
            if (minHeap.Count == 0)
                return 0;
            if (minHeap.Count == maxHeap.Count)
                return (minHeap.Max[0] + maxHeap.Min[0]) * 0.5;
            else
                return minHeap.Max[0];
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
}
