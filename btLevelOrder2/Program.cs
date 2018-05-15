using System;
using System.Collections.Generic;

namespace btLevelOrder2
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            var obj = new Solution();
            var res = obj.LevelOrderBottom(root);
            Console.WriteLine("BT level order 2");
            foreach(var r in res){
                Console.WriteLine(string.Join(",", r));
            }
        }
        public class Solution {
            public IList<IList<int>> LevelOrderBottom(TreeNode root) {
                List<IList<int>> res = new List<IList<int>>();
                if (root == null) return res;
                Queue<TreeNode> q = new Queue<TreeNode>();
                q.Enqueue(root);
                while(q.Count != 0){
                    List<int> level = new List<int>();
                    int size = q.Count;
                    for(int i = 0; i < size; i++){
                        TreeNode t = q.Dequeue();
                        level.Add(t.val);
                        if(t.left != null) q.Enqueue(t.left);
                        if(t.right != null) q.Enqueue(t.right);
                    }
                    res.Insert(0, level);
                }
                return res;
            }
        }
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
