public class Solution {
    public int MaxSumAfterPartitioning(int[] A, int K) {
        int N = A.Length;
        // dp[i] = max{dp[i – k] + max(A[i-k:i]) * k}, 1 <= k <= min(i, K)
        int[] dp = new int[N+1];
        for (int i = 1; i <= N; ++i) {
            int mx = Int32.MinValue;
            // at most K
            for (int k = 1; k <= K && i - k >= 0; ++k) {
                mx = Math.Max(mx, A[i - k]);
                // sum of all array after being updated value of each element
                // plus the prev subarray sum
                dp[i] = Math.Max(dp[i], dp[i - k] + mx * k);
            }
        }
        return dp[N];
    }
    public int MaxSumAfterPartitioning1(int[] A, int K) {
        int N = A.Length;
        int[] dp = new int[N];
        for (int i = 0; i < N; ++i) {
            int curMax = 0;
            // at most K
            for (int k = 1; k <= K && i - k + 1 >= 0; ++k) {
                curMax = Math.Max(curMax, A[i - k + 1]);
                // sum of all array after being updated value of each element
                // plus the prev subarray sum
                dp[i] = Math.Max(dp[i], (i >= k ? dp[i - k] : 0) + curMax * k);
            }
        }
        return dp[N - 1];
    }
    // Let k be 2
    // Focus on "growth" of the pattern
    // Define A' to be a partition over A that gives max sum
    
    // #0
    // A = {1}
    // A'= {1} => 1
    
    // #1
    // A = {1, 2}
    // A'= {1}{2} => 1 + 2 => 3 X
    // A'= {1, 2} => {2, 2} => 4 AC
        
    // #2
    // A = {1, 2, 9}
    // A'= {1, 2}{9} => {2, 2}{9} => 4 + 9 => 13 X
    // A'= {1}{2, 9} => {1}{9, 9} => 1 + 18 => 19 AC
    
    // #3
    // A = {1, 2, 9, 30}
    // A'= {1}{2, 9}{30} => {1}{9, 9}{30} => 19 + 30 => 49 X
    // A'= {1, 2}{9, 30} => {2, 2}{30, 30} => 4 + 60 => 64 AC
    
    // Now, label each instance. Use F1() to represent how A is partitioned and use F2() to represent
    // the AC value of that partition. F2() is the dp relation we are looking for.
    
    // #4
    // A = {1, 2, 9, 30, 5}
    // A'= F1(#3){5} => F2(#3) + 5 => 69 X
    // A'= F1(#2){30, 5} => F2(#2) + 30 + 30 => 79 AC
    // => F2(#4) = 79
}
