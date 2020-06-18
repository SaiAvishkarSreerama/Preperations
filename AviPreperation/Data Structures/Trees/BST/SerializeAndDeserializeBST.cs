using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trees.BST
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    public class SerializeAndDeserializeBST
    {

        //TC - O(N)
        //SC - O(N)
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
                return "";
            return root.val + "," + serialize(root.left) + "," + serialize(root.right);
        }

        //DESIALIZE USING QUEUE
        public TreeNode deserialize(string data)
        {
            if (data.Length == 0)
                return null;

            string[] arr = data.Split(',');
            Queue<int> queue = new Queue<int>();
            foreach (string s in arr)
            {
                if (s != "")
                    queue.Enqueue(Convert.ToInt32(s));
            }

            return BuildBST(queue, int.MinValue, int.MaxValue);
        }

        public TreeNode BuildBST(Queue<int> q, int lower, int upper)
        {
            if (q.Count == 0)
                return null;

            int val = q.Peek();
            if (val < lower || val > upper)
                return null;
            TreeNode node = new TreeNode(q.Dequeue());
            node.left = BuildBST(q, lower, val);
            node.right = BuildBST(q, val, upper);

            return node;
        }


        //DESIALIZE WITHOUT USING QUEUE
        // Decodes your encoded data to tree.
        // public TreeNode deserialize(string data) {
        //     string[] arr = data.Split(',');
        //     TreeNode root = null;
        //     foreach(string s in arr){
        //         if(s != ""){
        //             root = BuildBST(root, Convert.ToInt32(s));
        //         }
        //     }

        //     return root;
        // }

        // public TreeNode BuildBST(TreeNode root, int val){
        //     if(root == null)
        //         return new TreeNode(val);
        //     if(val < root.val)
        //         root.left = BuildBST(root.left, val);
        //     else
        //         root.right = BuildBST(root.right, val);

        //     return root;
        // }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
