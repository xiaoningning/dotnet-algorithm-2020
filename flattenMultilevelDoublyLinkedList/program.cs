/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;

    public Node(){}
    public Node(int _val,Node _prev,Node _next,Node _child) {
        val = _val;
        prev = _prev;
        next = _next;
        child = _child;
}
*/
public class Solution {
    public Node Flatten(Node head) {
        var cur = head;
        while (cur != null) {
            if (cur.child != null) {
                var next = cur.next;
                var last = cur.child;
                while (last.next != null) last = last.next;
                cur.next = cur.child;
                cur.child.prev = cur;
                cur.child = null;
                last.next = next;
                if (next != null) next.prev = last;
            }
            cur = cur.next;
        }
        return head;
    }
}
