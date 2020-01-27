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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        var leaf1 = new List<int>();
        var leaf2 = new List<int>();
        GetLeaf(root1, leaf1);
        GetLeaf(root2, leaf2);
        // c# equal is object level, not element value level
        // SequenceEqual in Linq, element order & value equal
        return leaf1.SequenceEqual(leaf2);
    }
    void GetLeaf(TreeNode root, List<int> leaf) {
        if (root == null) return;
        if (root.left == null && root.right == null) leaf.Add(root.val);
        GetLeaf(root.left, leaf);
        GetLeaf(root.right, leaf);
    }
}
