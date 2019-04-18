using System;

namespace nextRightPointersEachNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("populate next right points in each node of perfect bt");
        }
    }
    public class Solution {
        public Node Connect1(Node root) {
            if (root == null) return null;
            Node start = root, cur = null;
            while (start.left != null) {
                cur = start;
                while (cur != null) {
                    cur.left.next = cur.right;
                    if (cur.next != null) cur.right.next = cur.next.left;
                    cur = cur.next;
                }
                start = start.left;
            }
            return root;
        }
        
        public Node Connect(Node root) {
            if (root == null) return null;
            if (root.left != null) root.left.next = root.right;
            if (root.right != null) root.right.next = root.next != null ? root.next.left : null;
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
