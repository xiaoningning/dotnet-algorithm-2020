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
    public IList<IList<string>> PrintTree(TreeNode root) {
        // BT width: 2^height - 1
        int h = GetHeight(root), w = (int)Math.Pow(2, h)  - 1;
        var res = new List<IList<string>>();
        for (int i = 0; i < h; i++) {
            res.Add(new List<string>());
            for (int j = 0; j < w; j++) res[i].Add("");
        }
        Helper(root, 0, w - 1, 0, h, res);
        return res;
    }
    void Helper(TreeNode node, int i, int j, int curH, int h, IList<IList<string>> res) {
        if (node == null || curH == h) return;
        res[curH][(i + j) / 2] = node.val.ToString();
        Helper(node.left, i, (i + j) / 2, curH + 1, h, res);
        Helper(node.right, (i + j) / 2 + 1, j, curH + 1, h, res);
    }
    int GetHeight(TreeNode root) {
        if (root == null) return 0;
        return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
    }
}
