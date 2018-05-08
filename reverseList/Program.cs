using System;

namespace reverseList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            var obj = new Solution();
            var res = obj.ReverseList(head);
            Console.WriteLine("reverse List");
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
        public ListNode ReverseList(ListNode head) {
            ListNode prev = null;
            while(head != null){
                ListNode tmp = head.next;
                head.next = prev;
                prev = head;
                head = tmp;
            }      
            return prev;
        }
    }
}
