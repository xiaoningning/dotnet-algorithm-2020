/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;

    public Node(){}
    public Node(int _val,Node _next) {
        val = _val;
        next = _next;
}
*/
public class Solution {
    public Node Insert(Node head, int insertVal) {
        if (head == null) {
            var res = new Node(insertVal, null);
            res.next = res;
            return res;
        }
        
        Node pre = head, cur = pre.next;
        while (cur != head) {
            if (pre.val <= insertVal && insertVal <= cur.val) break;
            if (pre.val > cur.val 
                && (pre.val <= insertVal || cur.val >= insertVal)) break;
            pre = cur;
            cur = cur.next;
        }
        pre.next = new Node(insertVal, cur);
        return head;
    }
}
