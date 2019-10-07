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
    public int PathSum(TreeNode root, int sum) {
        if (root == null) return 0;
        return sumUp(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
    }
    int sumUp(TreeNode node, int sum) {
        if (node == null) return 0;
        return (node.val == sum ? 1 : 0) + sumUp(node.left, sum - node.val) + sumUp(node.right, sum - node.val);
    }
}
