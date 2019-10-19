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
    int res = 0;
    public int CountUnivalSubtrees(TreeNode root) {
        Count(root, 0);
        return res;
    }
    bool Count(TreeNode root, int val) {
        if (root == null) return true;
        bool left = Count(root.left, root.val);
        bool right = Count(root.right, root.val);
        if (left && right) {
            res++; // itself is a tree
            return root.val == val;
        }
        else return false;
    }
}
