using System;

namespace btreeUpsideDown
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("binary tree upside down");
        }
    }
    /**
     * Definition for a binary tree node.
     */
     public class TreeNode {
         public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int x) { val = x; }
     }
     
    public class Solution {
        public TreeNode UpsideDownBinaryTree(TreeNode root) {
            if (root == null || root.left == null) return root;
            TreeNode l = root.left, r = root.right;
            TreeNode res = UpsideDownBinaryTree(l);
            l.left = r;
            l.right = root;
            root.left = null;
            root.right = null;
            return res;
        }
    }
}
