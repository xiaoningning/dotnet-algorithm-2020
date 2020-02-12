using System;
using System.Collections.Generic;

// You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4) Output: 7 -> 0 -> 8class Solution(object):
namespace add2numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s_l1 = args[0].Split(',');
            string[] s_l2 = args[1].Split(',');
            Console.WriteLine("l1: " + args[0]);
            Console.WriteLine("l2: " + args[1]);

            LinkedList<int> l1 = new LinkedList<int>();
            LinkedList<int> l2 = new LinkedList<int>();
            ListNode ls1 = new ListNode(0);
            ListNode ls2 = new ListNode(0);
            ListNode tmp = ls1;

            for (int i = 0; i <= s_l1.Length - 1; i++)
            {
                l1.AddLast(Int32.Parse(s_l1[i]));
                tmp.next = new ListNode(Int32.Parse(s_l1[i]));
                tmp = tmp.next;
            }

            tmp = ls2;
            for (int i = 0; i <= s_l2.Length - 1; i++)
            {
                l2.AddLast(Int32.Parse(s_l2[i]));
                tmp.next = new ListNode(Int32.Parse(s_l2[i]));
                tmp = tmp.next;
            }

            LinkedList<int> r = add2numbers(l1, l2);
            int[] r_array = new int[r.Count];
            r.CopyTo(r_array, 0);
            Console.WriteLine("r: " + string.Join(",", r_array));
            ListNode result = AddTwoNumbers(ls1.next, ls2.next);
            Console.WriteLine("result: ");
            while(result != null){
                Console.Write(result.val + ", ");
                result = result.next;
            }
        }

        static LinkedList<int> add2numbers(LinkedList<int> l1, LinkedList<int> l2)
        {
            LinkedList<int> r = new LinkedList<int>();
            int carry = 0;
            while (l1.Count != 0 || l2.Count != 0 || carry != 0)
            {
                int d1 = l1.Count == 0 ? 0 : l1.First.Value;
                int d2 = l2.Count == 0 ? 0 : l2.First.Value;
                int sum = d1 + d2 + carry;
                carry = sum / 10;
                r.AddLast(sum % 10);
                if (l1.Count != 0) l1.RemoveFirst();
                if (l2.Count != 0) l2.RemoveLast();
            }
            if (carry > 0) r.AddLast(carry);
            return r;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode dummyhead = new ListNode(0);
            ListNode cur = dummyhead;
            while (l1 != null || l2 != null || carry != 0)
            {
                int d1 = l1 == null ? 0 : l1.val;
                int d2 = l2 == null ? 0 : l2.val;
                int sum = d1 + d2 + carry;
                carry = sum / 10;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
            }
            if (carry > 0) cur.next = new ListNode(carry);
            return dummyhead.next;

        }

    }

}
