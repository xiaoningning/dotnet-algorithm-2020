using System;

namespace linkedListCycleII
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var head = new ListNode(1);
            head.next = new ListNode(2);
            var node3 = new ListNode(3);
            head.next.next = node3;
            var node4 = new ListNode(4);
            node3.next = node4;
            var node5 = new ListNode(5);
            node4.next = node5;
            node5.next = node3;
            Console.WriteLine("linked list has cycle at node: {0}", obj.DetectCycle(head)?.val);
        }
    }
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) {
            val = x;
            next = null;
        }
    }
    public class Solution {
        public ListNode DetectCycle(ListNode head) {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null){
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) break;
            }
            // no cycle case
            if (fast == null || fast.next == null) return null;
            // fast is 2 x slow spead
            // x ->(a) y ->(b) z ->(c) y. z is where fast and slow meets
            // the length of fast is 2 x that of slow
            // fast = a+b+c+b
            // slow = a + b
            // a + b + c  + b = 2 * (a + b)
            // c = a 
            // now fast walk c, head walk a,
            // then meet at the cycly point
            slow = head;
            while (slow != fast) {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }
    }
}
