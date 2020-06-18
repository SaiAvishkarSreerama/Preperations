using System;
using System.Collections.Generic;
using System.Text;
/*You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:
* 
* struct Node1 {
*   int val;
*   Node1 *left;
*   Node1 *right;
*   Node1 *next;
* }
* Populate each next pointer to point to its next right Node1. If there is no next right Node1, the next pointer should be set to NULL.
* 
* Initially, all next pointers are set to NULL.
* 
* Follow up:
* *************You may only use constant extra space.
* Recursive approach is fine, you may assume implicit stack space does not count as extra space for this problem.
*  
* Example 1:
* Input: root = [1,2,3,4,5,6,7]
* Output: [1,#,2,3,#,4,5,6,7,#]
* Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right Node1, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.
* 
* Constraints:
* The number of Node1s in the given tree is less than 4096.
* -1000 <= Node1.val <= 1000
* */
namespace AviPreperation.Data_Structures.Trees
{
    /**************************************II- Perfect Binary Tree(No missing Nodes)********************************************************/

    // Definition for a Node1.
    public class Node1 {
        public int val;
        public Node1 left;
        public Node1 right;
        public Node1 next;

        public Node1() {}

        public Node1(int _val) {
            val = _val;
        }

        public Node1(int _val, Node1 _left, Node1 _right, Node1 _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class PopulatingNextRightPointerInEachNode1Solution
    {
        //TC - O(N)
        //SC - O(N)
        //USING BFS Level ORDER
        public Node1 Connect(Node1 root)
        {
            if (root == null)
                return root;

            Queue<Node1> q = new Queue<Node1>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Node1 Node1 = q.Dequeue();

                    if (i < size - 1)//i should be less than size to access the same level Node1s in the q
                        Node1.next = q.Peek();

                    if (Node1.left != null)
                        q.Enqueue(Node1.left);
                    if (Node1.right != null)
                        q.Enqueue(Node1.right);
                }
            }

            return root;
        }

        //TC - O(N)
        //SC - O(1), no space
        public Node1 Connect2(Node1 root)
        {
            if (root == null)
                return root;

            Node1 leftMost = root;
            while (leftMost.left != null)
            {
                Node1 head = leftMost;
                while (head != null)
                {

                    //Condition 1: for two childs of same parent Node1
                    head.left.next = head.right;

                    //condition 2: right child of Node11 and left child of Node11's sibling(Node12)
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }

                    head = head.next;
                }
                leftMost = leftMost.left;
            }

            return root;
        }


        /**************************************II- Binary Tree with missing Nodes********************************************************/
        //TC - O(N)
        //SC - O(N)
        //USING BFS Level ORDER
        //SAME AS Connect above, useing q and adding connection of the Dequeue nodes


        //TC - O(N)
        //SC - O(1)
        public Node1 ConnectII_I(Node1 root)
        {
            if (root == null)
                return root;
            //head node for return purpose only
            Node1 head = root;

            //dummy will maintain the child level order connections
            Node1 dummy = new Node1(0);
            Node1 pre = dummy;

            //processing on root
            while (root != null)
            {
                //if left exists then add it to pre 
                if (root.left != null)
                {
                    pre.next = root.left;
                    pre = pre.next;
                }
                //if right exists add it to the pre whcih alreay have left init
                if (root.right != null)
                {
                    pre.next = root.right;
                    pre = pre.next;
                }
                root = root.next;
                //if root is null which means the that level is end, so move root to next node of dummy(make null)
                if (root == null)
                {
                    //reset all
                    pre = dummy;
                    root = dummy.next;
                    dummy.next = null;
                }
            }
            return head;
        }
    }
}
