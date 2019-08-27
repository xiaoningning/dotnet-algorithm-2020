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
    public int RangeSumBST(TreeNode root, int L, int R) {
        if (root == null) return 0; // base case.
        if (root.val < L) return RangeSumBST(root.right, L, R); // left branch excluded.
        if (root.val > R) return RangeSumBST(root.left, L, R); // right branch excluded.
        // count in both children.
        return root.val + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R); 
    }
}
