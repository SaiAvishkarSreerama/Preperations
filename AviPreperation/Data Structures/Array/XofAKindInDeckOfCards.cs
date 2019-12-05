using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class Solution
    {
        //Time Complexity- O(NlogN), N = no of cards, for GCD-O(logN), for each card in n we find GCD
        //Space Complexity - O(N)
        public bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length <= 1 || deck == null)
                return false;

            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < deck.Length; i++)
            {
                if (d.ContainsKey(deck[i]))
                {
                    d[deck[i]]++;
                }
                else
                {
                    d.Add(deck[i], 1);
                }
            }
            int res = 0;
            foreach (var k in d.Keys)
            {
                res = gcd(res, d[k]);
            }

            return res > 1;
        }

        //Recursive to find GCD
        // public int gcd(int a, int b){
        //     return a==0 ? b : gcd(b%a, a);
        // }

        //ITERATIVE for GCD
        public int gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
    }
}
