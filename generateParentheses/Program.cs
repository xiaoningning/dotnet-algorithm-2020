public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var res = new List<string>();
        Helper(n, n, "", res);
        return res;
    }
    void Helper(int l, int r, string s, List<string> res) {
        // if l > r, )(
        if (l > r) return;
        if (l == 0 && r == 0) res.Add(s);
        else {
            if (l>0) Helper(l-1, r, s+"(", res);
            if (r>0) Helper(l, r-1, s+")", res);
        }
    }
}
