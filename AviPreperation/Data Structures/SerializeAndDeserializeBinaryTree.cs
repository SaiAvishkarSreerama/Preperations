using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
 
     //Definition for a binary tree node.
     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
     }
    public class SerializeAndDeserializeBinaryTree
    {

        // Encodes a tree to a single string.
        //RECURSIVE
        public string serialize_RECURSIVE(TreeNode root)
        {
            if (root == null)
                return "X";
            string serial = root.val + "," + serialize_RECURSIVE(root.left) + "," + serialize_RECURSIVE(root.right);
            return serial;
        }

        //***********OR***********

        //ITERATIVE
        public string serialize_ITERATIVE(TreeNode root)
        {
            if (root == null)
                return null;
            StringBuilder sb = new StringBuilder();
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);

            while (s.Count > 0)
            {
                TreeNode node = s.Pop();
                string val = (node == null) ? "X" : node.val.ToString();
                sb.Append(val);
                sb.Append(",");

                if (node != null)
                    s.Push(node.right);

                if (node != null)
                    s.Push(node.left);
            }

            return sb.ToString();
        }

        //OUTPUT OF SERIALIZE METHOD IS PASSING AS A PARAMETER TO DESERIALIZE AS DATA
        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            Queue<string> q = new Queue<string>();
            string[] s = data.Split(',');
            for (int i = 0; i < s.Length; i++)
            {
                q.Enqueue(s[i]);
            }
            return deserialize_Helper(q);
        }

        public TreeNode deserialize_Helper(Queue<string> q)
        {
            string nodeVal = q.Dequeue();
            if (nodeVal == "X")
                return null;
            TreeNode newNode = new TreeNode(Convert.ToInt32(nodeVal));
            newNode.left = deserialize_Helper(q);
            newNode.right = deserialize_Helper(q);

            return newNode;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
