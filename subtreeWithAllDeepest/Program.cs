using System;
using System.Collections.Generic;

namespace subtreeWithAllDeepest
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("subtree with all the same deepest level:");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(7);
            root.left.right = new TreeNode(6);
            var res = obj.SubtreeWithAllDeepest(root);
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
        public TreeNode SubtreeWithAllDeepest(TreeNode root) {
            if (root == null) return null;
            // memorize depth in a map
            Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
            return DFS(root, map);
        }
        public int Depth(TreeNode node, Dictionary<TreeNode, int> map) {
            if (node == null) return 0;
            if (map.ContainsKey(node)) return map[node];
            int max = Math.Max(Depth(node.left, map), Depth(node.right, map)) + 1;
            map.Add(node, max);
            return max;
        }

        public TreeNode DFS(TreeNode node, Dictionary<TreeNode, int> map) {
            int left = Depth(node.left, map);
            int right = Depth(node.right, map);
            if ( left == right ) return node;
            if ( left > right ) return DFS(node.left, map);
            else return DFS(node.right, map);
        }
    }    
}
