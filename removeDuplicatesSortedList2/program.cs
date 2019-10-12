/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null) return head;
        var dummy = new ListNode(-1);
        dummy.next = head;
        var pre = dummy;
        while (pre.next != null){
            var cur = pre.next;
            while (cur.next != null && cur.next.val == cur.val) {
                cur = cur.next;
            }
            if (cur != pre.next) pre.next = cur.next;
            else pre = pre.next;
        }
        return dummy.next;
    }
}
