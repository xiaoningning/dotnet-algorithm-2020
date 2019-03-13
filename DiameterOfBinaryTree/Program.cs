using System;
using System.Collections.Generic;
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
            var obj = new Solution();
            Console.WriteLine("diameter of tree:{0}", obj.DiameterOfBinaryTree(root));
        }
    }
    public class Solution {
        int res;
        Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
        public int DiameterOfBinaryTree(TreeNode root) {
            res = 0;
            GetDepth(root, ref res);
            return res;
        }

        int GetDepth(TreeNode t, ref int res){
            if (t == null) return 0;
            if (map.ContainsKey(t)) return map[t];
            int left = GetDepth(t.left, ref res);
            int right = GetDepth(t.right, ref res);
            res = Math.Max(res, left + right);
            map[t] = Math.Max(left, right) + 1;
            return map[t];
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
