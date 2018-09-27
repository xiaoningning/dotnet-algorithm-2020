using System;

namespace removeNthFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var head = new ListNode(5);
            head.next = new ListNode(3);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);
            var res = obj.RemoveNthFromEnd(head, 1);
            Console.WriteLine("Remove Nth From End");
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
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode slow = dummy, fast = dummy;
            
            //Move fast in front so that the gap between slow and fast becomes n
            for (int i = 0; fast != null && i <= n; i++) {
                fast = fast.next;
            }
            
            //Move fast to the end, maintaining the gap
            while (fast != null) {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return dummy.next;
        }
    }
}
