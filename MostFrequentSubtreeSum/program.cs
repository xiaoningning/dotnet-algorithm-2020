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
    int cnt = -1;
    Dictionary<int,int> m = new Dictionary<int,int>();
    public int[] FindFrequentTreeSum(TreeNode root) {
        var res = new List<int>();
        PostOrder(root);
        foreach (var kv in m) if (kv.Value == cnt) res.Add(kv.Key);
        return res.ToArray();
    }
    int PostOrder(TreeNode root) {
        if (root == null) return 0;
        int left = PostOrder(root.left);
        int right = PostOrder(root.right);
        int sum = left + right + root.val;
        if (!m.ContainsKey(sum)) m.Add(sum, 0);
        cnt = Math.Max(cnt, ++m[sum]);
        return sum;
    }
}
