public class Solution {
    public int SuperEggDrop(int K, int N) {
        // # of moves
        int cnt = 0;
        // dp[i, j]: # of floors tested by i moves with j eggs 
        int[,] dp = new int[N+1,K+1];
        while (dp[cnt,K] < N) {
            ++cnt;            
            for (int j = 1; j <= K; j++) {
                // if egg is broken at the floor, dp[i,j] = dp[i-1, j-1];
                // if egg is not broken at the floor, this egg can test one more floor.
                // => dp[i,j] = dp[i-1, j] + 1
                dp[cnt,j] = dp[cnt - 1,j - 1] + dp[cnt - 1,j] + 1;
            }
        }
        // O(KlgN)
        // cnt -> N is cnt-1,j-1 plus cnt-1,j => lgN
        return cnt;
    }
}
