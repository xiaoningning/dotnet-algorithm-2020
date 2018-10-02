using System;

namespace buildTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var node = obj.BuildTree(new int[]{9,3,15,20,7}, new int[]{9,15,7,20,3});
            Console.WriteLine("build tree from inorder and postorder: {0}", node.val);            
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
        public TreeNode BuildTree(int[] inorder, int[] postorder) {
            return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        public TreeNode BuildTree(int[] inorder, int il, int ir, int[] postorder, int pl, int pr){
            if (pl > pr || il > ir) return null;
            int i = 0;
            for (i = il; i <= ir; i++) {
                if (postorder[pr] == inorder[i]) break;
            }
            TreeNode cur = new TreeNode(postorder[pr]);
            cur.left = BuildTree(inorder, il, i - 1, postorder, pl, pl + i - il - 1 );
            cur.right = BuildTree(inorder, i + 1, ir, postorder, pl + i - il, pr - 1);
            return cur;
        }
    }
}
