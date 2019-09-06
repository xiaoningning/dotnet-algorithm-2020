public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        int sum = nums.Sum();
        if (sum % k != 0) return false;
        var visited = new bool[nums.Length];
        return Helper(nums, k, sum / k, 0, 0, visited);
    }
    bool Helper(int[] nums, int k, int target, int start, int curSum, bool[] visited) {
        if (k == 1) return true;
        // all nums are positive
        if (curSum > target) return false;
        if (curSum == target) return Helper(nums, k - 1, target, 0, 0, visited);
        for (int i = start; i < nums.Length; i++) {
            if (visited[i]) continue;
            visited[i] = true;
            if (Helper(nums, k, target, i + 1, curSum + nums[i], visited)) return true;
            visited[i] = false;
        }
        return false;
    }
}
