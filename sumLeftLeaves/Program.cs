using System;

namespace sumLeftLeaves
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            Console.WriteLine("sum of left leaves: {0}", SumOfLeftLeaves(root));            
        }
        static int SumOfLeftLeaves(TreeNode root) {        
            int res = DFS(root, false);
            return res;
        }
        static int DFS(TreeNode root, bool isLeft){
            if(root == null) return 0;
            if(root.left == null && root.right == null && isLeft) return root.val;
            return DFS(root.left, true) + DFS(root.right, false);        
        }
    }
    public class TreeNode {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
    }
}
