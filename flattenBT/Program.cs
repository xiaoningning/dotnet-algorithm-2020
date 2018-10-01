using System;

namespace flattenBT
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();   
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.right = new TreeNode(3);
            root.right = new TreeNode(4);
            obj.Flatten(root);
            Console.WriteLine("flattern binary tree");
            while (root != null){
                Console.WriteLine("{0} ", root.val);
                root = root.right;
            }
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
        private TreeNode prev;
        public void Flatten(TreeNode root) {
            if (root == null) return;
            // flatten right first
            // then link back to left.right
            // then link left to root.right
            Flatten(root.right);        
            Flatten(root.left);
            root.right = prev;
            root.left = null;
            prev = root;        
        }
    }
}
