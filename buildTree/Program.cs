using System;

namespace buildTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var node = obj.BuildTree(new int[]{3,9,20,15,7}, new int[]{9,3,15,20,7});
            Console.WriteLine("build tree from preorder and inorder: {0}", node.val);            
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
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        public TreeNode BuildTree(int[] preorder, int pl, int pr, int[] inorder, int il, int ir){
            if (pl > pr || il > ir) return null;
            int i = 0;
            for (i = il; i <= ir; i++) {
                if (preorder[pl] == inorder[i]) break;
            }
            TreeNode cur = new TreeNode(preorder[pl]);
            cur.left = BuildTree(preorder, pl + 1, pr + i - il, inorder, il, i - 1);
            cur.right = BuildTree(preorder, pl + 1 + i - il, pr, inorder, i + 1, ir);
            return cur;
        }
    }
}
