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
    int i = 0;
    public TreeNode BstFromPreorder(int[] preorder) {
        return BstFromPreorder(preorder, Int32.MaxValue);
    }
    public TreeNode BstFromPreorder(int[] A, int bound) {
        if (i == A.Length || A[i] > bound) return null;
        TreeNode root = new TreeNode(A[i++]);
        root.left = BstFromPreorder(A, root.val);
        root.right = BstFromPreorder(A, bound);
        return root;
    }
}
