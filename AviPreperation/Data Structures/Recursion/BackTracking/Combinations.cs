using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion.BackTracking
{
    //TimeComplexity - O(k * Combinations(k==>n))
    //SpaceComplexity - O(Combinations(k==>n))
    public class Combinations
    {
        public static IList<IList<int>> combine(int n, int k)
        {
            List<IList<int>> combs = new List<IList<int>>();
            helper(combs, new List<int>(), 1, n, k);
            return combs;
        }

        public static void helper(List<IList<int>> combs, List<int> comb, int start, int n, int k)
        {
            if (k == 0)
            {
                combs.Add(new List<int> ( comb ));
                return;
            }

            for(int i=start; i <= n; i++)
            {
                comb.Add(i);
                helper(combs, comb, i + 1, n, k - 1);
                comb.RemoveAt(comb.Count-1);
            }
        }

        //public static void Main()
        //{
        //    combine(4, 2);
        //}
    }
}
