using System;
using System.Collections.Generic;
using System.Text;
/*Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
* Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
* The largest rectangle is shown in the shaded area, which has area = 10 unit.
* 
* Example:
* Input: [2,1,5,6,2,3]
* Output: 10
*/
namespace AviPreperation.Data_Structures
{
    //TimeComplexity - O(n)
    //SpaceComplexity - O(n)
    public class LargestRectangleInHistogram
    {
        public int LargestRectangleArea(int[] A)
        {
            //we need a stack to maintain the incrementing bars
            Stack<int> s = new Stack<int>();
            s.Push(-1);
            int maxArea = 0;

            //Iterate through the histogram and push the values if increments, pop and calculate area if decrements
            for (int i = 0; i <= A.Length; i++)
            {
                //if value in stack is greater than current value; i.e, decrementing, pop and calcultte maxArea till 
                //we reach lesser value than current value.
                while (s.Peek() != -1 && A[s.Peek()] >= A[i])
                {
                    //to calculate maxArea: prev heighest value(Pop) from stack * (current position we are at - 
                    //previous index(peek) after we pop -1)
                    maxArea = Math.Max(maxArea, A[s.Pop()] * (i - s.Peek() - 1));
                }
                s.Push(i);
            }

            //still we will left with some indexes in stack
            while (s.Peek() != -1)
                maxArea = Math.Max(maxArea, A[s.Pop()] * (A.Length - s.Peek() - 1));

            return maxArea;
        }
    }
}
