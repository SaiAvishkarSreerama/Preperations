using System;
using System.Collections.Generic;
using System.Text;
/*Given n, how many structurally unique BST's (binary search trees) that store values 1 ... n?

Example:

Input: 3
Output: 5
Explanation:
Given n = 3, there are a total of 5 unique BST's:

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3*/
namespace AviPreperation.Data_Structures.Recursion
{
    public class UniqueBinaryTreesSolution
    {
        //Using Dynamic Programming
        //Catalan numbers for n is 1,2,5,13,34... https://en.wikipedia.org/wiki/Catalan_number
        // Cartesian product of left sub trees and righ sub trees G[n] = F[i-1]*F[n-i], where n is no of nodes, i is the root of n nodes available if n=3 then i=1,2,3.
        public int NumTrees(int n)
        {
            int[] G = new int[n + 1];
            G[0] = 1;
            G[1] = 1;

            //Here i or node will be the no of nodes
            //and j or root will be each node as a root and its possible binary search trees
            for (int node = 2; node <= n; node++)
            {
                for (int root = 1; root <= node; root++)
                {
                    G[node] += G[root - 1] * G[node - root]; // using += because for n=2, for node1 as root G[1] will comes and it will adds to the node2 as root
                }
            }
            return G[n];
        }
    }
}
