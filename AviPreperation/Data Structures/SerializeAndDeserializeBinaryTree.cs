using System;
using System.Collections.Generic;
using System.Text;
/*
* Serialization is the process of converting a data structure or object into a sequence of bits so that it can be
* stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
* 
* Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization
* algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized 
* to the original tree structure.
* 
* Example: 
* 
* You may serialize the following tree:
* 
*     1
*    / \
*   2   3
*      / \
*     4   5
* 
* as "[1,2,3,null,null,4,5]"
* Clarification: The above format is the same as how LeetCode serializes a binary tree. You do not necessarily need to follow this format, 
* so please be creative and come up with different approaches yourself.
* 
* Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless. 
*/
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
