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
    public IList<int> InorderTraversal(TreeNode root) {
        var res = new List<int>();
        InOrder(root, res);
        return res;
    }
    void InOrder(TreeNode root, List<int> res) {
        if (root == null) return;
        InOrder(root.left, res);
        res.Add(root.val);
        InOrder(root.right, res);
    }
    public IList<int> InorderTraversal1(TreeNode root) {
        var res = new List<int>();
        // find the far left first
        // so use stack instead of queue
        var q = new Stack<TreeNode>();
        while (root != null || q.Any()) {
            while(root != null){
                q.Push(root);
                root = root.left;
            }
            var t = q.Pop();
            res.Add(t.val);
            root = t.right;
        }
        return res;
    }
}
