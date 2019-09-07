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
    public int LargestBSTSubtree(TreeNode root) {
        if (root == null) return 0;
        if (IsValidBst(root, Int32.MinValue, Int32.MaxValue)) return Count(root);
        return Math.Max(LargestBSTSubtree(root.left), LargestBSTSubtree(root.right));
    }
    bool IsValidBst(TreeNode root, int mn, int mx) {
        if (root == null) return true;
        if (root.val <= mn || root.val >= mx) return false;
        return IsValidBst(root.left, mn, root.val) 
            && IsValidBst(root.right, root.val, mx);
    }
    int Count(TreeNode root) {
        if (root == null) return 0;
        return 1 + Count(root.left) + Count(root.right);
    }
}
