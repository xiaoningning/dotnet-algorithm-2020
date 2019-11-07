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
    public int KthSmallest(TreeNode root, int k) {
        // binary search tree
        int cnt = countNodes(root.left);
        if (k <= cnt) return KthSmallest(root.left, k);
         // 1 is counted as current node
        else if (k > cnt + 1) return KthSmallest(root.right, k-1-cnt);
        return root.val;
    }
  
    public int countNodes(TreeNode n) {
      if (n == null) return 0;
      return 1 + countNodes(n.left) + countNodes(n.right);
    }
}
