using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    public class MinStack
    {
        Stack<int> stack = new Stack<int>();
        int min = int.MaxValue;

        //if x < min, then x is considered as min
        // before that the valu in min should be push to stack for using later pop.
        public void Push(int x)
        {
            if (x <= min)
            {
                stack.Push(min);
                min = x;
            }
            stack.Push(x);
        }

        //as we pushed min and x in to the stack
        //during pop, if removing value is min value then poping out next value and setting it to min 
        public void Pop()
        {
            if (min == stack.Pop())
            {
                min = stack.Pop();// as this was the value we inserted during push
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
        }



        //int tail;
        //int tailMin;
        //List<int> s;
        //List<int> min;
        ///** initialize your data structure here. */
        //public MinStack()
        //{
        //    tail = -1;
        //    tailMin = -1;
        //    s = new List<int>();
        //    min = new List<int>();
        //}
        //
        //public void Push(int x)
        //{
        //    if (min.Count - 1 > tailMin)
        //        min[++tailMin] = x;
        //    else if(tailMin == -1 || min[tailMin] > x)
        //    {
        //        tailMin++;
        //        min.Add(x);
        //    }
        //
        //    if (tail == s.Count-1)
        //    {
        //        tail++;
        //        s.Add(x);
        //    }
        //    else if(s.Count-1 > tail)
        //    {
        //        s[++tail] = x;
        //    }
        //}
        //
        //public void Pop()
        //{
        //    if (tail > -1 && tailMin > -1 && s[tail] == min[tailMin])
        //        tailMin--;
        //    if (tail > -1)
        //        tail--;
        //}
        //
        //public int Top()
        //{
        //    return s[tail];
        //}
        //
        //public int GetMin()
        //{
        //    return min[tailMin];
        //}

        //public static void Main()
        //{
        //    //Your MinStack object will be instantiated and called as such:
        //    MinStack minStack = new MinStack();
        //    minStack.Push(-2);
        //    minStack.Push(0);
        //    minStack.Push(-3);
        //    Console.WriteLine(minStack.GetMin()); //--> Returns - 3.
        //    minStack.Pop();
        //    Console.WriteLine(minStack.Top()); //--> Returns 0.
        //    Console.WriteLine(minStack.GetMin()); //--> Returns - 2.


        //    //minStack.Push(int.MaxValue-1);
        //    //minStack.Push(int.MaxValue-1);
        //    //minStack.Push(int.MaxValue);
        //    //Console.WriteLine(minStack.Top());
        //    //minStack.Pop();
        //    //Console.WriteLine(minStack.GetMin());
        //    //minStack.Pop();
        //    //minStack.Push(int.MaxValue);
        //    //Console.WriteLine(minStack.Top());
        //    //Console.WriteLine(minStack.GetMin());
        //    //minStack.Push(int.MinValue);
        //    //Console.WriteLine(minStack.Top());
        //    //Console.WriteLine(minStack.GetMin());
        //    //minStack.Pop();
        //    //Console.WriteLine(minStack.GetMin());
        //}
    }
}
