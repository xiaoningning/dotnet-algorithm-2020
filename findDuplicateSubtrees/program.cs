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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        var res = new List<TreeNode>();
        var m = new Dictionary<string, int>();
        Helper(root, res, m);
        return res;
    }
    string Helper (TreeNode node, List<TreeNode> res, Dictionary<string, int> m) {
        if (node == null) return "#";
        string str = node.val + "," + Helper(node.left, res, m) + "," + Helper(node.right, res, m);
        if (!m.ContainsKey(str)) m.Add(str,0);
        // check == 1 here, so only add once
        if (m[str] == 1) res.Add(node);
        m[str]++;
        return str;
    }
}
