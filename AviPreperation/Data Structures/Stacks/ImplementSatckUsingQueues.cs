using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    /* Push()
     *      time complexity - O(n)
     *      Space Complexity - O(1)
     * Pop()
     *      time complexity - O(1) 
     *      space compexity - O(1)
     * Peek(), Empty()
     *      time complexity - O(1
     *      space complexity - O(1)
     */
    class MyStack
    {
        Queue<int> q = new Queue<int>();
        /** Initialize your data structure here. */
        public MyStack()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q.Enqueue(x);
            int size = q.Count;
            while (size > 1)
            {
                q.Enqueue(q.Dequeue());
                size--;
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return q.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return q.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q.Count == 0;
        }
    }
}
