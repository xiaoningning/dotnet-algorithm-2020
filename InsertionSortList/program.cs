/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode InsertionSortList(ListNode head) {
        if (head == null) return head;
        ListNode helper = new ListNode(0); //new starter of the sorted list
		ListNode cur = head; //the node will be inserted
		ListNode pre = helper; //insert node between pre and pre.next
		while( cur != null ) { 
            while (pre.next != null && pre.next.val < cur.val) pre = pre.next;
            ListNode next = cur.next;
            cur.next = pre.next;
            pre.next = cur;            
            cur = next;
            pre = helper;
        }
        return helper.next;
    }
}
