/*
 *  Given the root of a binary tree, return the vertical order traversal of its nodes' values. (i.e., from top to bottom, column by column).
 * If two nodes are in the same row and column, the order should be from left to right.
 * 
 * Example 1:
 * Input: root = [3,9,20,null,null,15,7]
 * Output: [[9],[3,15],[20],[7]]
 * 
 * Example 2:
 * Input: root = [3,9,8,4,0,1,7]
 * Output: [[4],[9],[3,0,1],[8],[7]]
 * 
 * Example 3:
 * Input: root = [1,2,3,4,10,9,11,null,5,null,null,null,null,null,null,null,6]
 * Output: [[4],[2,5],[1,10,9,6],[3],[11]]
 * 
 * Constraints:
 * The number of nodes in the tree is in the range [0, 100].
 * -100 <= Node.val <= 100
 * */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.BinaryTree
{
    [TestClass]
    public class _314_BinaryTreeVerticalOrderTraversal
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        [TestMethod]
        public void Run()
        {
            //           1
            //         /   \
            //        2     3
            //       / \   / \
            //      4   5 6   7
            //     /           \
            //    8             9
            //                 /
            //               10
            // Create all nodes
            TreeNode node1 = new TreeNode(1);
            TreeNode node2 = new TreeNode(2);
            TreeNode node3 = new TreeNode(3);
            TreeNode node4 = new TreeNode(4);
            TreeNode node5 = new TreeNode(5);
            TreeNode node6 = new TreeNode(6);
            TreeNode node7 = new TreeNode(7);
            TreeNode node8 = new TreeNode(8);
            TreeNode node9 = new TreeNode(9);
            TreeNode node10 = new TreeNode(10);

            // Connect nodes to form the tree
            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;
            node4.left = node8;
            node7.right = node9;
            node9.left = node10;

            var path = VerticalOrder(node1);
            path = VerticalOrder_WithOutSorting(node1);
        }

        /// <summary>
        /// Using BFS with Sorted Dictionary
        /// TC - O(nlogn), O(n) for traversal and O(k logk) for sorting dictionary where k is no of columns
        /// SC - O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            SortedDictionary<int, List<int>> columnTable = new SortedDictionary<int, List<int>>();
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();

            queue.Enqueue((root, 0));

            // Built Queue and Dict
            while (queue.Count > 0)
            {
                var (node, index) = queue.Dequeue();

                if (node != null)
                {
                    if (!columnTable.ContainsKey(index))
                    {
                        columnTable[index] = new List<int>();
                    }
                    columnTable[index].Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue((node.left, index - 1));
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue((node.right, index + 1));
                    }
                }
            }

            IList<IList<int>> result = new List<IList<int>>(columnTable.Count());
            foreach (var item in columnTable)
            {
                result.Add(item.Value);
            }

            return result;
        }


        /// <summary>
        /// Using BFS with Sorted Dictionary
        /// TC - O(n), O(n) for traversal
        /// SC - O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> VerticalOrder_WithOutSorting(TreeNode root)
        {
            Dictionary<int, List<int>> columnTable = new Dictionary<int, List<int>>();
            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();

            int min = 0;
            int max = 0;

            queue.Enqueue((root, 0));

            // Built Queue and Dict
            while (queue.Count > 0)
            {
                var (node, index) = queue.Dequeue();

                if (node != null)
                {
                    if (!columnTable.ContainsKey(index))
                    {
                        columnTable[index] = new List<int>();
                    }
                    columnTable[index].Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue((node.left, index - 1));
                        min = Math.Min(min, index - 1);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue((node.right, index + 1));
                        max = Math.Max(max, index + 1);
                    }
                }
            }

            IList<IList<int>> result = new List<IList<int>>(columnTable.Count());
            for (int i = min; i <= max; i++)
            {
                result.Add(columnTable[i]);
            }

            return result;
        }
    }
}
