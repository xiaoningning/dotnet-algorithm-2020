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
    // a given tree is a complet one!
    public int CountNodes(TreeNode root) {
        int hLeft = LeftHeight(root);
        int hRight = RightHeight(root);
        if (hLeft == hRight) return (int)Math.Pow(2, hLeft) - 1;
        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }
    
    int LeftHeight(TreeNode root) {
        if (root == null) return 0;
        return LeftHeight(root.left) + 1;
    }
    int RightHeight(TreeNode root) {
        if (root == null) return 0;
        return RightHeight(root.right) + 1;
    }
}
