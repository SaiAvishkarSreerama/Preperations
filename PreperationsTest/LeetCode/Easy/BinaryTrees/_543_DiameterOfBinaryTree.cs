/*
 * Given the root of a binary tree, return the length of the diameter of the tree.
 * The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.
 * The length of a path between two nodes is represented by the number of edges between them.
 * Example 1:
 * Input: root = [1,2,3,4,5]
 * Output: 3
 * Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
 * 
 * Example 2:
 * Input: root = [1,2]
 * Output: 1
 * 
 * Constraints:
 * The number of nodes in the tree is in the range [1, 104].
 * -100 <= Node.val <= 100
 * 
 *  Continuation - Return the diameter path
 */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Easy.BinaryTrees
{
    [TestClass]
    public class _543_DiameterOfBinaryTree
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
            node7.left = node9;
            node9.left = node10;

            int diameter = DiameterOfBinaryTree(node1);
            int[] path = DiameterPathOfBinaryTree(node1);
        }

        #region Diameter
        public int diameter { get; set; }
        public int DiameterOfBinaryTree(TreeNode root)
        {
            diameter = 0;
            Depth(root);
            return diameter;
        }

        /// <summary>
        /// TC - O(N), each node visited exactly once
        /// SC - O(N), max depth of the recursion stack, in worst case n
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int Depth(TreeNode node)
        {
            // base case
            // when we are at leaf node, return 0 as nothing to traverse
            if (node == null)
            {
                return 0;
            }

            // traverse left and right
            int leftDepth = Depth(node.left);
            int rightDepth = Depth(node.right);

            // now we have left and right depths
            // Update diameter if their combined length is higher
            diameter = Math.Max(diameter, leftDepth + rightDepth);

            // return the max depth from left/right including that node
            return Math.Max(leftDepth, rightDepth) + 1;
        }
        #endregion

        #region Diameter Path
        
        List<int> longestDiaPath = new List<int>();
        public int[] DiameterPathOfBinaryTree(TreeNode root)
        {
            diameter = 0;
            DFS(root);
            return longestDiaPath.ToArray();
        }

        // TC - O(N), traversing each node once
        // SC - O(N), if balanced tree - O(logn), worst case -O(n)
        public List<int> DFS(TreeNode node)
        {
            // base case, return if at leaf nodes
            if(node == null)
            {
                return new List<int>();
            }

            // Get the left and right depth nodes list
            List<int> leftDepth = DFS(node.left);
            List<int> rightDepth = DFS(node.right);

            // only when curr Diamerer is large
            int currDiameter = leftDepth.Count + rightDepth.Count;
            if( currDiameter > diameter)
            {
                diameter = currDiameter;

                // prepare the list using left and right depth values
                List<int> path = new List<int>(leftDepth);
                path.Reverse();
                path.AddRange(rightDepth);

                // now add this to global path variable
                longestDiaPath = path;
            }

            // final case: return the longest path among left and right
            if (leftDepth.Count > rightDepth.Count)
            {
                leftDepth.Add(node.val);
                return leftDepth;
            }
            else
            {
                rightDepth.Add(node.val);
                return rightDepth;
            }
        }
        #endregion
    }
}
