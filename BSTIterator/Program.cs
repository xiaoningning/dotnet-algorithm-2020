using System;
using System.Collections.Generic;

namespace BSTIterator
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
            var obj = new BSTIterator(root);
            Console.WriteLine("BST Iterator {0}", obj.HasNext());
            Console.WriteLine("BST Iterator {0}", obj.Next());
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class BSTIterator {
        private Stack<TreeNode> s = new Stack<TreeNode>();
        public BSTIterator(TreeNode root) {
            while(root != null){
                s.Push(root);
                root = root.left;
            }
            
        }

        /** @return whether we have a next smallest number */
        public bool HasNext() {
            return s.Count > 0;
        }

        /** @return the next smallest number */
        public int Next() {
            TreeNode t = s.Pop();
            int res = t.val;
            if(t.right != null){
                t = t.right;
                while(t != null){
                    s.Push(t);
                    t = t.left;
                }
            }
            return res;
        }
    }
}
