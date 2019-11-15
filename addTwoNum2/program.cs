/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers1(ListNode l1, ListNode l2) {
        var s1 = new Stack<int>();
        var s2 = new Stack<int>();
        while (l1 != null) {
            s1.Push(l1.val);
            l1 = l1.next;
        }
        while (l2 != null) {
            s2.Push(l2.val);
            l2 = l2.next;
        }
        int sum = 0;
        ListNode res = new ListNode(0);
        while (s1.Any() || s2.Any()) {
            if (s1.Any()) sum += s1.Pop();
            if (s2.Any()) sum += s2.Pop();
            res.val = sum % 10;
            ListNode head = new ListNode(sum / 10);
            head.next = res;
            res = head;
            sum /= 10;
        }
        return res.val == 0 ? res.next : res;
    }
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        int n1 = GetLength(l1), n2 = GetLength(l2), diff = Math.Abs(n1 - n2);
        if (n1 < n2) {
            var t = l1;
            l1 = l2;
            l2 = t;
        };
        ListNode dummy = new ListNode(0), cur = dummy, right = cur;
        while (diff > 0) {
            cur.next = new ListNode(l1.val);
            if (l1.val != 9) right = cur.next;
            cur = cur.next;
            l1 = l1.next;
            --diff;
        }
        while (l1 != null) {
            int val = l1.val + l2.val;
            if (val > 9) {
                val %= 10;
                right.val++;
                while (right.next != null) {
                    right.next.val = 0;
                    right = right.next;
                }
                right = cur;
            }
            cur.next = new ListNode(val);
            if (val != 9) right = cur.next;
            cur = cur.next;
            l1 = l1.next;
            l2 = l2.next;
        }
        return (dummy.val == 1) ? dummy : dummy.next;
    }
    int GetLength(ListNode head) {
        int cnt = 0;
        while (head != null) {
            ++cnt;
            head = head.next;
        }
        return cnt;
    }
}
