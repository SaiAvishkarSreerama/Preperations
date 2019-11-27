using System;
using System.Collections.Generic;
using System.Text;

/*
* Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.
*
*Two trees are duplicate if they have the same structure with same node values.
*
*Example 1:
*
*        1
*       / \
*      2   3
*     /   / \
*    4   2   4
*       /
*      4
*The following are two duplicate subtrees:
*
*      2
*     /
*    4
*and
*
*    4
*Therefore, you need to return above trees' root in the form of a list.
*/
namespace AviPreperation.Data_Structures.HashTable
{
  
  //Definition for a binary tree node.
  public class TreeNode
  {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }

    //Usign DFS
    //Time Complexity - O(n^2),  where N is the number of nodes in the tree. We visit each node once, but each creation of serial may take O(N) work.
    //Space Complexity - O(n^2) - size of dictionary
    //public class FindDuplicateNodesSol
    //{

    //    static Dictionary<string, int> d;
    //    static List<TreeNode> list;
    //    public static IList<TreeNode> FindDuplicateSubtrees(TreeNode node)
    //    {
    //        d = new Dictionary<string, int>();
    //        list = new List<TreeNode>();

    //        //DFS Recusrsive function to find all possible trees
    //        Count(node);

    //        return list;
    //    }

    //    //It will return a string of node.val,left,right -using pre order traversal
    //    //if null nodes then node.val,#,# - called serialization of a tree
    //    public static string Count(TreeNode node)
    //    {
    //        if (node == null) return "#";
    //        string key = Count(node.left)  + "," +   node.val + "," + Count(node.right);
    //        if (d.ContainsKey(key))
    //        {
    //            d[key]++;
    //        }
    //        else
    //        {
    //            d.Add(key, 1);
    //        }

    //        if (d[key] == 2)
    //            list.Add(node);

    //        return key;
    //    }

    //    public static void Main()
    //    {
    //        var nodeA = new TreeNode(1);

    //        var nodeB1 = new TreeNode(2);
    //        var nodeB2 = new TreeNode(3);

    //        var nodeC1 = new TreeNode(4);
    //        var nodeC2 = new TreeNode(2);
    //        var nodeC3 = new TreeNode(4);

    //        var nodeD1 = new TreeNode(4);

    //        nodeA.left = nodeB1;
    //        nodeA.right = nodeB2;

    //        nodeB1.left = nodeC1;

    //        nodeB2.left= nodeC2;
    //        nodeB2.right = nodeC3;

    //        nodeC2.left = nodeD1;

    //        FindDuplicateSubtrees(nodeA);
    //    }
    //}





    //Usign DFS
    //Time Complexity - O(n),  where N is the number of nodes in the tree. We visit each node once..
    //Space Complexity - O(n) - Every structure we use is using O(1) storage per node.

    //Explanation:
    /* 1. declare dictionary d, d_count, counter, list(return list)
     * 2. Traverse the node to the end and get the traversal value let say 4,0,0(where 4 is node.val and 0 is if null left ot right)
     * 3. Put the 4,0,0 in d as key and value is counter(intially 0) and then increment for others
     * 4. Now put the value(0) of key(4,0,0) from d into d_count as key and value as 1 intitially(will be incremnt if duplicate comes)
     * 5. Now go to another node, let say 2,(4,0,0), 0 ==> 2,1,0(where 1 is from d whcih is value of 4,0,0), then take its valu and put in d_count as key with counter(1) and ++it;
     * 6. Repeat all, if duplicate happends d_Count will be incrementing its value for that key, after generating key itself check the duplicate in d_count and add to List if any.
     */

    public class FindDuplicateNodesSol
    {

        static Dictionary<string, int> d;
        static Dictionary<int, int> d_Count;
        static List<TreeNode> list;
        static int counter = 0;
        public static IList<TreeNode> FindDuplicateSubtrees(TreeNode node)
        {
            d = new Dictionary<string, int>();
            d_Count = new Dictionary<int, int>();
            list = new List<TreeNode>();

            //DFS Recusrsive function to find all possible trees
            Serialize(node);

            return list;
        }

        public static int Serialize(TreeNode node)
        {
            string key = "";
            if (node == null) 
                key = "0";
            else
            {
                key = node.val + "," + Serialize(node.left) + "," + Serialize(node.right);

                int gen_Id = GenerateIdForKey(key);

                if (d_Count.ContainsKey(gen_Id))
                    d_Count[gen_Id]++;
                else
                    d_Count[gen_Id] = 1;

                if (d_Count[gen_Id] == 2)
                    list.Add(node);
            }

            return GenerateIdForKey(key);
        }

        private static int GenerateIdForKey(string key)
        {
            if (!d.ContainsKey(key))
                d[key] = counter++;

            return d[key];
        }

        //public static void Main()
        //{
        //    var nodeA = new TreeNode(1);

        //    var nodeB1 = new TreeNode(2);
        //    var nodeB2 = new TreeNode(3);

        //    var nodeC1 = new TreeNode(4);
        //    var nodeC2 = new TreeNode(2);
        //    var nodeC3 = new TreeNode(4);

        //    var nodeD1 = new TreeNode(4);

        //    nodeA.left = nodeB1;
        //    nodeA.right = nodeB2;

        //    nodeB1.left = nodeC1;

        //    nodeB2.left = nodeC2;
        //    nodeB2.right = nodeC3;

        //    nodeC2.left = nodeD1;

        //    FindDuplicateSubtrees(nodeA);
        //}
    }
}
