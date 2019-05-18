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
