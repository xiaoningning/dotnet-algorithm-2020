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
    public bool IsBalanced(TreeNode root) {
        // button up => O(n) 
        return GetBalancedHeight(root) != -1;
    }
    int GetBalancedHeight(TreeNode root) {
        if (root == null) return 0;
        int left = GetBalancedHeight(root.left);
        if (left == -1) return -1;
        int right = GetBalancedHeight(root.right);
        if (right == -1) return -1;
        return Math.Abs(left - right) <= 1 ? Math.Max(left, right) + 1 : -1;
    }
}
