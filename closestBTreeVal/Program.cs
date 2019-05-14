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
    public int ClosestValue(TreeNode root, double target) {
        // non-empty tree
        int a = root.val;
        var t = (target < a) ? root.left : root.right;
        if (t == null) return a;
        var b = ClosestValue(t, target);
        return Math.Abs(a - target) > Math.Abs(b - target) ? b : a;
    }
}
