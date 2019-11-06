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
    public int FindClosestLeaf(TreeNode root, int k) {
        var parents = new Dictionary<TreeNode, TreeNode>();
        var kNode = Find(root, k, parents);
        var q = new Queue<TreeNode>();
        var visited = new List<TreeNode>(){kNode};
        q.Enqueue(kNode);
        while (q.Any()) {
            var t = q.Dequeue();
            // it is q, the nearest one pop first
            if (t.left == null && t.right == null) return t.val;
            if (t.left != null && !visited.Contains(t.left)) {
                visited.Add(t.left);
                q.Enqueue(t.left);
            }
            if (t.right != null && !visited.Contains(t.right)) {
                visited.Add(t.right);
                q.Enqueue(t.right);
            }
            // check parent side
            if (parents.ContainsKey(t) && !visited.Contains(parents[t])) {
                visited.Add(parents[t]);
                q.Enqueue(parents[t]);
            }
        }
        return -1;
    }
    TreeNode Find(TreeNode node, int k, Dictionary<TreeNode, TreeNode> p) {
        if (node == null) return null;
        if (node.val == k) return node;
        if (node.left != null) {
            p[node.left] = node;
            TreeNode left = Find(node.left, k, p);
            if (left != null) return left;
        }
        if (node.right != null) {
            p[node.right] = node;
            TreeNode right = Find(node.right, k, p);
            if (right != null) return right;
        }
        return null;
    }
}
