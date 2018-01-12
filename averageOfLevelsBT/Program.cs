using System;
using System.Collections.Generic;

namespace averageOfLevelsBT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input is in the code");
            TreeNode root = new TreeNode(1);
            TreeNode p = new TreeNode(2);
            TreeNode q = new TreeNode(3);
            TreeNode tn1 = new TreeNode(4);            
            TreeNode tn2 = new TreeNode(6);            
            root.left = p;
            p.right = q;
            q.left = tn1;
            q.right = tn2;
            Console.WriteLine("average of each levels:");
            var res = AverageOfLevels(root);
            foreach (var d in res)
            {
                Console.Write("{0},", d);
            }

        }

        static IList<double> AverageOfLevels(TreeNode root) {
            List<double> res = new List<double>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while(q.Count != 0){
                int n = q.Count;                
                double sum = 0;
                for (int i = 0; i < n; i++){
                    var t = q.Dequeue();
                    sum += t.val;
                    if (t.left != null) q.Enqueue(t.left);
                    if (t.right != null) q.Enqueue(t.right);
                }
                res.Add(sum/n);
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
