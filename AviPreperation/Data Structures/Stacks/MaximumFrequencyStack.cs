﻿using System;
using System.Collections.Generic;
using System.Text;

/*
* Implement FreqStack, a class which simulates the operation of a stack-like data structure.
* 
* FreqStack has two functions:
* 
* push(int x), which pushes an integer x onto the stack.
* pop(), which removes and returns the most frequent element in the stack.
* If there is a tie for most frequent element, the element closest to the top of the stack is removed and returned.
*  
* 
* Example 1:
* 
* Input: 
* ["FreqStack","push","push","push","push","push","push","pop","pop","pop","pop"],
* [[],[5],[7],[5],[7],[4],[5],[],[],[],[]]
* Output: [null,null,null,null,null,null,null,5,7,5,4]
* Explanation:
* After making six .push operations, the stack is [5,7,5,7,4,5] from bottom to top.  Then:
* 
* pop() -> returns 5, as 5 is the most frequent.
* The stack becomes [5,7,5,7,4].
* 
* pop() -> returns 7, as 5 and 7 is the most frequent, but 7 is closest to the top.
* The stack becomes [5,7,5,4].
* 
* pop() -> returns 5.
* The stack becomes [5,7,4].
* 
* pop() -> returns 4.
* The stack becomes [5,7].
*  
* 
* Note:
* 
* Calls to FreqStack.push(int x) will be such that 0 <= x <= 10^9.
* It is guaranteed that FreqStack.pop() won't be called if the stack has zero elements.
* The total number of FreqStack.push calls will not exceed 10000 in a single test case.
* The total number of FreqStack.pop calls will not exceed 10000 in a single test case.
* The total number of FreqStack.push and FreqStack.pop calls will not exceed 150000 across all test cases.
* */
namespace AviPreperation.Data_Structures.Stacks
{
    //TimeComplexity - O(1)
    //SpaceComplexity - O(N)
    public class MaximumFrequencyStack
    {
        public Dictionary<int, int> freq;
        public Dictionary<int, Stack<int>> group;
        public int maxFreq = 0;

        public MaximumFrequencyStack()
        {
            freq = new Dictionary<int, int>();
            group = new Dictionary<int, Stack<int>>();
        }

        public void Push(int x)
        {
            //count the freq of number x
            if (!freq.ContainsKey(x))
                freq.Add(x, 0);
            freq[x]++;

            int xFreq = freq[x];
            //find the maxFreq for pop purpose
            maxFreq = Math.Max(maxFreq, xFreq);

            //find the xFreq stack to push the number x
            if (!group.ContainsKey(xFreq))
                group.Add(xFreq, new Stack<int>());
            group[xFreq].Push(x);
        }

        public int Pop()
        {
            int x = -1;
            //pop value from the stack of maxFreq
            if (group.ContainsKey(maxFreq))
                x = group[maxFreq].Pop();

            //reduce the poped value freq from freq dictionary
            freq[x]--;

            //check the stack empty and remove
            if (group[maxFreq].Count == 0)
                maxFreq--;

            return x;
        }
    }

    /**
     * Your FreqStack object will be instantiated and called as such:
     * FreqStack obj = new FreqStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     */
}
