using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class CountPrimesSolution
    {
        //TimeComplexity - less than n, logn or sqrt n 
        //SpaceComplexity - O(n)   
        public int CountPrimes(int n)
        {
            if (n <= 2)
                return 0;

            bool[] primes = new bool[n];
            int nonPrimeCount = 0;

            for (int i = 2; i * i < n; i++)
            {
                if (!primes[i])
                {
                    for (int j = i; j * i < n; j++)
                    {
                        //for n=13, i=2 => j= 2,3,4,5,6
                        //for n=13, i=3 => j= 3,4, which means 2*6 and 3*4 updates 12 twice, so avoiding with i*j
                        if (!primes[i * j])
                        {
                            primes[i * j] = true;
                            nonPrimeCount++; // only non visintg priems are counting 
                        }
                    }
                }
            }

            //n - total non primes we are counting - 2 is for 0 and 1 index
            return n - (nonPrimeCount + 2);
        }
    }
}
