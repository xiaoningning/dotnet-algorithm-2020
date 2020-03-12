public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        var st = new HashSet<string>(words);
        var res = new List<string>();
        foreach (var w in words) {
            int n = w.Length;
            var dp = new bool[n+1];
            dp[0] = true;
            for (int i = 0; i < n; i++) {
                if (!dp[i]) continue;
                for (int j = i + 1; j <= n; j++) {
                    // j - i < exclude itself
                    if (j - i < n && st.Contains(w.Substring(i, j - i))) dp[j] = true;
                }
                if (dp[n]) { 
                    res.Add(w);
                    break;
                }
            }
        }
        return res;
    }
}
