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
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        var res = new List<int>();
        // reverse link of node to find parent side node
        var parentMap = new Dictionary<TreeNode, TreeNode>();
        var visited = new List<TreeNode>();
        FindParent(root, parentMap);
        Helper(target, K, parentMap, res, visited);
        return res;
    }
    void FindParent(TreeNode n, Dictionary<TreeNode, TreeNode> map) {
        if (n == null) return;
        if (n.left != null) map[n.left] = n;
        if (n.right != null) map[n.right] = n;
        FindParent(n.left, map);
        FindParent(n.right, map);
    }
    void Helper(TreeNode n, 
                int k, 
                Dictionary<TreeNode, TreeNode> map, 
                List<int> res,
                List<TreeNode> visited) {
        if (visited.Contains(n)) return;
        visited.Add(n);
        if (k == 0)  {
            res.Add(n.val);
            return;
        }
        if (n.left != null) Helper(n.left, k - 1, map, res, visited);
        if (n.right != null) Helper(n.right, k - 1, map, res, visited);
        if (map.ContainsKey(n)) Helper(map[n], k - 1, map, res, visited);
    }
}
