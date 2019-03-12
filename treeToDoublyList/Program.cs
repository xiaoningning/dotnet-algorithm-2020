using System;

namespace treeToDoublyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var left = new Node(3, null, null);
            var right = new Node(5, null, null);
            var root = new Node(4, left, right);
            obj.TreeToDoublyList(root);
        }
    }
    public class Node {
        public int val;
        public Node left;
        public Node right;

        public Node(){}
        public Node(int _val, Node _left, Node _right) {
            val = _val;
            left = _left;
            right = _right;
        }
    }
    public class Solution {
        Node prev = null;
        public Node TreeToDoublyList(Node root) {
            if (root == null) return null;
            var head = new Node(0, null, null);
            prev = head; // set head right to the far left leave in Inorder(root)
            Inorder(root);
            //connect head and tail
            prev.right = head.right;
            head.right.left = prev;
            return head.right;
        }
        private void Inorder (Node cur) {
            if (cur == null) return;
            Inorder(cur.left);
            prev.right = cur;
            cur.left = prev;
            prev = cur;
            Inorder(cur.right);
        }
    }
}
