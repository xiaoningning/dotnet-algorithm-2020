public class Solution {
    public int LongestSubstring(string s, int k) {
        int res = 0, i = 0, n = s.Length;
        while (i + k <= n) {
            int[] m = new int[26];
            int mask = 0, max_idx = i;
            for (int j = i; j < n; ++j) {
                int t = s[j] - 'a';
                ++m[t];
                if (m[t] < k) mask |= (1 << t);
                else mask &= (~(1 << t)); // >=k, t bit set as 0.
                
                // all bits = 0, then all >= k
                if (mask == 0) {
                    res = Math.Max(res, j - i + 1);
                    max_idx = j;
                }
            }
            i = max_idx + 1;
        }
        return res;
    }
}
