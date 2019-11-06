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
        if (root == null) return 0;
        int res = helper(root, 1) + helper(root, -1) + 1;
        return Math.Max(res, Math.Max(LongestConsecutive(root.left), LongestConsecutive(root.right)));
    }
    int helper(TreeNode node, int diff) {
        if (node == null) return 0;
        int left = 0, right = 0;
        if (node.left != null && node.left.val == node.val + diff)
            left = 1 + helper(node.left, diff);
        if (node.right != null && node.right.val == node.val + diff)
            right = 1 + helper(node.right, diff);
        return Math.Max(left, right);
    }
}
