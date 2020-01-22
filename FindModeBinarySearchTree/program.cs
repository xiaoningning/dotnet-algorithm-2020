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
    public int[] FindMode(TreeNode root) {
        InOrder(root);
        return res.ToArray();
    }
    List<int> res = new List<int>();
    int val = 0;
    int cnt = 0;
    int mxCnt = 0;
    void InOrder(TreeNode root) {
        if (root == null) return;
        InOrder(root.left);
        Visit(root);
        InOrder(root.right);
    }
    // since bst, the same val is next to each other
    void Visit(TreeNode root) {
        if (cnt > 0 && val == root.val) cnt++;
        else {
            val = root.val;
            cnt = 1;
        }
        if (cnt > mxCnt) {
            mxCnt = cnt;
            res.Clear();
        }
        if (cnt == mxCnt) {
            res.Add(root.val);
        }
    }
}
