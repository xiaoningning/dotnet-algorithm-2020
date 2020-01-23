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
    int val = -1;
    public bool IsUnivalTree(TreeNode root) {
        if (root == null) return true;
        if (val == -1) val = root.val;
        return root.val == val && IsUnivalTree(root.left) && IsUnivalTree(root.right);
    }
}
