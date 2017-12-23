using System;

namespace LCABinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input is in the code");
            TreeNode root = new TreeNode(1);
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(3);
            root.left = p;
            p.right = q;
            Console.WriteLine("LCA: {0}", LowestCommonAncestor(root, p, q).val);
        }

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || root == p || root == q) return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            return left == null ? right : right == null ? left : root;
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
