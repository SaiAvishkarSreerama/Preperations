using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trees
{
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
public class EncodeN_aryTreeToBinaryTreeCodec
    {
        //TC - O(N), no of nodes of N-ary tree
        //SC - O(D), depth of the N-ary tree
        // Encodes an n-ary tree to a binary tree.
        public TreeNode encode(Node root)
        {
            if (root == null)
                return null;

            //put left to root
            TreeNode newRoot = new TreeNode(root.val);
            if (root.children.Count > 0)
            {
                newRoot.left = encode(root.children[0]);
            }

            //put right to root.lefts
            TreeNode node = newRoot.left;
            for (int i = 1; i < root.children.Count; i++)
            {
                node.right = encode(root.children[i]);
                node = node.right;
            }

            return newRoot;
        }

        // Decodes your binary tree to an n-ary tree.
        public Node decode(TreeNode root)
        {
            if (root == null)
                return null;

            Node newRoot = new Node(root.val, new List<Node>());
            TreeNode node = root.left;
            while (node != null)
            {
                newRoot.children.Add(decode(node));
                node = node.right;
            }

            return newRoot;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(root));
}
