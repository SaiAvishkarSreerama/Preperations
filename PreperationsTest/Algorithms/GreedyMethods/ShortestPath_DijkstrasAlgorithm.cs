/*
 * Explanation:
 *  1. start from the starting Index, here 0 in our example
 *  2. we need a priority queue and an array for distances dist[] from 0
 *  3. Initially push 0node and its weight 0 into pq.
 *  4. Iterate pq untill is empty
 *  5. Dequeue the pq, that gives the current Node(let say u), first 0 here
 *  6. Get the connected nodes (v-node) and weight from the graph of u-node
 *  7. If u-node value + weight to vNode < vNode value, then update vNode value with this shortest value, in dist[]
 *  8. Enqueue this vnode value, vnode to pq
 *  
 *  Graph Implementation:
 *      1. Use adjacency list list<>[] with Tuple<int, int> type, so we can get (weight and node) for each node
 *      2. AddEdge will add adj[u] => new List<Tuple(v, wt)>();
 *  
 *  Priority queue Implementation ( Is called Fibonnaci heap - decrease-key operations happens here when finding a new shortest path and updating it)
 *      1. Use Tuple<int, int> type with comparer, as we need to heapify when each enqueue/dequeue the (wt, node)
 *      
 *   TC - O ((V+ E) LogV) https://www.geeksforgeeks.org/time-and-space-complexity-of-dijkstras-algorithm/ 
 *   SC - O(V)
 *   TC for Adj array - O(V^2)
 */

namespace PreperationsTest.Algorithms.GreedyMethods
{
    [TestClass]
    public class ShortestPath_DijkstrasAlgorithm
    {
        [TestMethod]
        public void Run()
        {
            int v = 7;

            // Graph is a 2D int[,] matrix, have AddEdge, RemoveEdge and Count methods
            Graph graph = new Graph(v);

            // Graph representation here: https://www.geeksforgeeks.org/introduction-to-dijkstras-shortest-path-algorithm/?ref=header_outind
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 6);
            graph.AddEdge(1, 3, 5);
            graph.AddEdge(2, 3, 8);
            graph.AddEdge(3, 4, 10);
            graph.AddEdge(3, 5, 15);
            graph.AddEdge(4, 6, 2);
            graph.AddEdge(5, 6, 6);

            // Nodes [0 1 2 3 4  5  6]
            // Dist: [0 2 6 7 17 22 19]
            ShortestPath(graph, 0, v);
        }

        #region Graph Implementaion with Adjacency list
        public class Graph
        {
            public List<Tuple<int, int>>[] adj { get; set; }

            public Graph(int v)
            {
                adj = new List<Tuple<int, int>>[v];
                for (int i = 0; i < v; i++)
                {
                    adj[i] = new List<Tuple<int, int>>();
                }
            }

            public void AddEdge(int v1, int v2, int wt)
            {
                adj[v1].Add(Tuple.Create(v2, wt));
                adj[v2].Add(Tuple.Create(v1, wt));
            }
        }
        #endregion

        #region Priority queue implementation with Tuple
        /// <summary>
        ///  Fibonnaci heap 
        ///  A Fibonacci heap is a more complex data structure that consists of a collection of trees satisfying the heap property. 
        ///  It is designed to improve the performance of certain operations, particularly the decrease-key operation, which is crucial for algorithms like Dijkstra's and Prim's.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T>
        {
            private List<T> _data { get; set; }
            private Comparison<T> _compare;

            // Constructors chaining: One constr calls other constr to avoid duplicate code
            // This is the default constructor
            public PriorityQueue() : this(Comparer<T>.Default) { }
            public PriorityQueue(IComparer<T> comparer) : this(comparer.Compare) { }
            public PriorityQueue(Comparison<T> comparison)
            {
                _data = new List<T>();
                _compare = comparison;
            }

            public void Enqueue(T item)
            {
                _data.Add(item);
                int currentIndex = _data.Count - 1;

                int parentIndex = currentIndex - 1 / 2;
                while (currentIndex > 0 && _compare(_data[parentIndex], _data[currentIndex]) < 0)
                {
                    Swap(parentIndex, currentIndex);
                    currentIndex = parentIndex;
                }
            }

            public T Dequeue()
            {
                // remove the first node and replace with leaf node
                T firstNodeValue = _data[0];
                _data[0] = _data[Count - 1];
                _data.RemoveAt(Count - 1);

                int parentIndex = 0;
                int lastIndex = _data.Count - 1;
                while (true)
                {
                    int leftIndex = 2 * parentIndex + 1;
                    int rightIndex = 2 * parentIndex + 2;

                    // Condition to break the true loop
                    // 1. any childIndex> lastIndex
                    // 2. parent < child (right-left compare small one)
                    if (leftIndex > lastIndex)
                        break;

                    if (rightIndex <= lastIndex &&
                        _compare(_data[rightIndex], _data[leftIndex]) < 0) // compare right & left, right>left, then use left variable for using right
                    {
                        leftIndex = rightIndex;
                    }

                    if (_compare(_data[parentIndex], _data[rightIndex]) <= 0)  // Comparer(a,b) < means a > b; 
                        break;
                    Swap(parentIndex, rightIndex);
                    parentIndex = rightIndex;
                }

                return firstNodeValue;
            }

            public T Peek()
            {
                return _data[0];
            }

            public int Count => _data.Count;

            public void Swap(int i, int j)
            {
                T temp = _data[i];
                _data[i] = _data[j];
                _data[j] = temp;
            }

        }
        #endregion


        public void ShortestPath(Graph graph, int startingVertex, int vertices)
        {
            PriorityQueue<Tuple<int, int>> pq = new PriorityQueue<Tuple<int, int>>();
            pq.Enqueue(Tuple.Create(0, startingVertex));

            int[] nodeDistances = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                nodeDistances[i] = int.MaxValue; //[INF, INF, INF, INF, INF, INF]
            }
            nodeDistances[startingVertex] = 0; //[0, INF, INF, INF, INF, INF,]

            while (pq.Count > 0)
            {
                var u = pq.Dequeue().Item2; //Item2 is the Node, Item1 is weight for pq

                foreach (var g in graph.adj[u])//Item1 is Node, Item2 is weight for adj graph
                {
                    int v = g.Item1;
                    int wt = g.Item2;
                    int distaceFromUtoV = nodeDistances[u] + wt;

                    if (distaceFromUtoV < nodeDistances[v]) // (u, {1})-----2---->(v) then v = 1+2 = 3, but v is alreay 5 then 3 is the shortest
                    {
                        nodeDistances[v] = distaceFromUtoV;
                        pq.Enqueue(Tuple.Create(nodeDistances[v], v));
                    }
                }
            }
        }
    }
}
