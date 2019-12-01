using System;
using System.Collections.Generic;
using System.Text;
/*
* Given a stream of integers and a window size, calculate the moving average of all integers in the sliding window.
* 
* Example:
* MovingAverage m = new MovingAverage(3);
* m.next(1) = 1
* m.next(10) = (1 + 10) / 2
* m.next(3) = (1 + 10 + 3) / 3
* m.next(5) = (10 + 3 + 5) / 3
*/
namespace AviPreperation.Data_Structures
{
    //USING CIRCULAR ARRAY
    //TimeComplexity - O(1),as we can see that there is no loop in the next(val) function.
    //Space Complexity - O(n), n is given size of window
    public class MovingAverage1
    {
        int size;
        int count = 0;
        int sum = 0;
        int head = 0;
        int[] arr;
        /** Initialize your data structure here. */
        public MovingAverage1(int size)
        {
            arr = new int[size];
            this.size = size;
        }

        public double Next(int val)
        {
            ++count;
            //to remove tail val, whcih is old value added before three steps
            //head+1 always gives the next index of the circular array 
            int tail = (head + 1) % size;
            sum = sum + val - arr[tail];

            head = tail;
            arr[head] = val;

            return sum * 1.0 / Math.Min(count, size);
        }
    }

    // /**
    //  * Your MovingAverage object will be instantiated and called as such:
    //  * MovingAverage obj = new MovingAverage(size);
    //  * double param_1 = obj.Next(val);
    //  */

    //USING QUEUE
    //TimeComplexity - O(1),as we can see that there is no loop in the next(val) function.
    //Space Complexity - O(n), n is given size of window
    public class MovingAverage
    {
        int count = 0;
        int sum = 0;
        Queue<int> q;
        double size;
        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            q = new Queue<int>();
            this.size = size;
        }

        public double Next(int val)
        {
            if (q.Count >= size)
            {
                sum -= q.Dequeue();
            }

            q.Enqueue(val);
            sum += val;
            Console.WriteLine(sum + " - " + q.Count);
            return (double)sum / q.Count;

        }
    }

    /**
     * Your MovingAverage object will be instantiated and called as such:
     * MovingAverage obj = new MovingAverage(size);
     * double param_1 = obj.Next(val);
     */




}
