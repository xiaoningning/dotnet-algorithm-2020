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
    public int MinCameraCover(TreeNode root) {
        return (dfs(root) == 0 ? 1 : 0) + res;
    }
    // 0: none, 1: camera, 2: covered
    int dfs(TreeNode root) {
        if (root == null) return 2;
        int l = dfs(root.left), r = dfs(root.right);
        if (l == 0 || r == 0) {
            res++;
            return 1;
        }
        // leaf is 2 => root : 0 -> MinCameraCover  => 1
        // one of leaf is 1 => root: 2
        return l == 1 || r == 1 ? 2 : 0;
    }
}
