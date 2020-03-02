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
    public int WidthOfBinaryTree(TreeNode root) {
        if (root == null) return 0;
        var q = new Queue<Tuple<TreeNode,int>>();
        q.Enqueue(new Tuple<TreeNode,int>(root, 1));
        int res = 0;
        while (q.Any()) {
            int cnt = q.Count;
            // avoid a deep tree with only 1 node
            // overwise, it could overflow int32 b/c 2*i;
            if (cnt == 1) {
                var onode = q.Dequeue();
                q.Enqueue(new Tuple<TreeNode,int>(onode.Item1, 1));
            }
            int left = q.Peek().Item2, right = left;
            while (cnt-- > 0) {
                var t = q.Dequeue();
                var node = t.Item1;
                right = t.Item2;
                // node: i => node.left: 2*i, node.right: 2*i+1
                if (node.left != null) q.Enqueue(new Tuple<TreeNode,int>(node.left, 2 * right));
                if (node.right != null) q.Enqueue(new Tuple<TreeNode,int>(node.right, 2 * right + 1));
            }
            res = Math.Max(res, right - left + 1);
        }
        return res;
    }
}
