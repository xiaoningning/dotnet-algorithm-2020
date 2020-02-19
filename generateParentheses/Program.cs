public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        if (n == 0) return new List<string>(){""};
        var st = new HashSet<string>();
        var pre = GenerateParenthesis(n-1);
        foreach (var str in pre) {
            for (int i = 0; i < str.Length; i++) {
                if (str[i] == '(') 
                    st.Add(str.Substring(0, i+1) +"()" + str.Substring(i+1));
            }
            st.Add("()" + str);
        }
        return st.ToList();
    }
    public IList<string> GenerateParenthesis1(int n) {
        var res = new List<string>();
        dfs(n, n, "", res);
        // O(2^n)
        return res;
    }
    void dfs(int l, int r, string s, List<string> res) {
        // if l > r, )(
        if (l > r) return;
        if (l == 0 && r == 0) res.Add(s);
        else {
            if (l>0) dfs(l-1, r, s+"(", res);
            if (r>0) dfs(l, r-1, s+")", res);
        }
    }
}
