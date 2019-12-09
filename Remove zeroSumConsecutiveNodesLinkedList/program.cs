/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveZeroSumSublists(ListNode head) {
        int prefix = 0;
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        var seen = new Dictionary<int, ListNode>();
        seen.Add(0, dummy);
        for (ListNode i = dummy; i != null; i = i.next) {
            prefix += i.val;
            // update the latest prefix
            seen[prefix] = i;
        }
        prefix = 0;
        for (ListNode i = dummy; i != null; i = i.next) {
            prefix += i.val;
            // remove the previous same prefix nodes
            i.next = seen[prefix].next;
        }
        return dummy.next;
    }
}
