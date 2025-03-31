/*
 * PRIM's method states that a min cost of the spanning tree can be achieved by stating from a min weight edge and traversing through the connected min weight edges only.
 * Using Adjaceny Array the TC and SC takes O(V^2) andd O(V)
 * Using Adjacency list the TC and SC comes down to O((V+E)* logV) and O(V + E)
 **/

namespace PreperationsTest.Algorithms.DivideAndConquer
{
    [TestClass]
    public class MinimumSpanningTree_Prim_s
    {

        [TestMethod]
        public void Run()
        {
            int[,] graph = new int[,]{{ 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0} };

            Prims_MinSpanningTree(graph);
        }

        public void Prims_MinSpanningTree(int[,] graph)
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
        }

        /// <summary>
        /// To find the vertex with minimum key value, from the set of vertices not yet included in MST
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
