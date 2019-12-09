public class Solution {
    public int UniqueLetterString1(string S) {
        // CACACCAC => CA(CACC)AC, CAC(AC)CAC
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
        int[] dp = new int[26]; // uniq of each char in 26 letters
        int cur = 0, res = 0, mod = (int)Math.Pow(10, 9) + 7;;
        for (int i = 0; i < S.Length; i++) {
            int x = S[i]-'A';
            // - previous uniq of x
            cur -= dp[x] % mod; 
            // current uniq of x
            dp[x] = (i - lastPosition[x]);
            cur += dp[x] % mod; 
            lastPosition[x] = i;
            res += cur % mod;
        }   
        return res;
        
    }
    public int UniqueLetterString3(string S) {
        int res = 0, dp = 0, mod = (int)Math.Pow(10, 9) + 7;        
        int[] first = new int[26], second = new int[26];
        Array.Fill(first, -1);
        Array.Fill(second, -1);
        for (int i = 0; i < S.Length; i++) {
            int x = S[i]-'A';
            dp = dp + (i - first[x]) - (first[x] - second[x]);
            res = (res + dp) % mod;
            second[x] = first[x];
            first[x] = i;
        }   
        return res;
        
    }
}
