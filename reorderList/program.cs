/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        var m = new Dictionary<int, ListNode>();
        for (int i = 1; head != null; head = head.next,i++){
            m.Add(i, head);
        }
        var dummy = new ListNode(0);
        var curr = dummy;
        for(int i = 1, j = m.Count; i <= j; i++, j--){   //1,2,3,4
            curr.next = m[i];                            //curr->1
            if (i != j) m[i].next = m[j];              //1->4
            m[j].next = null;                           //4->null
            curr = m[j];                                //curr = 4,then 1->4
        }
    }
}
