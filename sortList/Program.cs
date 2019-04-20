using System;

namespace SortList
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("sort List");
        }
    }
    
    public class Solution {
        public ListNode SortList(ListNode head) {
            if (head == null || head.next == null) return head;
            ListNode pre = head, slow = head, fast = head;
            while (fast != null && fast.next != null) {
                pre = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            pre.next = null;
            return MergeSort(SortList(head), SortList(slow));
        }
        ListNode MergeSort(ListNode l1, ListNode l2) {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val) {
                l1.next = MergeSort(l1.next, l2);
                return l1;
            }
            else {
                l2.next = MergeSort(l1, l2.next);
                return l2;
            }
        }
    }
    /**
     * Definition for singly-linked list.
     */
    public class ListNode {
        public int val;
       public ListNode next;
       public ListNode(int x) { val = x; }
    }
}
