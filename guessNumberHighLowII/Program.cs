public class Solution {
    public int GetMoneyAmount(int n) {
        var dp = new int[n+1,n+1];
        for (int i = 2; i <= n; i++) {
            for (int j = i - 1; j > 0; j--) {
                int global_min = Int32.MaxValue;
                for (int k = j + 1; k < i; k++) {
                    int local_max = k + Math.Max(dp[j,k-1], dp[k+1,i]);
                    global_min = Math.Min(global_min, local_max);
                }
                // j + 1 == i edge case b/s no k
                dp[j,i] = j + 1 == i ? j : global_min; 
            }
        }
        return dp[1, n];
    }
    public int GetMoneyAmount1(int n) {
        int[,] memo = new int[n+1,n+1];
        return helper(1, n, memo);
    }
    
    int helper(int start, int end, int[,] memo){
        if (start >= end) return 0;
        if(memo[start, end] != 0) return memo[start, end];
        int res = Int32.MaxValue;
        for(int k = start; k <= end; k++){
            // max the worst case of guess
            int t = k + Math.Max(helper(start, k-1, memo), helper(k+1, end, memo));
            // min the overall cost
            res = Math.Min(res, t);
        }
        memo[start, end] = res;
        return memo[start, end];
    }   
}
