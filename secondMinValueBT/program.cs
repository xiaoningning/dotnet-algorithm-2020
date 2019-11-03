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
    public int FindSecondMinimumValue(TreeNode root) {
        // the node's value is the smaller than its two sub-nodes
        return helper(root, root.val);
    }
    int helper(TreeNode node, int first) {
        if (node == null) return -1;
        if (node.val != first) return node.val; // second
        int left = helper(node.left, first), right = helper(node.right, first);
        return (left == -1 || right == -1) ? Math.Max(left, right) : Math.Min(left, right);
    }
}
