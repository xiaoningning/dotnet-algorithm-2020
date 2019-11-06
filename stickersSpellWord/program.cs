public class Solution {
    public int MinStickers(string[] stickers, string target) {
        int n = stickers.Length;
        var cnt = new int[n,26];
        for (int i = 0; i < n; i++)
            foreach(var c in stickers[i])
                cnt[i, c - 'a']++;
        var memo = new Dictionary<string, int>();
        memo.Add("", 0);
        return helper(cnt, target, memo);
    }
    int helper(int[,] freq, string target, Dictionary<string, int> memo) {
        if (memo.ContainsKey(target)) return memo[target];
        int res = Int32.MaxValue, N = freq.GetLength(0);
        var cnt = new int[26];
        foreach (char c in target) ++cnt[c - 'a'];
        for (int i = 0; i < N; i++) {
            // trim search
            if (freq[i, target[0] - 'a'] == 0) continue;
            string t = "";
            for (int j = 0; j < 26; ++j) {
                if (cnt[j] - freq[i,j] > 0) t += new string((char)('a' + j), cnt[j] - freq[i,j]);
            }
            int ans = helper(freq, t, memo);
            if (ans != -1) res = Math.Min(res, ans + 1);
        }
        memo[target] = res == Int32.MaxValue ? -1 : res;
        return memo[target];
    }
}
