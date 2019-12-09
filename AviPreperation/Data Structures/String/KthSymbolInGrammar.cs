using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.String
{
    class KthGrammarSolution
    {
        public int kthGrammar(int N, int K)
        {
            if (N == 1) return 0;
            int prevK = K / 2;
            if (K%2 == 0)
            {
                return (kthGrammar(N - 1, prevK) + 1) % 2;
            }
            return kthGrammar(N - 1, prevK);
        }

        //public static void Main()
        //{
        //    var pow = new KthGrammarSolution();
        //    Console.WriteLine(pow.kthGrammar(4, 2));
        //}
    }
}
