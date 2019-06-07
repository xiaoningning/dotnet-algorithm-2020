/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var res = new List<IList<int>>();
        if (root == null) return res;
        var m = new SortedDictionary<int, SortedDictionary<int, List<int>>>();
        var q = new Queue<TreeNode>();
        var l = new Queue<int>();
        var h = new Queue<int>();
        q.Enqueue(root);
        l.Enqueue(0);
        h.Enqueue(0);
        while (q.Count != 0) {
            var n = q.Dequeue();
            var i = l.Dequeue();
            var j = h.Dequeue();
            if (!m.ContainsKey(i)) {
                var tm = new SortedDictionary<int, List<int>>();
                m.Add(i, tm);
            }
            if (!m[i].ContainsKey(j)) {
                m[i].Add(j, new List<int>());
            }
            m[i][j].Add(n.val);
            if(n.left != null) {
                q.Enqueue(n.left);
                l.Enqueue(i-1);
                h.Enqueue(j-1);
            }
            if(n.right != null) {
                q.Enqueue(n.right);
                l.Enqueue(i+1);
                h.Enqueue(j-1);
            }
        }
        foreach (var kv in m) {
            var tl = new List<int>();
            foreach (var tkv in kv.Value.Reverse()) {
                tkv.Value.Sort();
                tl.AddRange(tkv.Value);
            }
            res.Add(tl);
        }
        return res;
    }
}
