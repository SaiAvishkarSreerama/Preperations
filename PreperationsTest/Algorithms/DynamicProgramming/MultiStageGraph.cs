using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.Algorithms.DynamicProgramming
{
    [TestClass]
    public class MultiStageGraph
    {
        [TestMethod]
        public void Run()
        {
            // Directed weighted graph
            // MultiStage graph
            int[,] graph = new int[,] {
                { 1, 2, 2 },
                { 1, 3, 1 },
                { 1, 4, 3 },
                { 2, 5, 2 },
                { 2, 6, 3 },
                { 3, 5, 6 },
                { 3, 6, 7 },
                { 4, 5, 6 },
                { 4, 6, 8 },
                { 4, 7, 9 },
                { 5, 8, 6 },
                { 6, 8, 4 },
                { 7, 8, 5 },
            };

            int vertices = 8;
            int stages = 4;

            // Get the path from stage-1 to stagen
            // Here we get [1, 2, 6, 8], means traversing form 1 to n through these nodes gives smallest cost
            int[] path = MultiStageGraphTest(graph, vertices, stages);
        }

        /// <summary>
        /// Traversing MultiStage graph to get the min cost
        /// Explanation:
        ///     1. we need a graph in either Adj matrix or adk list format, so intialize and fill the data
        ///     2. we need 3 arrays
        ///         a. cost - to maintain each node cost from itself to end node (of lenght v vertices)
        ///         b. directions - each node that takes the min cost next stage node (of lenght v vertices)
        ///         c. path - list of all nodes that we get to traverse from first stage-last stage (of lenght s stages)
        ///     3. Iterate through each vertices(v) from end
        ///         a. for each node let say 5, get the associated edges form the graph , 
        ///             if adjList calling adjList[5] gives total no of edges, iterating those only
        ///             if adjMatrix we need to call adjMatrix[5, k] where k = 5+1 to v(8)
        ///         b. Check if each edge weight + nextNode cost is min then update it in the cost[] and add the next node to dir[]
        ///     4. For path array, we know p[1]=1 nad p[s] = v, as 1 node present in 1st stage and s(8) node present in s(4) stage
        ///         Use p[i] = dir[p[i-1]] to get the path for each stage from the directions[]
        ///         
        /// TC - O(N)
        /// SC - O(N)
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="v"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] MultiStageGraphTest(int[,] graph, int v, int s)
        {
            // prepare an adj list for the graph
            List<List<int[]>> adj = new List<List<int[]>>(v);

            for (int i = 0; i <= v; i++)
            {
                adj.Add(new List<int[]>());
            }

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                int v1 = graph[i, 0];
                int v2 = graph[i, 1];
                int w = graph[i, 2];

                adj[v1].Add(new int[] { v2, w });
            }

            // We need to have two matrices to maintain cost and directions
            int[] cost = new int[v + 1]; //since we have nodes from 1-n
            int[] dir = new int[v + 1];

            // Since we are doing forward approach using the path[], first we need to find out the distance for each vertex to the tail
            // as we know, to reach n vertex from last stage takes 0, as nth vertex resides in last stage.
            cost[v] = 0;
            dir[v] = v;
            for (int i = v - 1; i >= 1; i--)
            {
                int min = int.MaxValue;
                List<int[]> curr = adj[i];
                for (int k = 0; k < curr.Count; k++)
                {
                    int nextNode = curr[k][0];
                    int currWeight = curr[k][1]; // [7node] = [8node, 5weight] - (7)-----5w---->(8)
                    // curr[k][0] gives the other node that edge is pointing to
                    // curr[k][1] gives the weight
                    // check: if current node weight + cost[next node] < min
                    if (currWeight + cost[nextNode] < min)
                    {
                        min = currWeight + cost[nextNode];
                        dir[i] = nextNode;
                    }
                }
                // Insert the min cost from the current node in the memoization table
                cost[i] = min;
            }

            // Now return the smallest cost path that we can travel from start to end
            // we need an output array that gives the order of vertices to traverse from stage1 to stageN
            // we know the firat and last vertices (1 & v) is are stage (1 & s), so add them to the path array
            int[] path = new int[s + 1];
            path[1] = 1;
            path[s] = v;
            for (int i = 0; i < s; i++)
            {
                path[i] = dir[path[i - 1]]; // path[i-1] gives the direction from the node, dir[x] gives the smallest costed to next stage node
            }

            // cost will be cost[1]
            return dir;
        }
    }
}
