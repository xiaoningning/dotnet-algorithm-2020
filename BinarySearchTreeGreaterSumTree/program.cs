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
    int sum = 0;
    public TreeNode BstToGst(TreeNode root) {
        if (root == null) return null;
        BstToGst(root.right);
        root.val += sum;
        sum = root.val;
        BstToGst(root.left);
        return root;
    }
}
