using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Stacks
{
    class DailyTemperaturesSol
    {
        public static int[] DailyTemperatures(int[] T)
        {
            //output array
            int[] result = new int[T.Length];
            //edge case
            if (T.Length == 0 || T == null)
                return result;

            //Need a stack to store the no od days
            Stack<int> stack = new Stack<int>();

            //iterating T from back
            for (int i = T.Length - 1; i >= 0; i--)
            {
                // if T[0] > T[1] then remove it
                while (stack.Count > 0 && T[i] >= T[stack.Peek()])
                    stack.Pop();

                //add the value to result
                result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
                stack.Push(i);
            }

            return result;
        }

        //static void Main()
        //{
        //    int[] a = new int[] { 74, 75, 71, 69, 72, 76, 73 };
        //    DailyTemperatures(a);
        //}

    }
}
