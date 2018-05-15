using System;

namespace validBST
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            var obj = new Solution();
            Console.WriteLine("valid BST {0}", obj.IsValidBST(root));
        }

        public class Solution {
            public bool IsValidBST(TreeNode root) {
                return IsValidBST(root, Int64.MinValue, Int64.MaxValue);
            }
            // change int to long for the border case of int32
            bool IsValidBST(TreeNode node, long min, long max){
                if(node == null) return true;
                if(node.val <= min || node.val >= max) return false;
                return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
            }
        }
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
