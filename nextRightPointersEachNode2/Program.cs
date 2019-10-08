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
   
    public class Solution {
        // constant space
        public Node Connect(Node root){
            var dummy = new Node(0,null, null, null);
            Node cur = dummy, head = root;
            while (root != null) {
                if (root.left != null) {
                    cur.next = root.left;
                    cur = cur.next;
                }
                if (root.right != null) {
                    cur.next = root.right;
                    cur = cur.next;
                }
                root = root.next;
                if (root == null) {
                    root = dummy.next; // pre root.left/right
                    dummy.next = null; // reset dummy as null
                    cur = dummy;
                }
            }
            return head;
        }

        public Node Connect1(Node root) {
            if (root == null) return null;
            // it is not full binary tree
            // need to scan the same level
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
}
