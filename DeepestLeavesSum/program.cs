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
    int maxDepth = 0;
    public int DeepestLeavesSum(TreeNode root) {
        dfs(root, 0);
        return res;
    }
    void dfs(TreeNode root, int d){
        if (root == null) return;
        if (d > maxDepth) {
            maxDepth = d;
            res = 0;
        }
        if (d == maxDepth) res += root.val;
        dfs(root.left, d + 1);
        dfs(root.right, d + 1);
    }
}
