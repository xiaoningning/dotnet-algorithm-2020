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
    public TreeNode RecoverFromPreorder(string S) {
        int i = 0;
        return helper(S, ref i, 0);
    }
    TreeNode helper(string S, ref int cur, int level){
        int cnt = 0, n = S.Length, val = 0;
        while (cur + cnt < n && S[cur + cnt] == '-') ++cnt;
        if (cnt != level) return null;
        cur += cnt;
        for (; cur < n && S[cur] != '-'; ++cur) {
            val = 10 * val + (S[cur] - '0');
        }
        TreeNode node = new TreeNode(val);
        node.left = helper(S, ref cur, level + 1);
        node.right = helper(S, ref cur, level + 1);
        return node;
    }
    
    public TreeNode RecoverFromPreorder1(string S) {
        var st = new Stack<TreeNode>();
        int i = 0, level = 0, val = 0, n = S.Length;
        while (i < n) {
            for (level = 0; i < n && S[i] == '-'; ++i) {
                ++level;
            }
            for (val = 0; i < n && S[i] != '-'; ++i) {
                val = 10 * val + (S[i] - '0');
            }
            TreeNode node = new TreeNode(val);
            while (st.Count > level) st.Pop();
            if (st.Any()) {
                if (st.Peek().left == null) st.Peek().left = node;
                else st.Peek().right = node;
            }
            st.Push(node);
        }
        return st.Last();
    }
}
