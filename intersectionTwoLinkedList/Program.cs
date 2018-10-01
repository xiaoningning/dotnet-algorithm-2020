using System;

namespace intersectionTwoLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            Console.WriteLine("Get Intersection Node 1");
            ListNode headA = new ListNode(1);
            ListNode headB = new ListNode(2);
            headB.next = new ListNode(1);
            obj.GetIntersectionNode(headA, headB);
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
        public ListNode GetIntersectionNode1(ListNode headA, ListNode headB) {
            if(headA == null || headB == null) return null;
            
            int la = GetLength(headA);
            int lb = GetLength(headB);
            while (la < lb) {
                headB = headB.next;
                lb--;
            }
            while (lb < la) {
                headA = headA.next;
                la--;
            }
            while (headA != headB){
                headA = headA.next;
                headB = headB.next;
            }
            return headA;
        }
        
        private int GetLength(ListNode root) {
            int res = 0;
            while (root != null) {
                root = root.next;
                res++;
            }
            return res;
        }
        
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            if(headA == null || headB == null) return null;
            var a = headA;
            var b = headB;
            while (a != b){
                // if both lengths different, 
                // link them as a loop and then meet at the intersection
                a = a == null? headB : a.next;
                b = b == null? headA : b.next; 
            }
            return a;
        }
    }
}
