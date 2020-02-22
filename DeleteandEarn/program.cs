public class Solution {
    public int DeleteAndEarn(int[] nums) {
        if (!nums.Any()) return 0;
        int n = nums.Max() + 1;
        var cnt = new int[n];
        foreach (var nm in nums) cnt[nm] += nm;
        // 198 house robber
        int take = 0;
        int skip = 0;
        for (int i = 0; i < n; i++) {
            int takei = skip + cnt[i];
            int skipi = Math.Max(skip, take);
            take = takei; skip = skipi;
        }
        return Math.Max(take, skip);
    }
}
