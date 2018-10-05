using System;

namespace mergeTwoSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var l1 = new ListNode(1);
            l1.next = new ListNode(3);
            var l2 = new ListNode(3);
            l1.next = new ListNode(4);
            var res = obj.MergeTwoLists(l1, l2);
            Console.WriteLine("merge two sorted list");
            while (res != null){
                Console.Write(res.val + ",");
                res = res.next;
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
    
    public class Solution {
        public ListNode MergeTwoLists1(ListNode l1, ListNode l2) {
            ListNode dummy = new ListNode(-1);
            var cur = dummy;
            while (l1 != null && l2 != null) {
                if (l1.val < l2.val) {
                    cur.next = l1;
                    l1 = l1.next;                
                }
                else {
                    cur.next = l2;
                    l2 = l2.next;
                }
                cur = cur.next;
            }
            cur.next = (l1 != null) ? l1 : l2;
            return dummy.next;
        }
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val) {            
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
    }
}
