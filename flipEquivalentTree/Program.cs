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
    public bool FlipEquiv(TreeNode root1, TreeNode root2) {
        if (root1 == null || root2 == null) return root1 == root2;
        if (root1.val != root2.val) return false;
        int v1 = root1.left != null ? root1.left.val : -1;
        int v2 = root2.left != null ? root2.left.val : -1;
        // if nodes are flipped, swap it back.
        if (v1 != v2) {
            TreeNode tmp = root1.left;
            root1.left = root1.right;
            root1.right = tmp;
        }
        // time: O(n)
        return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right,root2.right);
    }
}
