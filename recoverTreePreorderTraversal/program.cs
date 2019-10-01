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
        var st = new Stack<TreeNode>();
        int i = 0, level = 0, val = 0, n = S.Length;
        while (i < n) {
            for (level = 0; i < n && S[i] == '-'; ++i) {
                ++level;Console.WriteLine(level);
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
