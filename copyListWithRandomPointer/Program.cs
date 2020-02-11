/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(){}
    public Node(int _val,Node _next,Node _random) {
        val = _val;
        next = _next;
        random = _random;
}
*/
public class Solution {
    public Node CopyRandomList(Node head) { 
        if (head == null) return head;
        var cur = head;
        // copy all nodes
        while (cur != null) {
            var t = new Node(cur.val, null, null);
            t.next = cur.next;
            cur.next = t;
            cur = t.next;
        }
        cur = head;
        // assign random
        while (cur != null) {
            // the next is the copy of cur/cur.random
            if (cur.random != null) cur.next.random = cur.random.next;
            cur = cur.next.next;
        }
        // remove old node
        cur = head;
        var res = cur.next;
        while (cur != null) {
            var t = cur.next;
            cur.next = t.next;
            if (t.next != null) t.next = t.next.next;
            cur = cur.next;
        }
        // time: O(n) space: O(1)
        return res;
    }
    
    public Node CopyRandomList1(Node head) {
        var m = new Dictionary<Node, Node>();
        return Helper(head, m);
    }
    Node Helper(Node n, Dictionary<Node, Node> m) {
        if (n == null) return null;
        if (m.ContainsKey(n)) return m[n];
        var res = new Node(n.val, null, null);
        m[n] = res;
        res.next = Helper(n.next, m);
        res.random = Helper(n.random, m);
        return res;
    }
}
