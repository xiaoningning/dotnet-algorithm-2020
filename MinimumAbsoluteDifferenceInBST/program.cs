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
    int res = Int32.MaxValue;
    int preVal = -1;
    public int GetMinimumDifference(TreeNode root) {
        if (root == null) return res;
        // BST do left first since left < root < right
        GetMinimumDifference(root.left);
        if (preVal >= 0) res = Math.Min(res, root.val - preVal);
        preVal = root.val;
        GetMinimumDifference(root.right);
        return res;
    }
}
