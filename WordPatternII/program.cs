public class Solution {
    HashSet<string> st;
    Dictionary<char, string> m;
    public bool WordPatternMatch(string pattern, string str) {
        st = new HashSet<string>();
        m = new Dictionary<char,string>();
        return IsMatch(str, 0, pattern, 0);
    }
    bool IsMatch(string str, int r, string pat, int p) {
        if (p == pat.Length && r == str.Length) return true;
        if (p == pat.Length || r == str.Length) return false;
        char c = pat[p];
        for (int i = r; i < str.Length; ++i) {
            string t = str.Substring(r, i - r + 1);
            if (m.ContainsKey(c) && m[c] == t) {
                if (IsMatch(str, i + 1, pat, p + 1)) return true;
            } 
            else if (!m.ContainsKey(c)) {
                if (st.Contains(t)) continue;
                m[c] = t;
                st.Add(t);
                if (IsMatch(str, i + 1, pat, p + 1)) return true;
                m.Remove(c);
                st.Remove(t);
            }
        }
        return false;
    }
}
