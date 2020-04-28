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
    public TreeNode ConstructFromPrePost(int[] pre, int[] post) {
        var st = new List<TreeNode>(){new TreeNode(pre[0])};
        for (int i = 1, j = 0; i < pre.Length; i++) {
            var node = new TreeNode(pre[i]);
            while (st.Last().val == post[j]) {
                st.RemoveAt(st.Count - 1);
                j++;
            }
            if (st.Last().left == null) st.Last().left = node;
            else st.Last().right = node;
            st.Add(node);
        }
        // O(n)
        return st.First();
    }
    int preIdx = 0; int postIdx = 0;
    public TreeNode ConstructFromPrePost2(int[] pre, int[] post) {
        var root = new TreeNode(pre[preIdx++]);
        // post order => do lelf, then do right until pre root meets post root
        if (root.val != post[postIdx]) root.left = ConstructFromPrePost2(pre, post);
        if (root.val != post[postIdx]) root.right = ConstructFromPrePost2(pre, post);
        postIdx++;
        // O(n)
        return root;
    }
    public TreeNode ConstructFromPrePost1(int[] pre, int[] post) {
        // O(n)
        return helper(pre, 0, pre.Length - 1, post, 0, post.Length - 1);
    }
    TreeNode helper(int[] pre, int prel, int prer, int[] post, int postl, int postr) {
        if (prel > prer || postl > postr) return null;
        var node = new TreeNode(pre[prel]);
        if (prel == prer) return node;
        int i = 0;
        for (i = postl; i <= postr; i++) if (pre[prel+1] == post[i]) break;
        node.left = helper(pre, prel+1, prel+1+i-postl, post, postl, i);
        node.right = helper(pre, prel+1+i-postl+1, prer, post, i+1, postr-1);
        return node;
    }
}
