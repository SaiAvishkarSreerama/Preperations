using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
    public class MyCircularQueue
    {
        private int size;
        private int rear;
        private int front;
        private int[] queue;

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            size = k;
            front = -1;
            rear = -1;
            queue =  new int[k];
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;
            if (IsEmpty())
                front = 0;
            rear = (rear + 1) % size;
            queue[rear] = value;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty())
                return false;
            if (front == rear)
            {
                front = -1;
                rear = -1;
                return true;
            }        
            front = (front + 1) % size;
            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty())
            {
                return -1;
            }
            return queue[front];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty())
            {
                return -1;
            }
            return queue[rear];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return front == -1;
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return ((rear + 1)%size) == front;
        }

        /**
         * Your MyCircularQueue object will be instantiated and called as such:
         * MyCircularQueue obj = new MyCircularQueue(k);
         * bool param_1 = obj.EnQueue(value);
         * bool param_2 = obj.DeQueue();
         * int param_3 = obj.Front();
         * int param_4 = obj.Rear();
         * bool param_5 = obj.IsEmpty();
         * bool param_6 = obj.IsFull();
         */

        //public static void Main()
        //{
        //    int k = 3;
        //    int value = 1;
        //    MyCircularQueue obj = new MyCircularQueue(k);
        //    bool param_1 = obj.EnQueue(value);
        //    bool param_2 = obj.DeQueue();
        //    int param_3 = obj.Front();
        //    int param_4 = obj.Rear();
        //    bool param_5 = obj.IsEmpty();
        //    bool param_6 = obj.IsFull();
        //}
    }
}
