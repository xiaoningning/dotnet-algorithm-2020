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
    public TreeNode Str2tree(string s) {
        if (s == null || s == "") return null;
        int firstIdx = s.IndexOf("(");
        int val = firstIdx == -1 ? Int32.Parse(s) : Int32.Parse(s.Substring(0, firstIdx));
        var cur = new TreeNode(val);
        if (firstIdx == -1) return cur;
        int start = firstIdx, cnt= 0;
        for (int i = start; i < s.Length; i++) {
            if (s[i] == '(') ++cnt;
            else if (s[i] == ')') --cnt;
            // tree left
            if (cnt == 0 && start == firstIdx) {
                cur.left = Str2tree(s.Substring(start + 1, i - start - 1));
                start = i + 1;
            }
            // tree right
            else if (cnt == 0) {
                cur.right = Str2tree(s.Substring(start + 1, i - start - 1));
            }
            // find ")" -> cnt == 0
        }
        return cur;
    }
}
