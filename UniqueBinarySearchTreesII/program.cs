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
    public IList<TreeNode> GenerateTrees(int n) {
        if (n== 0) return new List<TreeNode>();
        var m = new Dictionary<int, Dictionary<int,List<TreeNode>>>();
        return Helper(1, n, m);
    }
    List<TreeNode> Helper(int start, int end, Dictionary<int, Dictionary<int,List<TreeNode>>> m) {
        if (start > end) return new List<TreeNode>(){null};
        if (m.ContainsKey(start) && m[start].ContainsKey(end)) return m[start][end];
        var res = new List<TreeNode>();
        for(int i = start; i <= end; i++){
            var left = Helper(start, i - 1, m);
            var right = Helper(i + 1, end, m);
            foreach (var a in left) {
                foreach (var b in right) {
                    var n = new TreeNode(i);
                    n.left = a;
                    n.right = b;
                    res.Add(n);
                }
            }
        }
        if (!m.ContainsKey(start)) m.Add(start, new Dictionary<int,List<TreeNode>>());
        m[start][end] = res;
        return m[start][end];
    }
}
