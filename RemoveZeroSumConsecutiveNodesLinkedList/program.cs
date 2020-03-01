/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // wrong ans somehow
    public ListNode RemoveZeroSumSublists1(ListNode head) {
        var dummy = new ListNode(0);
        dummy.next = head;
        var prev = dummy;
        var cur = prev.next;
        var m = new Dictionary<int, ListNode>();
        m.Add(0, prev);
        int sum = 0;
        while (cur != null) {
            sum += cur.val;
            if (m.ContainsKey(sum)) m[sum].next = cur.next;
            else m[sum] = cur;
            prev = cur;
            cur = cur.next;
        }
        return dummy.next;
    }
    // better solution
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
