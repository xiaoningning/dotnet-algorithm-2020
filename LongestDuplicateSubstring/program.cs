public class Solution {
    int n;
    int[] A;
    int b = 26; // only low char
    long mod = 1 << 63 - 1; // 64 bit
    public string LongestDupSubstring(string S) {
        n = S.Length;
        A = new int[n];
        for (int i = 0; i < n; i++) A[i] = S[i] -'a';
        int res = -1, l = 1, r = n, k = 0;
        // binary search len
        while (l <= r) {
            int mid = l + (r - l) / 2;
            int pos = TestDup(mid);
            if (pos >= 0) {
                l = mid + 1;
                k = mid;
                res = pos;
            }
            else r = mid - 1;
        }
        // O(NlogN)
        return res >= 0 ? S.Substring(res, k) : "";
    }
    int TestDup(int len) {
        var seen = new HashSet<long>();
        long p = (long)Math.Pow(26, len) % mod; // prime number
        long hash = 0;
        for (int i = 0; i < len; i++) hash = (hash * b + A[i]) % mod;
        long bL = 1;
        for (int i = 1; i < len; i++) bL = (bL * b) % mod;
        seen.Add(hash);
        for (int i = len; i < n; i++) {
            hash -= (A[i - len] * bL) % mod;
            hash = (hash * b + A[i]) % mod;
            if (seen.Contains(hash)) return i - len + 1;
            else seen.Add(hash);
        }
        return -1;
    }
}
