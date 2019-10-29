/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates1(ListNode head) {
        if (head == null || head.next ==  null) return head;
        head.next = DeleteDuplicates(head.next);
        return (head.val == head.next.val) ? head.next : head;
    }
     public ListNode DeleteDuplicates(ListNode head) {
         if (head == null || head.next == null) return head;
         var t = new ListNode(-1);
         t.next = head;
         while (head != null) {
            var next = head.next;
            while (next != null && head.val == next.val) {
                next = next.next;
            }
            if ( next != head.next) head.next = next;
            else head = head.next;
        };
        return t.next;
    }
}
