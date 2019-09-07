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
}
