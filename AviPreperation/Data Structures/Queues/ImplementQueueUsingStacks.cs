using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
    /* Push()
     *      time complexity - O(1)
     *      Space Complexity - O(n)
     * Pop()
     *      time complexity - O(1) - amortized, O(n) - worst case
     *      space compexity - O(1)
     * Peek(), Empty()
     *      time complexity - O(1
     *      space complexity - O(1)
     */
    class MyQueue
    {
        Stack<int> s1 = new Stack<int>();
        Stack<int> s2 = new Stack<int>();
        int front;

        //NOTE: THE COMMENTED CODE FOR EACH METHOD IS APPROACH1, USING 2STACKS, DURING PUSH() ONLY WE ARE TRANSFERING
        //DATA FROM S1==>S2==>PUSH==>S2==>S1

        //NOTE: THE UNCONMMENTED CODE IS APPROACH2, DIRECTLY PUSHING TO S1
        //IN POP() S1==>S2==>S2.POP()
        /** Initialize your data structure here. */
        public MyQueue()
        {

        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            //if(Empty())
            //    front = x;
            // while(s1.Count > 0)
            //     s2.Push(s1.Pop());
            // s1.Push(x);
            // while(s2.Count > 0)
            //    s1.Push(s2.Pop());

            if (s1.Count == 0)
                front = x;
            s1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            //if(!Empty()){
            //    front = s1.Peek();
            //    return s1.Pop();
            //}
            //return int.MinValue;
            if (s2.Count == 0)
                while (s1.Count > 0)
                    s2.Push(s1.Pop());
            return s2.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            //return front;  
            if (s2.Count > 0)
                return s2.Peek();
            return front;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            //return s1.Count == 0;

            return s1.Count == 0 && s2.Count == 0;
        }
    }
}
