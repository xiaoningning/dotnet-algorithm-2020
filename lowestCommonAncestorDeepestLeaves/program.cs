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
    Dictionary<TreeNode, int> m = new Dictionary<TreeNode, int>();
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        if (root == null) return null;
        int left = GetDepth(root.left);
        int right = GetDepth(root.right);
        if (left == right) return root;
        return (left > right) ? LcaDeepestLeaves(root.left) : LcaDeepestLeaves(root.right);
    }
    int GetDepth(TreeNode node) {
        if (node == null) return 0;
        if (m.ContainsKey(node)) return m[node];
        m[node] = 1 + Math.Max(GetDepth(node.left), GetDepth(node.right));
        return m[node];
    }
}
