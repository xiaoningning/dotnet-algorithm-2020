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
    public IList<int> RightSideView(TreeNode root) {
        var res = new List<int>();
        if (root == null) return res;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count != 0) {
            var n = q.Count;
            var t = q.Peek();
            res.Add(t.val);
            for (int i = 0; i < n; i++) {
                var node = q.Dequeue();
                if (node.right != null) q.Enqueue(node.right);
                if (node.left != null) q.Enqueue(node.left);
            }
        }
        return res;
    }
    
}
