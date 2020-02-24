public class Solution {
    public int SplitArray(int[] nums, int m) {
        int n = nums.Length;
        int max = 0;
        int min = 0;
        for(int i = 0; i< n; i++){
            min = Math.Max(min, nums[i]);
            max += nums[i];
        }
        // min and max of the sum of nums
        long left = min, right = max;
        // binary search
        while(left < right){
            long mid = left + (right - left)/2;
            // split cnt <= m => smaller mid
            if(valid_split(nums, m, mid)) right = mid;
            else left = mid +1;
        }
        // overflow check
        // O(log(sum(n)) * n)
        return (int)left;
    }
    
    public bool valid_split(int[] nums, int m, long sum){
        int cnt = 1; // cnt of arrays
        int currSum = 0;
        for(int i=0; i< nums.Length; i++){
            if((currSum += nums[i]) > sum){
                currSum = nums[i];
                if (++cnt > m) return false;
            }
        }
        return true;
    }
    
    
    public int SplitArray1(int[] nums, int m) {
        int n = nums.Length;
        // dp[i][j] := min of largest sum of splitting nums[0] ~ nums[j] into i groups.
        int[,] dp = new int[m + 1, n + 1];
        
        for(int i = 0; i <= m; i++ ) {
            for(int j = 0; j <= n; j++){
                dp[i,j] = Int32.MaxValue;
            }
        }
        dp[0,0] = 0;
        
        int[] sum = new int[n+1];
        for(int i = 0; i< n; i++){
            sum[i+1] = sum[i] + nums[i];
        }
        
        for(int i = 1; i <= m; i++ ) {
            for(int j = 1; j <= n; j++){
                for(int k = i-1; k < j; k++){
                    int val = Math.Max(dp[i-1,k], sum[j] - sum[k]);
                    dp[i,j] = Math.Min(dp[i,j], val);
                }
            }
        }
        // O(m*n^2)
        return dp[m,n];
    }
}
