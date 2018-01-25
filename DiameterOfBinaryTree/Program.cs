using System;

namespace DiameterOfBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The tree input is hard coded.");            
                        TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            Console.WriteLine("diameter of tree:{0}", DiameterOfBinaryTree(root));
        }

        static int res;
        static int DiameterOfBinaryTree(TreeNode root) {
            res = 0;
            GetDepth(root);
            return res;
        }

        static int GetDepth(TreeNode t){
            if (t == null) return 0;
            int left = GetDepth(t.left);
            int right = GetDepth(t.right);
            res = Math.Max(res, left + right + 1);
            return Math.Max(left, right) + 1;
        }

    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
