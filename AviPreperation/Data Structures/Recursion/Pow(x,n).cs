using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    public class Pow_x_n
    {
        //RECURSIVE
        //Time Complexity - O(logn)
        //Space Complexity - O(logn)
        public double MyPow_Recursive(double x, int n)
        {
            long N = n;
            if (n < 0)
            {
                x = 1 / x;
                N = -N;
            }

            return helper(x, N);
        }

        public double helper(double input, long n)
        {
            if (n == 0)
                return 1.0;
            double half = helper(input, n / 2);
            if (n % 2 == 0)
            {
                return half * half;
            }
            else
            {
                return half * half * input;
            }
        }

        //ITERATIVE
        //Time Complexity - O(logn)
        //Space Complexity - O(1)
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            long N = n;
            if (n < 0)
            {
                x = 1 / x;
                N = -N;
            }

            double res = 1;
            double product = x;
            for (long i = N; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    res *= product;
                }
                product *= product;
            }
            return res;
        }

        //public static void Main()
        //{
        //    var pow = new Pow_x_n();
        //        Console.WriteLine(pow.MyPow(4,2));
        //}
    }
}
