using System;
using System.Collections.Generic;

namespace binaryTreePath
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
            var obj = new Solution(); 
            var res = obj.BinaryTreePaths(root);
            Console.WriteLine("binary tree path:");
            foreach(var r in res){
                Console.WriteLine("{0}", r);
            }
        }
    }
    
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        public IList<string> BinaryTreePaths(TreeNode root) {
            List<string> res = new List<string>();
            if (root == null) return res;
            DFS(root, string.Empty, res);
            return res;
        }
        void DFS(TreeNode root, string path, List<string> res){
            path += root.val;
            if(root.left == null && root.right == null) res.Add(path);
            else{
                if(root.left != null) DFS(root.left, path +"->", res);
                if(root.right != null) DFS(root.right, path +"->", res);            
            }
        }
    }
}
