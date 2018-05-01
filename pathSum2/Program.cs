using System;
using System.Collections.Generic;

namespace pathSum2
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
            var res = obj.PathSum(root,30);
            Console.WriteLine("Path Sum 2:");
            foreach(var r in res){
                Console.WriteLine("{0}", string.Join(',',r));
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
        public IList<IList<int>> PathSum(TreeNode root, int sum) {
            List<IList<int>> res = new List<IList<int>>();
            List<int> temp = new List<int>();
            DFS(root, sum, temp, res);
            return res;
        }
        void DFS(TreeNode node, int sum, List<int> temp, List<IList<int>> res){
            if(node == null) return;
            temp.Add(node.val);
            if(sum == node.val && node.left == null && node.right == null) {
                res.Add(new List<int>(temp));
            }
            
            DFS(node.left, sum - node.val, temp, res);
            DFS(node.right, sum - node.val, temp, res);
            // not in sum equ condition, remove val in temp list 
            // back to outer recursive layer 
            temp.RemoveAt(temp.Count - 1);
        }
    }
}
