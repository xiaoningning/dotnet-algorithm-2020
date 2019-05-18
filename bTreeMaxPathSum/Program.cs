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
    public int MaxPathSum(TreeNode root) {
        int res = Int32.MinValue;
        Helper(root, ref res);
        return res;
    }
    int Helper(TreeNode root, ref int res) {
        if (root == null) return 0;
        // node.val < 0
        int left = Math.Max(Helper(root.left, ref res), 0);
        int right = Math.Max(Helper(root.right, ref res), 0);
        res = Math.Max(res, left + right + root.val);
        return Math.Max(left, right) + root.val;
    }
}
