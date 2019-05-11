public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums.Length == 0) return 0;
        List<int> dp = new List<int>();
        for (int i = 0; i < nums.Length; i++){
            int left = 0, right = dp.Count();
            while (left < right) {
                int mid = left + (right - left) /2;
                // binary search to find 
                // 1st one >= nums[i]
                if (dp[mid] < nums[i]) left = mid +1;
                else right = mid;
            }
            if (right >= dp.Count()) dp.Add(nums[i]);
            else dp[right] = nums[i];
        }
        // O(nlogn)
        return dp.Count();
    }
    public int LengthOfLIS1(int[] nums) {
        if (nums.Length == 0) return 0;
        List<int> ends = new List<int>(){nums[0]};
        foreach (var a in nums) {
            if (a < ends[0]) ends[0] = a;
            else if (a > ends.Last()) ends.Add(a);
            else {
                // binary search to find 
                // 1st one >= a
                int left = 0, right = ends.Count();
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (ends[mid] < a) left = mid + 1;
                    else right = mid;
                }
                ends[right] = a;
            }
        }
        // O(nlogn)
        return ends.Count();
    }
}
