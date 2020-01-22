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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) return root;
        if (key < root.val) root.left = DeleteNode(root.left, key);
        else if (key > root.val) root.right = DeleteNode(root.right, key);
        else {
            if (root.left != null && root.right != null) {
                var min = root.right;
                while (min.left != null) min = min.left;
                root.val = min.val;
                root.right = DeleteNode(root.right, min.val);
            }
            else {
                var t = root.left == null ? root.right : root.left;                
                return t;
            }
        }
        return root;
    }
}
