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
    public int LongestConsecutive(TreeNode root) {
        return helper(root, null, 0);
    }
    int helper(TreeNode root, TreeNode p, int res) {
        if (root == null) return res;
        res = (p != null && root.val == p.val + 1) ? res + 1 : 1;
        return Math.Max(res, Math.Max(helper(root.left, root, res), helper(root.right, root, res)));
    }
}
