public class Solution {
    public int GetMoneyAmount(int n) {
        int[,] memo = new int[n+1,n+1];
        return helper(1, n, memo);
    }
    int helper(int start, int end, int[,] memo){
        if (start >= end) return 0;
        if(memo[start, end] != 0) return memo[start, end];
        int res = Int32.MaxValue;
        for(int k = start; k <= end; k++){
            int t = k + Math.Max(helper(start, k-1, memo), helper(k+1, end, memo));
            res = Math.Min(res, t);
        }
        memo[start, end] = res;
        return memo[start, end];
    }   
}
