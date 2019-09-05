public class Solution {
    public bool SplitArray(int[] nums) {
        int n = nums.Length;
        int[] sums = nums;
        for (int i = 1; i < n; ++i) {
            sums[i] = sums[i - 1] + nums[i];
        }
        // find j first to reduce Time
        // split each side for i and k
        for (int j = 3; j < n - 3; ++j) {
            HashSet<int> s = new HashSet<int>();
            for (int i = 1; i < j - 1; ++i) {
                // s1 == s2
                if (sums[i - 1] == (sums[j - 1] - sums[i])) {
                    s.Add(sums[i - 1]);
                }
            }
            for (int k = j + 1; k < n - 1; ++k) {
                int s3 = sums[k - 1] - sums[j], s4 = sums[n - 1] - sums[k];
                if (s3 == s4 && s.Contains(s3)) return true;
            }
        }
        return false;
    }
}
