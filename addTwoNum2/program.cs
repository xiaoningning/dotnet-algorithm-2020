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
        int n1 = GetLength(l1), n2 = GetLength(l2);
        // plus 1 in case head.next is 9
        ListNode head = new ListNode(1);
        head.next = (n1 > n2) ? helper(l1, l2, n1 - n2) : helper(l2, l1, n2 - n1);
        if (head.next.val > 9) {
            head.next.val %= 10;
            return head;
        }
        return head.next;
    }
    ListNode helper(ListNode l1, ListNode l2, int diff) {
        if (l1 == null) return null;
        var cur = diff == 0 ? new ListNode(l1.val + l2.val) : new ListNode(l1.val);
        var post = diff == 0 ? helper(l1.next, l2.next, 0) : helper(l1.next, l2, diff - 1);
        if (post != null && post.val > 9) {
            post.val %= 10;
            ++cur.val;
        }
        cur.next = post;
        return cur;
    }
    public ListNode AddTwoNumbers2(ListNode l1, ListNode l2) {
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
            // val is never 19 => only one carry
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
        // dummy 0 -> 1 b/c dummy is 9
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
