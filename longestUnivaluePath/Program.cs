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
    public int LongestUnivaluePath(TreeNode root) {
        int res = 0;
        DFS(root, ref res);
        return res;
    }
    int DFS(TreeNode root, ref int res) {
        if (root == null) return 0;
        int l = DFS(root.left, ref res);
        int r = DFS(root.right, ref res);
        if (root.left != null) l = (root.val == root.left.val) ?  l + 1 : 0;
        if (root.right != null) r = (root.val == root.right.val) ?  r + 1 : 0;
        res = Math.Max(res, l + r);
        return  Math.Max(l, r);
    }
}
