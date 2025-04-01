/*
 * PRIM's method states that a min cost of the spanning tree can be achieved by stating from a min weight edge and traversing through the connected min weight edges only.
 * Using Adjaceny Array the TC and SC takes O(V^2) andd O(V)
 * Using Adjacency list the TC and SC comes down to O((V+E)* logV) and O(V + E)
 * 
 * Explanation:
 * 1. Get the length of the matrix v = graph.GetLength(0);
 * 2. Declare three matrices of size v, and intialize with int.MaxValues and false.
 *      1. Parent[] - to maintian the parent node of current node
 *      2. Key[] - To maintain the current node smallest value 
 *      3. Visited - To note the already visited nodes
 *  3. Lets start from 0-node, parent[0]=-1, key[0] = 0;
 *  4. Iterate the graph from [0 - 8] nodes
 *      1. Get the minValueIndex - intially we have key[0] = 0 < int.MaxValue, now minIndex is 0, which means we are at 0 node
 *      2. iterate j=0-8 numbers for 0node, with these 3 conditions
 *          a. graph[minIndex,j] != 0
 *          b. visited[j] != true
 *          c. graph[minIndex, j] < key[j], it must be less than already visited value
 *      3. then update parent as minIndex, and now we have even less value, so update key[j] = graphValue.
 *  5. Done
 *      Note: MinIndex will be 0-8, not consecutively, for each row, we iterate from 0-8 column and when a num found we compare it with key[] and if less then
 *          we consider the minValue as that value and minIndex that index. If found at col2, still we iterate till col-8 and we dont know if we can find at col8 also
 **/

namespace PreperationsTest.Algorithms.GreedyMethods.Prims_MinSpanningTree
{
    [TestClass]
    public class MinimumSpanningTree_Prims_AdjMatrix
    {

        [TestMethod]
        public void Run()
        {
            //int[,] graph = new int[,]{{ 0, 2, 0, 6, 0 },
            //                          { 2, 0, 3, 8, 5 },
            //                          { 0, 3, 0, 0, 7 },
            //                          { 6, 8, 0, 0, 9 },
            //                          { 0, 5, 7, 9, 0} };


            // Graph can be seen like here: https://www.geeksforgeeks.org/kruskals-minimum-spanning-tree-algorithm-greedy-algo-2/
            int[,] graph = new int[,]{{ 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 }};

            // OUTPUT FOR ABOVE EXAMPLE
            /* 
             * 0 - 1 = 4
             * 1 - 2 = 8
             * 2 - 3 = 7
             * 2 - 8 = 2
             * 2 - 5 = 4
             * 3 - 4 = 9
             * 5 - 6 = 2
             * 6 - 7 = 1             
             */

            Prims_MinSpanningTree_AdjacencyArrays(graph);
        }

        public void Prims_MinSpanningTree_AdjacencyArrays(int[,] graph)
        {
            // As we know the lenght of the 2D matrix gives the no of vertices(rows/Columns)
            // matrix values denotes the weights of the edges
            int v = graph.GetLength(0);

            // we need three array to mainitan the visitedNodes, Values and parents
            int[] parent = new int[v];
            int[] key = new int[v]; // used to pick min weight edge
            bool[] visited = new bool[v];

            //Initialte the visited and weights with default values
            for (int i = 0; i < v; i++)
            {
                key[i] = int.MaxValue;
                visited[i] = false;
            }

            // always start with the 0 node as we consider it as a root node of the graph
            key[0] = 0;
            parent[0] = -1;

            // traverse the matrix rows and columns 
            // which means we are traversing the nodes and the edges
            for (int i = 0; i < v - 1; i++)
            {
                // Get the minValue of the connected edges of current node
                int currentNode = ConnectedMinimumVertexIndex(key, visited);

                // since we are visiting this node, we make it true
                visited[currentNode] = true;

                for (int node = 0; node < v; node++)
                {
                    int graphValue = graph[currentNode, node];
                    // if weight != 0
                    // if not visited
                    // 
                    if (graphValue != 0 && !visited[node] && graphValue < key[node])
                    {
                        parent[node] = currentNode;
                        key[node] = graphValue;
                    }
                }
            }

            // Iterate Key[] and add the result and return, which will be the MST value
        }

        /// <summary>
        /// To find the vertex with minimum key value, from the set of vertices not yet included in MST
        /// For 0 - 8 (let say we have 9x9 matrix)
        ///     check for each v, key[v] < minValue (intially minValue is int.MaxValue)
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public int ConnectedMinimumVertexIndex(int[] key, bool[] visited)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < visited.Length; v++)
            {
                if (!visited[v] && key[v] < minValue)
                {
                    minValue = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }
}
