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

            for (int i = 0; i <= s_l1.Length - 1; i++){
                l1.AddLast(Int32.Parse(s_l1[i]));
            }

            for (int i = 0; i <= s_l2.Length - 1; i++){
                l2.AddLast(Int32.Parse(s_l2[i]));
            }

            LinkedList<int> r = add2numbers(l1, l2);
            int[] r_array = new int[r.Count];
            r.CopyTo(r_array, 0);
            Console.WriteLine("resulte: " + string.Join(",", r_array));
        }

        static LinkedList<int> add2numbers(LinkedList<int> l1, LinkedList<int> l2){
            LinkedList<int> r = new LinkedList<int>();
            int carry = 0;
            while (l1.Count != 0 || l2.Count != 0){
                int d1 = l1.Count == 0 ? 0: l1.Last.Value;
                int d2 = l1.Count == 0 ? 0: l2.Last.Value;
                int sum = d1 + d2 + carry;
                carry = sum >= 10 ? 1 : 0;
                r.AddLast(sum % 10);
                l1.RemoveLast();
                l2.RemoveLast();
            }
            if(carry == 1) r.AddLast(carry);
            return r;
        }
    }
}
