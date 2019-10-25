public class Solution {
    public int NumMusicPlaylists(int N, int L, int K) {
        int M = (int) Math.Pow(10,9) + 7;
        long[,] dp = new long[L+1, N+1];
        dp[0,0] = 1;
        for (int i = 1; i <= L; i++){
            for (int j = 1; j <= N; j++){ 
                // pick a new song from N
                dp[i, j] = (dp[i-1,j-1] * (N - (j-1))) % M; 
                if (j > K){
                    // the old song can be repeated other than K
                    dp[i, j] = (dp[i, j] + (dp[i-1, j] * (j-K)) % M) % M;
                }
            }
        }
        return (int) dp[L, N];
    }
}
