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
    public TreeNode SortedArrayToBST(int[] nums) {
        if (nums.Length == 0) return null;
        return Helper(nums, 0, nums.Length - 1);        
    }
    TreeNode Helper(int[] nums, int l, int r) {
        if (l > r) return null;
        int m = l + (r - l) / 2;
        var node = new TreeNode(nums[m]);
        node.left = Helper(nums, l, m - 1);
        node.right = Helper(nums, m + 1, r);
        return node;
    }
}
