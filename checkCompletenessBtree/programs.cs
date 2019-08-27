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
    public bool IsCompleteTree(TreeNode root) {
        var q = new Queue<TreeNode>();
        var end = false;
        q.Enqueue(root);
        while(q.Count != 0) {
            var t = q.Dequeue();
            if (t == null) {
                end = true;
            } 
            else {
                if(end) return false;
                q.Enqueue(t.left);
                q.Enqueue(t.right);
            }
        }
        return true;
    }
}
