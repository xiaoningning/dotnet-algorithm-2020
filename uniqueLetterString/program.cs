public class Solution {
    public int UniqueLetterString1(string S) {
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
    public int UniqueLetterString(string S) {
        int[] lastPosition = new int[26];
        Array.Fill(lastPosition, -1);
        int[] cnt = new int[26];
        int cur = 0, res = 0;
        for (int i = 0; i < S.Length; i++) {
            int x = S[i]-'A';
            cur -= cnt[x]; 
            cnt[x] = (i - lastPosition[x]);
            cur += cnt[x]; 
            lastPosition[x] = i;
            res += cur;
        }   
        return res;
        
    }
}
