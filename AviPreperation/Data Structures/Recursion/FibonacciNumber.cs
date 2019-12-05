using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    //Time Complexity - O(N)
    //Space Complextiy - O(N), The size of the stack in memory is proportionate to

    public class FibonacciSolution
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        public int Fib(int N)
        {
            //check if the value in dictionary
            if (dict.ContainsKey(N))
                return dict[N];

            //fib of 0 and 1 are 0 and 1 only
            if (N < 2)
                return N;

            //calculate fib
            int result = Fib(N - 1) + Fib(N - 2);

            //Add value to dictionary
            dict.Add(N, result);

            return result;
        }
    }
}
