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
        // the node's value is the smaller among its two sub-nodes
        // root <= left | right
        return helper(root, root.val);
    }
    int helper(TreeNode node, int first) {
        if (node == null) return -1;
        if (node.val != first) return node.val; // second
        int left = helper(node.left, first), right = helper(node.right, first);
        return (left == -1 || right == -1) ? Math.Max(left, right) : Math.Min(left, right);
    }
    
    public int FindSecondMinimumValue2(TreeNode root) {
        // the node's value is the smaller among its two sub-nodes
        // 2nd min can be int32.maxvalue
        int first = root.val, second = Int32.MaxValue;
        helper(root, ref first, ref second);
        return (second == first || second == Int32.MaxValue) ? -1 : second;
    }
    void helper(TreeNode node, ref int first, ref int second) {
        if (node == null) return;
        if (node.val != first && node.val < second) {
            second = node.val;
        }
        helper(node.left, ref first, ref second);
        helper(node.right, ref first, ref second);
    }
}
