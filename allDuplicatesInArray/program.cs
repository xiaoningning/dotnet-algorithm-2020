public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var res = new List<int>();
        // 1 <= a[i] <= nums.Length
        for (int i = 0; i < nums.Length; i++) {
            int idx = Math.Abs(nums[i]) - 1;
            // if duplicate, num[idx] is already marked as negative
            if (nums[idx] < 0) res.Add(idx + 1);
            nums[idx] = -nums[idx];
        }
        return res;
    }
    public IList<int> FindDuplicates(int[] nums) {
        var res = new List<int>();
        // 1 <= a[i] <= nums.Length
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] != nums[nums[i] - 1]) {
                swap(nums, i, nums[i] - 1);
                --i;
            }
        }
        for (int i = 0; i < nums.Length; ++i) {
            if (nums[i] != i + 1) res.Add(nums[i]);
        }
        return res;
    }
    void swap(int[] nums, int i, int j) {
        int t = nums[i]; nums[i] = nums[j]; nums[j] = t;
    }
}
