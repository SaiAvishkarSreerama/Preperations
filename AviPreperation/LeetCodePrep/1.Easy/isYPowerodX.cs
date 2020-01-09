using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.LeetCodePrep._1.Easy
{
    class isYPowerodX
    {
        //TimeComplexity - O(N)
        //SpaceComplexity - O(1)
        public static bool IsPower(int x, int y)
        {
            int product = 1;
            while (product < y)
                product *= x;
            return product == y;
        }

        public static bool IsPower1(int x, int y)
        {
            int res1 = (int)Math.Log(y) / (int)Math.Log(x);
            double res2 = Math.Log(y) / Math.Log(x);

            return (res1 == res2);

        }

        //public static void Main()
        //{
        //    //Console.WriteLine(IsPower(10, 1000)); 
        //    Console.WriteLine(IsPower1(27,729));
        //}
    }
}
