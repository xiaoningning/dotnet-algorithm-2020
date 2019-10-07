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
    
    public int SumNumbers(TreeNode root) {
        return sum(root, 0);
    }
    int sum(TreeNode n, int s){
        if (n == null) return 0;
        // 0 <= val <= 9
        if (n.right == null && n.left == null) return s*10 + n.val;
        return sum(n.left, s*10 + n.val) + sum(n.right, s*10 + n.val);
    }
}
