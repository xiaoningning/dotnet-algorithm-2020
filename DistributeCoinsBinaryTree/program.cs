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
    public int DistributeCoins(TreeNode root) {
        dfs(root);
        return res;
    }
    int dfs (TreeNode root) {
        if (root == null) return 0;
        int left = dfs(root.left), right = dfs(root.right);
        // Abs(extra # of coints)
        // + => out, - => in moves
        res += Math.Abs(left) + Math.Abs(right);
        // total N coin, N node => each node.val will be 1;
        // return total extra coins of root
        // -1 keep one coint for itself
        return root.val + left + right - 1;
    }
}
