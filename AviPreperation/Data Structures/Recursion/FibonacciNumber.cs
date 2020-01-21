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
        public static int Fib1(int n)
        {
            int number = n - 1; //Need to decrement by 1 since we are starting from 0  
            int[] Fib = new int[number + 1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                Fib[i] = Fib[i - 2] + Fib[i - 1];
            }
            return Fib[number];
        }

        //public static void Main()
        //{
        //    Fib1(12);
        //}
    }
}
