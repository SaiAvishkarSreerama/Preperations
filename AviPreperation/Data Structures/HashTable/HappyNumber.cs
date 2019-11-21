using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class IsHappySolution
    {
        //Scenario -1
        public static bool IsHappy(int n)
        {
            //Time Complexity = O(logn) - O(1)
            //Space Complexity = O(logn)
            //..................Using hash Set
            //At some point if the sum of squares of the num doesn't return 1, but if it return any number twice 
            //means, it will endlessly loop around that num; So we need to maintain the numbers and return false.
            //using HAshSet for that
            HashSet<int> h = new HashSet<int>();

            //IF n = 1 : stop
            while (n != 1)
            {
                int sum = 0;
                //if n = 0: stop
                while (n > 0)
                {
                    sum += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }

                //given number 18->65->61->37->58->89->145->42->20->2->4->16->37(so it will have a loop at 37), 
                //return false.....
                if (h.Contains(sum))
                    return false;

                n = sum;
                h.Add(n);
            }

            return true;
        }

        //Scenario -2
        public static bool IsHappy1(int n)
        {
            //TimeComplexity - O(log n)
            //SpaceComplexity - O(1)
            //............With out HashSet
            // Trick - 2,3,4,5,6 are always UnHappy numbers
            while (n > 6)
            {
                int sum = 0;
                while (n != 0)
                {
                    sum += (int)Math.Pow(n % 10, 2);
                    n /= 10;
                }
                n = sum;
            }
            Console.WriteLine(n);
            return n == 1;
        }

        //public static void Main()
        //{
        //    Console.WriteLine(IsHappy(19));
        //    Console.WriteLine(IsHappy1(19));
        //}
    }
}
