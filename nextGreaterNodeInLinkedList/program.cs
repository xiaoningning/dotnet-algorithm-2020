/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // the same as 503
    public int[] NextLargerNodes(ListNode head) {
        var A = new List<int>();
        for (ListNode node = head; node != null; node = node.next)
            A.Add(node.val);
        int[] res = new int[A.Count];
        Stack<int> st = new Stack<int>();
        for (int i = 0; i < A.Count; ++i) {
            while (st.Any() && A[st.Peek()] < A[i])
                res[st.Pop()] = A[i];
            st.Push(i);
        }
        return res;
    }
}
