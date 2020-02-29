public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var res = new List<int>();
        int n = nums.Length;
        // 1 ≤ nums[i] ≤ n
        for (int i = 0; i < n; i++) nums[(nums[i] - 1) % n] += n; // % n => no overflow
        for (int i = 0; i < n; i++) if (nums[i] <= n) res.Add(i + 1);
        return res;
    }
}
