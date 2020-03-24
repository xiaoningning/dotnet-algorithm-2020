public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i]) {
                swap(nums, i, nums[i] - 1);
            }
        }
        for (int i = 0; i < n; ++i) {
            if (nums[i] != i + 1) return i + 1;
        }
        // time: O(n) space: O(1)
        // the last positive is missing
        return n + 1;
    }
    void swap(int[] nums, int i, int j) {
        int t = nums[i]; nums[i] = nums[j]; nums[j] = t;
    }
    public int FirstMissingPositive1(int[] nums) {
        HashSet<int> s = new HashSet<int>();
        int max = 0;
        foreach (int n in nums) {
            if (n > 0) {
                s.Add(n);
                max = Math.Max(max, n);
            }
        }
        for (int i = 1; i <= max; i++){
            if (!s.Contains(i)) return i;
        }
        // the last positive is missing
        return max + 1;
    }
}
