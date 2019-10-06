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
    public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target) {
        if (root1 == null || root2 == null) return false;
        int t = root1.val;
        if (binarySearch(root2, target-t)) return true;
        return TwoSumBSTs(root1.left, root2, target) || TwoSumBSTs(root1.right, root2, target);
    }
    bool binarySearch(TreeNode root, int target) {
        if (root == null) return false;
        int t = root.val;
        if (target == t) return true;
        return t > target ? binarySearch(root.left, target) : binarySearch(root.right, target);
    }
}
