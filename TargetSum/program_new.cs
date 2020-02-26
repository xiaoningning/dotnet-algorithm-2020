public class Solution {
    /*
    sum(P) - sum(N) = target
    sum(P) + sum(N) + sum(P) - sum(N) = target + sum(P) + sum(N)
    2 * sum(P) = target + sum(nums)
    */
    public int FindTargetSumWays(int[] nums, int S) {
        int sum = nums.Sum();
        int s = Math.Abs(S); // S can be negative
        if (sum < S || (sum + S) % 2 != 0) return 0;
        int target = (sum + s) / 2;
        var dp = new int[target + 1];
        dp[0] = 1;
        foreach (var n in nums)
            for (int i = target; i >= n; i--)
                dp[i] += dp[i-n];
        // O(n*sum)
        return dp.Last();
    }
    
    public int FindTargetSumWays1(int[] nums, int S) {
        int n = nums.Length;
        List<Dictionary<int, int>> dp = new List<Dictionary<int, int>>();
        // dict: key -> sum, value -> total cnt to get sum
        dp.Add(new Dictionary<int, int>());
        dp[0].Add(0,1);
        for (int i = 0; i < n; ++i) {
            // i + 1
            dp.Add(new Dictionary<int, int>());
            foreach (var a in dp[i]) {
                int sum = a.Key, cnt = a.Value;
                dp[i + 1][sum + nums[i]] = dp[i+1].ContainsKey(sum + nums[i])? dp[i + 1][sum + nums[i]] + cnt : cnt;
                dp[i + 1][sum - nums[i]] = dp[i+1].ContainsKey(sum - nums[i])? dp[i + 1][sum - nums[i]] + cnt : cnt;
            }
        }
        // O(2^n)
        return dp[n].ContainsKey(S) ? dp[n][S] : 0; 
    }
    
    public int FindTargetSumWays2(int[] nums, int S) {
        int res = 0;
        Helper(nums, S, 0, ref res);
        return res;
    }

    void Helper(int[] nums, int S, int start, ref int res) {
        if (start == nums.Length) {
            if (S == 0) res++;
            return;
        }
        Helper(nums, S + nums[start], start+1, ref res);
        Helper(nums, S - nums[start], start+1, ref res);
    }
    
}
