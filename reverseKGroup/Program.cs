using System;

namespace reverseKGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            var li = new ListNode(1);
            var s = new ListNode(2);
            var t = new ListNode(3);
            var f = new ListNode(4);
            var five = new ListNode(5);
            li.next = s;
            s.next = t;
            t.next = f;
            f.next = five;
            five.next = new ListNode(6);
            var res = obj.ReverseKGroup(li, 3);
            Console.WriteLine("revers k group: ");
            while(res != null){
                Console.WriteLine(res.val);
                res = res.next;
            }
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution {
        public ListNode ReverseKGroup(ListNode head, int k) {
            ListNode res = new ListNode(-1);
            res.next = head;
            // pre.next -> head
            ListNode pre = res, cur = head;
            int i = 0;
            while (cur != null){
                i++;
                //reverse every k node
                if (i % k == 0) {
                    pre = ReverseOne(pre, cur.next);
                    cur = pre.next;
                } else {
                    cur = cur.next;
                }
            }            
            return res.next;
        }
        // pre.next -> head
        // tail.next -> next
        // reverse from head to tail
        ListNode ReverseOne(ListNode pre, ListNode next){
            ListNode last = pre.next;
            ListNode cur = last.next;
            while(cur != next) {
                last.next = cur.next;
                cur.next = pre.next;
                pre.next = cur;
                cur = last.next;
            }
            return last;
        }
    }
}
