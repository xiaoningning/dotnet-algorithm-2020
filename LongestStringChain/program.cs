public class Solution {
    public int LongestStrChain(string[] words) {
        var dp = new Dictionary<string, int>();
        Array.Sort(words, (a, b) => a.Length - b.Length);
        int res = 0;
        foreach (string word in words) {
            int best = 0;
            for (int i = 0; i < word.Length; ++i) {
                string prev = word.Substring(0, i) + word.Substring(i + 1);
                best = Math.Max(best, dp.GetValueOrDefault(prev, 0) + 1);
            }
            dp[word] = best;
            res = Math.Max(res, best);
        }
        return res;
    }
}
