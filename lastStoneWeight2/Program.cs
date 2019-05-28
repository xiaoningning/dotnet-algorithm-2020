public class Solution {
    public int LastStoneWeightII(int[] stones) {
        // similar to target sum #494
        var s = new HashSet<int>();
        s.Add(stones[0]);
        s.Add(-stones[0]);
        for(int i=1; i<stones.Length; i++) {
            var set2 = new HashSet<int>();
            foreach (int item in s) {
                set2.Add(item + stones[i]);
                set2.Add(item - stones[i]);
            }
            s = set2;
        }
        int min = Int32.MaxValue;
        foreach (int item in s) min = Math.Min(Math.Abs(item), min);
        return min;
    }
    
    public int LastStoneWeightII1(int[] stones) {
        // dp to record the achievable sum of the smaller group
        // 1 <= stones.length <= 30
        // 1 <= stones[i] <= 100
        // total max sum 3000, half is 1501
        // s1 + s2 = sum
        // s1 - s2 = diff
        // => diff = sum - 2* s2
        bool[] dp = new bool[1501];
        dp[0] = true;
        int sum = 0;
        foreach (var s in stones) {
            sum += s;
            // update if the smaller sum exists
            for (int i = 1500; i >= s; i--) {
                dp[i] |= dp[i - s];
            }
        }
        
        for (int i = sum / 2; i >= 0; i--) {
            if (dp[i]) return sum - 2 * i;
        }
        return 0;
    }
}
