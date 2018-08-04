using System;

namespace mergeKLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();
            ListNode[] l = new ListNode[]{
                new ListNode(1),
                new ListNode(3),
                new ListNode(2),
            };
            var res = obj.MergeKLists(l);
            Console.WriteLine("merge k sorted list");
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
        public ListNode MergeKLists(ListNode[] lists) {
            if (lists.Length == 0) return null;
            int n = lists.Length;
            while (n > 1) {
                int k = (n + 1) / 2;
                for (int i = 0; i < n / 2; ++i) {
                    lists[i] = MergeTwo(lists[i], lists[i + k]);
                }
                n = k;
            }
            return lists[0];            
        }

        ListNode MergeTwo(ListNode m, ListNode n){
            ListNode head = new ListNode(0);
            ListNode cur = head;
            while(m != null && n != null){
                if (m.val < n.val) {
                    cur.next = m;
                    m = m.next;
                } 
                else {
                    cur.next = n;
                    n = n.next;
                }
                cur = cur.next;    
            }
            if (m != null) cur.next = m;
            if (n != null) cur.next = n; 
            return head.next;
        }
    }
}
