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
    public int Rob(TreeNode root) {
        int[] res = dfs(root);
        return Math.Max(res[0], res[1]);
    }
    //[0]: max with root, [1] max without root
    int[] dfs(TreeNode root) {
        if (root == null) return new int[2]{0,0};
        int[] l = dfs(root.left);
        int[] r = dfs(root.right);
        int[] res = new int[2];
        res[0] = l[1] + r[1] + root.val;
        res[1] = Math.Max(l[0], l[1]) + Math.Max(r[0], r[1]);
        return res;
    }
    // TLE
    int res = 0;
    public int Rob1(TreeNode root) {
        if (root == null) return 0;
        return Math.Max(dfsExclude(root),dfsInclude(root));
    }
    int dfsInclude(TreeNode root) {
        if (root == null) return 0;
        return dfsExclude(root.left)+dfsExclude(root.right) + root.val;
    }
    int dfsExclude(TreeNode root) {
        if (root == null) return 0;
        return Rob1(root.left) + Rob1(root.right);
    }
}
