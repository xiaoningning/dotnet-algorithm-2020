using System;

namespace IsSubtree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The tree input is hard coded.");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(4);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(2);
            
            TreeNode subTree = new TreeNode(4);
            subTree.left = new TreeNode(1);
            subTree.right = new TreeNode(2);
            Console.WriteLine("is subtree: {0}", IsSubtree1(root, subTree));
        }
        
        static bool IsSubtree(TreeNode s, TreeNode t) {
            if (s == null) return false;
            if (IsSame(s, t)) return true;
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        static bool IsSame(TreeNode t1, TreeNode t2){
            if (t1 == null && t2 == null) return true;
            if ((t1 != null && t2 == null) || (t1 == null && t2 != null)) return false;
            if (t1.val != t2.val) return false;
            return IsSame(t1.left, t2.left) && IsSame(t1.right, t2.right);            
        }

        static bool IsSubtree1(TreeNode s, TreeNode t){
            string sstr = preorderTree(s, true);
            string tstr = preorderTree(t, true);
            return sstr.IndexOf(tstr) >= 0;
        }

        static string preorderTree(TreeNode t, bool left){
            if (t == null) return left ? ",left-null" : ",right-null";
            return ","+t.val+preorderTree(t.left, true)+preorderTree(t.right, false);
        }

    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
