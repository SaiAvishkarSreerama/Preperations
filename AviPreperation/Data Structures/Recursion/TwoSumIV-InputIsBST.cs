using System;
using System.Collections.Generic;
using System.Text;

/*Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.
* 
* Example 1:
* 
* Input: 
*     5
*    / \
*   3   6
*  / \   \
* 2   4   7
* 
* Target = 9
* 
* Output: True
*  
* 
* Example 2:
* 
* Input: 
*     5
*    / \
*   3   6
*  / \   \
* 2   4   7
* 
* Target = 28
* 
* Output: False
**/
namespace AviPreperation.Data_Structures.Recursion
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
    public class TwoSumIVSolution
    {

        //Approach1
        //Time Complexity - O(N)
        //Space Complexity - O(N)
        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> h = new HashSet<int>();
            return helper(root, k, h);
        }

        public bool helper(TreeNode node, int k, HashSet<int> h)
        {
            if (node == null)
                return false;

            if (h.Contains(k - node.val))
                return true;

            h.Add(node.val);

            return helper(node.left, k, h) || helper(node.right, k, h);
        }

        //Approach 2: Do inorder and iterate the List  by two pointer
        //Approach 3: Do BFS, add value in Queue, iterate till Q empty, if Q.Dequeue() value != null then check 
        // k-nodeVal is in HashSet return true, add val in hashset, and add right and left in Q

    }

}
