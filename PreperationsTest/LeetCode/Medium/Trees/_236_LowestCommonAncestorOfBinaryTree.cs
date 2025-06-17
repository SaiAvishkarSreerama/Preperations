/*
 * Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.
 * According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes p and q as the lowest node in T 
 * that has both p and q as descendants (where we allow a node to be a descendant of itself).”
 * 
 * Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
 * Output: 3
 * Explanation: The LCA of nodes 5 and 1 is 3.
 */

namespace PreperationsTest.LeetCode.Medium.Trees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    [TestClass]
    public class _236_LowestCommonAncestorOfBinaryTree
    {
        [TestMethod]
        public void Run()
        {
            TreeNode node3 = new TreeNode(3);
            TreeNode node5 = new TreeNode(5);
            TreeNode node1 = new TreeNode(1);
            TreeNode node6 = new TreeNode(6);
            TreeNode node2 = new TreeNode(2);
            TreeNode node0 = new TreeNode(0);
            TreeNode node8 = new TreeNode(8);
            TreeNode node7 = new TreeNode(7);
            TreeNode node4 = new TreeNode(4);

            // Connect nodes
            node3.left = node5;
            node3.right = node1;

            node5.left = node6;
            node5.right = node2;

            node1.left = node0;
            node1.right = node8;

            node2.left = node7;
            node2.right = node4;

            // node3 is the root of the tree
            TreeNode root = node3;

            TreeNode lca = LowestCommonAncestor(root, node6, node4);
        }

        // TC - O(N), traversing all nodes in the iterations
        // SC - O(N), N for stack, N for dictionary and N for Set, total would be 3N~= O(N)
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // traversalStack
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            // node-Parent dictionary
            Dictionary<TreeNode, TreeNode> dict = new Dictionary<TreeNode, TreeNode>();
            dict.Add(root, null);

            // traverse from root to all nodes and push root-parentNode to dictionary
            // Push untill both p and q are found
            while (!dict.ContainsKey(p) || !dict.ContainsKey(q))
            {
                // get the current node from stack
                TreeNode curr = stack.Pop();

                if (curr.left != null)
                {
                    stack.Push(curr.left);
                    dict.Add(curr.left, curr);
                }

                if (curr.right != null)
                {
                    stack.Push(curr.right);
                    dict.Add(curr.right, curr);
                }
            }

            // Now we have all nodes and its parent in the dictionary
            // Now traverse from p to root and get all its parent(ancestors) nodes.
            HashSet<TreeNode> set = new HashSet<TreeNode>();
            while (p != null)
            {
                set.Add(p);
                p = dict[p]; //move to parent
            }

            // Now traverse q and check is we find itself or any of the ancestors in set.
            while (!set.Contains(q))
            {
                q = dict[q];
            }

            return q; //here q is the first ancestor we find in set
        }
    }
}
