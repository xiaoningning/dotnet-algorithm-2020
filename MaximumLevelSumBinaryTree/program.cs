/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int MaxLevelSum(TreeNode root) {
        if (root == null) return 0;
        int mx = Int32.MinValue, mlvl = 1, lvl = 1;
        var q = new List<TreeNode>(){root};
        while (q.Any()){
            int sum = q.Sum(x => x.val);
            var tq = new List<TreeNode>();
            foreach (var n in q) {
                if (n.left != null) tq.Add(n.left);
                if (n.right != null) tq.Add(n.right);
            }
            if (sum > mx) {
                mx = sum; mlvl = lvl;
            }
            lvl++;
            q = tq;
        }
        return mlvl;
    }
}
