using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Recursion
{
    class SameTree
    {
        //Check if Two binary trees are identical
        //     //RECURSION
        //     //TimeComplexity - O(n^2)
        //     //SpaceComplexity - O(n^2)
        public bool IsSameTreeRECURSION(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            if (p.val != q.val)
                return false;

            return IsSameTreeRECURSION(p.left, q.left) && IsSameTreeRECURSION(p.right, q.right);
        }

        //TimeComplexity - O(m+n)
        //SpaceComplexity -O(m+n)
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            List<int> plist = new List<int>();
            List<int> qlist = new List<int>();
            ConvertToList(p, plist);//converting a treenode to list using preorder, do not use inorder
            ConvertToList(q, qlist);//same

            //if the list lengths are diff, whcih means the trees are different
            if (plist.Count != qlist.Count)
                return false;

            //comparing both results
            for (int i = 0; i < plist.Count; i++)
            {
                if (plist[i] != qlist[i])
                    return false;
            }

            return true;
        }

        //Here using inorder is a bad example where it is failing to find [root,left,right]==>[1,null,1] and [1,1,null]
        //Using PreOrder
        public void ConvertToList(TreeNode root, List<int> list)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                root = stack.Pop();
                list.Add(root == null ? 0 : root.val);

                if (root != null)
                {
                    stack.Push(root.right);
                    stack.Push(root.left);
                }
            }
        }
    }
}
