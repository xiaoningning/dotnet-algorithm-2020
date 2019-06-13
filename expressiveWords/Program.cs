public class Solution {
    public int ExpressiveWords(string S, string[] words) {
        int n = S.Length, res = 0;
        foreach (var w in words) {
            int j = 0, i = 0, m = w.Length;
            for (; i < n; i++) {
                if (j < m && w[j] == S[i]) j++;
                // 3 or more repeats
                else if (i > 0 && S[i] == S[i - 1] && i + 1 < n && S[i] == S[i + 1]);
                else if (i > 1 && S[i] == S[i - 1] && S[i] == S[i - 2]);
                else break;
            }
            if (j == m && i == n) res++;
        }
        return res;
    }
}
