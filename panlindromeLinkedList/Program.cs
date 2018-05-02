using System;
using System.Collections.Generic;

namespace panlindromeLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            ListNode head = new ListNode(3);
            head.next = new ListNode(5);
            head.next.next = new ListNode(5);            
            head.next.next.next = new ListNode(3);
            Console.WriteLine("IsPalindrome {0}", obj.IsPalindrome(head));
        }
    }
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution {
        public bool IsPalindrome(ListNode head) {
            if(head == null || head.next == null) return true;
            // slow -> one step
            // fast -> two steps
            // then slow is middle
            ListNode slow = head, fast = head;
            Stack<int> s = new Stack<int>();
            while (fast != null && fast.next != null) {
                s.Push(slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }
            
            // odd nodes: let right half smaller
            if (fast != null){
                slow = slow.next;                                
            } 
            
            while(slow != null){
                if(s.Count != 0){
                    int t = s.Pop();
                    if(t != slow.val) return false;
                }
                slow = slow.next;
            }
            return true;
        }
        public bool IsPalindrome1(ListNode head) {
            if(head == null || head.next == null) return true;
            // slow -> one step
            // fast -> two steps
            // then slow is middle
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null) {
                slow = slow.next;
                fast = fast.next.next;
            }
            
            // odd nodes: let right half smaller
            if (fast != null) slow = slow.next;
            
            ListNode prev = head;
            ListNode last = Reverse(slow);
            
            while(prev != null && last != null){
                if(prev.val != last.val) return false;
                prev = prev.next;
                last = last.next;
            }
            return true;
        }
        public ListNode Reverse(ListNode head) {
            ListNode prev = null;
            while (head != null) {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }
}
