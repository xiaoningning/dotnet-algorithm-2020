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
    public IList<int> BoundaryOfBinaryTree(TreeNode root) {
        var res = new List<int>();
        if (root == null) return res;
        res.Add(root.val);
        Helper(root.left, true, false, res);
        Helper(root.right, false, true, res);
        return res;
    }
    void Helper(TreeNode node, bool leftb, bool rightb, List<int> res) {
        if (node == null) return;
        // leave
        if (node.left == null && node.right == null)  {
            res.Add(node.val);
            return;
        }
        if (leftb) res.Add(node.val);
        Helper(node.left, leftb, rightb && (node.right == null), res);
        Helper(node.right, leftb && (node.left == null), rightb, res);
        if (rightb) res.Add(node.val);
    }
}
