using System;
using System.Collections.Generic;

namespace BTVerticalOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(0);
            var res = obj.VerticalOrder(root);
            foreach(var r in res){
                Console.WriteLine("result list: {0}", string.Join(',', r));
            }
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution {
        public IList<IList<int>> VerticalOrder(TreeNode root) {
            List<IList<int>> res = new List<IList<int>>();
            if(root == null) return res;
            
            Dictionary<int,List<int>> map = new Dictionary<int,List<int>>();
            Queue<TreeNode> qNode = new Queue<TreeNode>();
            Queue<int> qCol = new Queue<int>();
            int min = 0;
            int max = 0;
            
            qNode.Enqueue(root);
            qCol.Enqueue(0);
            
            while(qNode.Count != 0){
                var t = qNode.Dequeue();
                int col = qCol.Dequeue();
                if (!map.ContainsKey(col)) {
                    map.Add(col, new List<int>());
                }
                map[col].Add(t.val);    
                
                if(t.left != null){
                    qNode.Enqueue(t.left);
                    qCol.Enqueue(col - 1);
                    min = Math.Min(min, col - 1);
                }
                if(t.right != null){
                    qNode.Enqueue(t.right);
                    qCol.Enqueue(col + 1);
                    max = Math.Max(max, col + 1);
                }
            }
            for (int i = min; i <= max; i++) {
                if (map.ContainsKey(i)) res.Add(map[i]);
            }
            return res;
        }
    }
}
