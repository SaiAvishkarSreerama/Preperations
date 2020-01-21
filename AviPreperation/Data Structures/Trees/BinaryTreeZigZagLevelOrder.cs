using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Trees
{
    class BinaryTreeZigZagLevelOrder
    {
        //APPROACH - 1
        //Same as Level Order traversal using DFS RECURSION, just reversing the values of the lists at end
        //TC - O(n)
        //SC - O(n)
        public IList<IList<int>> ZigzagLevelOrder1(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            helper1(root, res, 0);

            for (int i = 1; i < res.Count; i += 2)
            {
                res[i] = res[i].Reverse().ToList();
            }
            return res;
        }

        public void helper1(TreeNode node, List<IList<int>> res, int level)
        {
            if (node == null)
                return;

            if (res.Count <= level)
            {
                res.Add(new List<int>());
            }

            res[level].Add(node.val);

            helper1(node.left, res, level + 1);
            helper1(node.right, res, level + 1);
        }

        //APPROACH - 2, 
        //Same as above approach, but instead of reversing at last, during list.add only we re adding at front
        //TC - O(n)
        //SC - O(n)
        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            helper(root, res, 0);
            return res;
        }

        public void helper(TreeNode node, List<IList<int>> res, int level)
        {
            if (node == null)
                return;

            if (res.Count <= level)
            {
                res.Add(new List<int>());
            }

            if (level % 2 == 0)
                res[level].Add(node.val);
            else
                res[level].Insert(0, node.val);

            helper(node.left, res, level + 1);
            helper(node.right, res, level + 1);
        }

        //APPROACH - 3 
        //Same as above approach, but instead of reversing at last, during list.add only we re adding at front
        //TC - O(n)
        //SC - O(n)
        public IList<IList<int>> ZigzagLevelOrder3(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int size = q.Count;
                List<int> row = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = q.Dequeue();

                    if (res.Count % 2 == 0)
                    {
                        row.Add(node.val);
                    }
                    else
                    {
                        row.Insert(0, node.val);
                    }

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }

                res.Add(row);
            }
            return res;
        }
    }
}
