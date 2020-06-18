using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Trees.BST
{
    class Search_Insert_Delete_BST
    {
        /*************************SEARCHING**************************************/
        public class Search_BST_Solution
        {
            //TC - O(N)
            //SC - O(N)
            public TreeNode SearchBST_RECURSION(TreeNode root, int val)
            {
                if (root == null)
                    return null;

                if (root.val == val)
                    return root;

                if (val < root.val)
                    return SearchBST_RECURSION(root.left, val);
                else
                    return SearchBST_RECURSION(root.right, val);
            }

                //TC - O(N)
                //SC - O(1)
            public TreeNode SearchBST_ITERATION(TreeNode root, int val)
            {
                while (root != null)
                {
                    if (val == root.val)
                        return root;
                    if (val < root.val)
                        root = root.left;
                    else
                        root = root.right;
                }
                return null;
            }
        }
        /*************************INSERTION**************************************/
        public class Insert_BST_Solution
        {

            //RECURSION
            //TC- O(logN) or O(H), h is height of the tree
            //SC - O(N)
            public TreeNode InsertIntoBST_RECURSION(TreeNode root, int val)
            {
                if (root == null)
                    return new TreeNode(val);
                if (val > root.val)
                    root.right = InsertIntoBST_RECURSION(root.right, val);
                else
                    root.left = InsertIntoBST_RECURSION(root.left, val);
                return root;
            }


            //ITERATION
            //TC- O(logN) or O(H), h is height of the tree
            //SC - O(1)
            public TreeNode InsertIntoBST_ITERATION(TreeNode root, int val)
            {
                TreeNode cur = root;
                while (cur != null)
                {
                    if (val < cur.val)
                    {
                        if (cur.left == null)
                        {
                            cur.left = new TreeNode(val);
                            return root;
                        }
                        else
                            cur = cur.left;
                    }
                    else
                    {
                        if (cur.right == null)
                        {
                            cur.right = new TreeNode(val);
                            return root;
                        }
                        else
                            cur = cur.right;
                    }-
                }

                return new TreeNode(val);
            }
        }
        /*************************DELETION**************************************/
        public class DELETE_BST_Solution
        {
            //TC - O(logN)
            //SC - O(H)
            public TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null)
                    return root;

                if (key < root.val)
                    root.left = DeleteNode(root.left, key);
                else if (key > root.val)
                    root.right = DeleteNode(root.right, key);
                else
                {
                    if (root.left == null && root.right == null)
                        root = null;
                    else if (root.right != null)
                    {
                        root.val = Successor(root);
                        root.right = DeleteNode(root.right, root.val);
                    }
                    else
                    {
                        root.val = Predecessor(root);
                        root.left = DeleteNode(root.left, root.val);
                    }
                }

                return root;
            }

            public int Successor(TreeNode node)
            {
                node = node.right;
                while (node.left != null)
                    node = node.left;
                return node.val;
            }

            public int Predecessor(TreeNode node)
            {
                node = node.left;
                while (node.right != null)
                    node = node.right;
                return node.val;
            }
        }
    }
    }
