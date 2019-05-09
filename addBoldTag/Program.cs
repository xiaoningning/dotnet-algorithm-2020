public class Solution {
    public string AddBoldTag(string s, string[] dict) {
        int n = s.Length;
        string res = "";
        bool[] bold = new bool[n];
        foreach(var w in dict) {
            int len = w.Length;
            for (int i = 0; i <= n - len; i++) {
                if (s[i] == w[0] && s.Substring(i,len) == w) {
                    for (int j = i; j < i + len; ++j) bold[j]= true;
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            if (bold[i]) {
                if (i == 0 || !bold[i - 1]) res += "<b>";
                res += s[i];
                if (i == n - 1 || !bold[i + 1]) res += "</b>";
            } else {
                res += s[i];
            }
        }
        return res;
    }
}
