using System;

namespace nextRightPointersEachNode2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("populate next right points in each node II of unbalanced bt");
        }
    }
    public class Solution {
        public Node Connect(Node root) {
            if (root == null) return null;
            Node p = root.next;
            while (p != null) {
                if (p.left != null) {
                    p = p.left;
                    break;
                }
                if (p.right != null) {
                    p = p.right;
                    break;
                }
                p = p.next;
            }
            if (root.left != null) root.left.next = root.right != null ? root.right : p;
            if (root.right != null) root.right.next = p;
            Connect(root.left);
            Connect(root.right);
            return root;
        }
    }

    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node(){}
        public Node(int _val,Node _left,Node _right,Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
