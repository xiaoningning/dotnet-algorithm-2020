using System;

namespace LCABinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input is in the code");
            TreeNode root = new TreeNode(6);
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(8);
            TreeNode tn1 = new TreeNode(4);            
            TreeNode tn2 = new TreeNode(3);            
            root.left = p;
            root.right = q;
            q.right = tn1;
            tn1.left = tn2;
            Console.WriteLine("LCA: {0}", LowestCommonAncestor1(root, p, tn2).val);
        }

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || root == p || root == q) return root;
            while((root.val - p.val) * (root.val - q.val) > 0){
                root = p.val < root.val ? root.left : root.right;
            }
            return root;
        }

        static TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || root == p || root == q) return root;
            if (root.val > Math.Max(p.val, q.val)) 
                return LowestCommonAncestor1(root.left, p, q);
            else if (root.val < Math.Min(p.val, q.val)) 
                return LowestCommonAncestor1(root.right, p, q);
            else return root;            
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
