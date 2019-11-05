using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Queues
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node() { }
        public Node(int _val, IList<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
        public class CloneGraphSolution
        {
            public Node CloneGraph(Node node)
            {
                //Edge case scenario
                if (node == null)
                    return null;

                //Since Nodes are being traversed and copied, we are using BFS
                //Need a Queue 
                Queue<Node> q = new Queue<Node>();
                //Hashtable or dictionary is required to store the key value pair
                Dictionary<Node, Node> d = new Dictionary<Node, Node>();

                //initial node
                Node result = new Node(node.val, new List<Node>());

                //add the node to the queue, add the {val,node} to dictionary
                q.Enqueue(node);
                d.Add(node, result);

                //iterate till q becomes empty
                while (q.Count > 0)
                {
                    //remove the node from q
                    Node cur = q.Dequeue();
                    //we re finding the neighbors of the current node which is already in dictionary
                    result = d[cur];

                    foreach (Node neighbor in cur.neighbors)
                    {
                        Node newNeighbor = null;
                        //if the neighbor is not existd in dictionary
                        if (!d.ContainsKey(neighbor))
                        {
                            //push to q
                            q.Enqueue(neighbor);
                            //add to dictionary, which requires {val, node}, val is neighbor val, but node of neighbor is yet to find so new Node
                            newNeighbor = new Node(neighbor.val, new List<Node>());
                            d.Add(neighbor, newNeighbor);
                        }
                        else
                        {
                            //since the neighbor is already existed in the dictionary
                            //so we need to add that neighbor key as value to the cur node
                            newNeighbor = d[neighbor];
                        }
                        //add the neighbor to the cur node's neighbor
                        result.neighbors.Add(newNeighbor);
                    }
                }
                return d[node];
            }
        }
    }
}
