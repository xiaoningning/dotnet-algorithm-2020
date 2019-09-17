public class Solution {
    public int UniqueLetterString(string S) {
        // index of last positions of S[i]
        int[][] index = new int[26][];
        for (int i = 0; i < 26; i++) index[i] = new int[2]{-1,-1};
        int res = 0, N = S.Length, mod = (int)Math.Pow(10, 9) + 7;
        for (int i = 0; i < N; ++i) {
            int c = S[i] - 'A';
            res = (res + (i - index[c][1]) * (index[c][1] - index[c][0]) % mod) % mod;
            index[c] = new int[] {index[c][1], i};
        }
        for (int c = 0; c < 26; ++c)
            res = (res + (N - index[c][1]) * (index[c][1] - index[c][0]) % mod) % mod;
        return res;
    }
}
