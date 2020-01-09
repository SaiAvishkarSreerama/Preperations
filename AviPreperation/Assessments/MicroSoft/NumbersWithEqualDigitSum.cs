using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Assessments.MicroSoft
{
    static class NumbersWithEqualDigitSum
    {
        //Time Complexity: O(NlogK) - N for iterating through A, logK for finding hash value for each digit
        //Space Complexity: O(N).
        //There contains logK since computing the digit sum of A[i], which complexity is log(A[i]) with base 10.
        public static int EqualDigitSum(int[] A)
        {
            //Dictionary is holding hash key and max value of array value
            Dictionary<int, int> d = new Dictionary<int, int>();
            int maxSum = -1;

            for(int i = 0; i < A.Length; i++)
            {
                int key = hash(A[i]);
                if (d.ContainsKey(key))
                {
                    maxSum = Math.Max(maxSum, A[i] + d[key]);
                    d[key] = Math.Max(A[i], d[key]);
                }
                else
                {
                    d.Add(key, A[i]);
                }
            }

            return maxSum;
        }

        static int hash(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }


        //public int Hello()
        //{
        //    return 1;
        //}

        //public static void Main()
        //{
        //    //Example-1
        //    //51 ==> 5+1 ==> 6
        //    //71 --> 7+1 ==> 8
        //    //17 =====> 8
        //    //42 =====> 6
        //    //Sum of 51+42 = 93 which is greater than sum of 71+17=88(of sum group of 8)
            
        //    //int[] A = new int[] { 51,71,17,42};
        //    //int[] A = new int[] { 51,32,43};
        //    int[] A = new int[] { 42,33,60};

        //    Console.WriteLine(EqualDigitSum(A));
        //}
    }
}
