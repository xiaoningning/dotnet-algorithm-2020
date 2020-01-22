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
    public void RecoverTree(TreeNode root) {
        InOrder(root);
        int t = first.val;
        first.val = second.val;
        second.val = t;
    }
    TreeNode first;
    TreeNode second;
    TreeNode prev = new TreeNode(Int32.MinValue);
    void InOrder(TreeNode node) {
        if (node == null) return;
        InOrder(node.left);
        // only one pair switched.
        if (prev.val > node.val) {
            if (first == null) first = prev;
            second = node;
        }
        prev = node;
        InOrder(node.right);
    }
}
